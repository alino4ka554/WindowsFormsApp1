using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ACO
    {
        public int _iterations;
        public Dictionary<int, int> _ants = new Dictionary<int, int>();
        private double _beta;
        private double _alpha;
        private double _rho;
        private double _tauMin;
        private double _tauMax;
        private double _Q;
        private Dictionary<int, double> _resourceFree = new Dictionary<int, double>();
        private Dictionary<int, Operation> _operations = new Dictionary<int, Operation>();
        public Dictionary<(int, int), double> _pheromones = new Dictionary<(int, int), double>();
        public Dictionary<(int, int), double> _localPheromones = new Dictionary<(int, int), double>();
        public Dictionary<(int, int), double> _probabilities = new Dictionary<(int, int), double>();
        public Dictionary<int, int> counter = new Dictionary<int, int>();
        public ScheduleSolution BestSolution;
        private Random _rnd = new Random();
        private Dictionary<int, List<int>> _resourcesOperations = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> _projectsOperations = new Dictionary<int, List<int>>();
        public double GetRandomChoice() => _rnd.NextDouble();

        public ACO(Dictionary<int,Operation> operations, int iterations, int ants,
                         double beta, double alpha, double rho,
                         double tauMin, double tauMax)
        {
            _operations = operations;
            _iterations = iterations;
            //_ants = ants;
            _beta = beta;
            _alpha = alpha;
            _rho = rho;
            _tauMin = tauMin;
            _tauMax = tauMax;
            //_Q = CalculateQ(operations);
            _Q = 1;
            InitializeData(ants);
        }
        private void InitializeData(int ants)
        {
            OpsToProjects();
            OpsToResources();
            InitPheromones();
            InitAnts(ants);
        }
        public void InitAnts(int count)
        {
            var resources = _resourcesOperations.Keys.ToList();
            for (int i = 0; i < count; i++)
            {
                int resourceId = i % resources.Count;
                _ants.Add(i, resourceId);
            }
        }
        public void InitPheromones()
        {
            foreach (var i in _operations.Values)
            {
                foreach (var j in _operations.Values)
                {
                    if (!CanCreateEdge(i, j)) continue;
                    _localPheromones[(i.Id, j.Id)] = 0;
                    _pheromones[(i.Id, j.Id)] = _tauMax;
                }
            }
        }
        private bool CanCreateEdge(Operation i, Operation j)
        {
            return i != j && i.Resource == j.Resource;
        }
        //private void InitAnts(int ants)
        //{
        //    for(int i = 0; i <= _operations.Count; i++)
        //    {
        //        if (i <= ants)
        //            _ants.Add(i + 1, i);
        //    }
        //}
        public void OpsToProjects()
        {
            foreach (var op in _operations.Values)
            {
                if (!_projectsOperations.ContainsKey(op.Project))
                    _projectsOperations.Add(op.Project, new List<int>());
                _projectsOperations[op.Project].Add(op.Id);
            }
        }
        public void OpsToResources()
        {
            foreach (var op in _operations.Values)
            {
                AddOperationToResource(op);
            }
        }
        private void AddOperationToResource(Operation op)
        {
            if (!_resourcesOperations.ContainsKey(op.Resource))
                _resourcesOperations[op.Resource] = new List<int>();

            _resourcesOperations[op.Resource].Add(op.Id);

            if (!_resourceFree.ContainsKey(op.Resource))
                _resourceFree[op.Resource] = 0;
        }
        private int SelectNextResource(int currentRes, List<int> visitedRes)
        {
            var nextRes = currentRes;
            while (visitedRes.Contains(nextRes))
            {
                if (visitedRes.Count == _resourcesOperations.Count)
                    break;
                nextRes = (int)(GetRandomChoice() * _resourcesOperations.Count);
            }
            return nextRes;
        }
        public ScheduleSolution RecursiveBuild(int firstResource)
        {
            var operationsCopy = _operations.ToDictionary(
                kvp => kvp.Key,
                kvp => (Operation)kvp.Value.CloneOriginal());
            ScheduleSolution solution = new ScheduleSolution(operationsCopy, _pheromones);
            List<int> visited = new List<int>();
            List<int> visitedRes = new List<int>();
            var currentRes = firstResource;
            var flag = 7;
            while (visited.Count != operationsCopy.Count)
            {
                var operationsByResource = new List<int>(_resourcesOperations.ElementAt(currentRes).Value);
                var prevOp = -1;
                foreach (var op in operationsByResource)
                {
                    var currentOp = CalculateNextOperation(0, operationsByResource, operationsCopy);
                    if (!visited.Contains(currentOp))
                        VisitOperation(prevOp, currentOp, ref visited, solution);
                    prevOp = currentOp;
                }
                visitedRes.Add(currentRes);
                currentRes = SelectNextResource(currentRes, visitedRes);

            }
            return solution;
        }
        public void VisitOperation(int prevOp, int currentOp, ref List<int> visited, ScheduleSolution solution)
        {
            if (_operations[currentOp].DependsOn.Count != 0)
            {
                foreach (var op in _operations[currentOp].DependsOn)
                {
                    if (visited.Contains(op)) continue;
                    if(_operations.ContainsKey(op))
                        VisitOperation(-2, op, ref visited, solution);
                }
            }
            if (!visited.Contains(currentOp))
            {
                var operationsByResource = new List<int>(_resourcesOperations[_operations[currentOp].Resource]);
                if (prevOp != -2)
                {
                    visited.Add(currentOp);
                    solution.AddToResource(currentOp, _operations[currentOp].Resource);
                }
                else currentOp = 0;
                foreach (var op in visited)
                {
                    if (operationsByResource.Contains(op)) operationsByResource.Remove(op);
                }
                while (operationsByResource.Any())
                {
                    var op = CalculateNextOperation(currentOp, operationsByResource, solution.Operations);
                    if (!visited.Contains(op))
                    {
                        VisitOperation(currentOp, op, ref visited, solution);
                    }
                    currentOp = op;
                    operationsByResource.Remove(op);
                }
            }
        }
        public int CalculateNextOperation(int currentOp, List<int> operations, Dictionary<int, Operation> currentOperations)
        {
            Dictionary<int, double> probabilities = new Dictionary<int, double>();
            double summary = 0;
            foreach (var operation in operations)
            {
                double F = 1 / (currentOperations[operation].StartTime + 1);
                if (currentOp != 0)
                {
                    double pheij = _pheromones[(currentOp, operation)];
                    _probabilities[(currentOp, operation)] = (Math.Pow(F, _beta) * Math.Pow(pheij, _alpha));
                    probabilities[operation] = _probabilities[(currentOp, operation)];
                }
                else
                {
                    double pheij = _tauMax;
                    probabilities[operation] = (Math.Pow(F, _beta) * Math.Pow(pheij, _alpha));
                }
                summary += probabilities[operation];
            }
            var randomValue = GetRandomChoice();
            double cumulative = 0;
            foreach (var probability in probabilities)
            {
                cumulative += probability.Value / summary;
                if (randomValue <= cumulative)
                    return probability.Key;
            }
            return operations.Last();
        }
        public void Run(IProgress<int> progress)
        {
            CalculateFirstStartTimes();
            for (int i = 0; i < _iterations; i++)
            {
                RunIteration();
                progress.Report(i);
                GlobalUpdatePheromones();
                Console.WriteLine($"Итерация {i}: лучшее время = {BestSolution.TotalTime}");
            }
        }
        private void RunIteration()
        {
            foreach (var ant in _ants)
            {
                ProcessAnt(ant);
            }
        }
        private void ProcessAnt(KeyValuePair<int, int> ant)
        {
            var solution = RecursiveBuild(ant.Value);
            if (solution == null) return;
            solution.CalculateEndTime();
            UpdateBest(solution);
            LocalUpdatePheromones(solution);
        }
        public void CalculateFirstStartTimes()
        {
            foreach (var project in _projectsOperations)
            {
                foreach (var op in project.Value)
                {
                    if (_operations[op].DependsOn.Count == 0)
                        _operations[op].StartTime = 0;
                    else
                    {
                        var flag = 0.0;
                        foreach (var pred in _operations[op].DependsOn)
                        {
                            if (_operations.ContainsKey(pred))
                            {
                                if (_operations[pred].StartTime + _operations[pred].ActualTime > flag)
                                    flag = _operations[pred].StartTime + _operations[pred].ActualTime;
                            }
                        }
                        _operations[op].StartTime = flag;
                    }
                }
            }
        }
        private void UpdateBest(ScheduleSolution solution)
        {
            if (BestSolution == null || solution.TotalTime < BestSolution.TotalTime)
                BestSolution = solution;
        }
        public void GlobalUpdatePheromones()
        {
            EvaporatePheromones();
            ReinforceBestSolution();
            ResetLocalPheromones();
        }
        private void EvaporatePheromones()
        {
            foreach (var key in _pheromones.Keys.ToList())
            {
                _pheromones[key] *= (1 - _rho);

                if (_pheromones[key] < _tauMin)
                    _pheromones[key] = _tauMin;
            }
        }
        private void ReinforceBestSolution()
        {
            foreach (var ops in BestSolution.W.Keys)
            {
                if (BestSolution.W[ops] != 1) continue;

                _pheromones[ops] += _localPheromones[ops];

                if (_pheromones[ops] > _tauMax)
                    _pheromones[ops] = _tauMax;
            }
        }
        private void ResetLocalPheromones()
        {
            foreach (var key in _localPheromones.Keys.ToList())
                _localPheromones[key] = 0;
        }
        public void LocalUpdatePheromones(ScheduleSolution solution)
        {
            foreach (var ops in solution.W.Keys)
            {
                if (solution.W[(ops)] == 1)
                    _localPheromones[ops] += _Q / solution.TotalTime;
            }
        }
    }
}
