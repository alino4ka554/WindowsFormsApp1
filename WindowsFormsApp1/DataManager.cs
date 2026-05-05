using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DataManager
    {
        private static readonly DataManager _instance = new DataManager();

        public static DataManager Instance => _instance;

        private DataManager() { }

        public void AddProject(Project project)
        {
            DataStorage.Projects.Add(project.Id, project);
        }
        public void DeleteProject(Project project)
        {
            foreach (var op in project.Operations)
                DataStorage.Operations.Remove(op.Id);
            DataStorage.Projects.Remove(project.Id);
            DeleteSolution();
        }
        public void AddOperation(Operation operation)
        {
            var project = DataStorage.Projects[operation.Project];
            project.Operations.Add(operation);
            DataStorage.Operations.Add(operation.Id, operation);
        }
        public void DeleteOperation(Operation operation)
        {
            var project = DataStorage.Projects[operation.Project];
            project.Operations.RemoveAll(op => op.Id == operation.Id);
            DataStorage.Operations.Remove(operation.Id);
            DeleteDependingOperation(operation.Id);
            DeleteSolution();
        }
        public void AddExecutor(Resource executor)
        {
            DataStorage.Executors.Add(executor.Id, executor);
        }
        public void DeleteExecutor(Resource executor)
        {
            var opsToDelete = DataStorage.Operations.Values
                .Where(op => op.Resource == executor.Id)
                .ToList();
            foreach (var op in opsToDelete)
            {
                DeleteOperation(op);
            }
            DataStorage.Executors.Remove(executor.Id);
            DeleteSolution();
        }
        public void DeleteDependingOperation(int operation)
        {
            foreach (var op in DataStorage.Operations.Values)
            {
                if(op.DependsOn.Contains(operation))
                    op.DependsOn.Remove(operation);
            }
        }
        public int GetNextProjectId()
        {
            return DataStorage.Projects.Count == 0 ? 1 : DataStorage.Projects.Keys.Max() + 1;
        }

        public int GetNextExecutorId()
        {
            return DataStorage.Executors.Count == 0 ? 1 : DataStorage.Executors.Keys.Max() + 1;
        }

        public int GetNextOperationId()
        {
            return DataStorage.Operations.Count == 0 ? 1 : DataStorage.Operations.Keys.Max() + 1;
        }
        public void DeleteSolution()
        {
            DataStorage.Solution = null;
        }
    }
}
