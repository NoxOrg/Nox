using Nox.Solution;

namespace Nox.Generator.Common
{
    public class NoxSolutionCodeGeneratorState
    {
        private readonly NoxSolution _noxSolution;

        public NoxSolutionCodeGeneratorState(NoxSolution noxSolution)
        {
            _noxSolution = noxSolution;
        }

        public NoxSolution Solution => _noxSolution;
        public string RootNameSpace => _noxSolution.Name;
        public string DomainNameSpace => $"{RootNameSpace}.Domain";
        public string ApplicationNameSpace => $"{RootNameSpace}.Application";
        public string DataTransferObjectsNameSpace => $"{RootNameSpace}.Application.DataTransferObjects";
        public string PersistenceNameSpace => $"{RootNameSpace}.Infrastructure.Persistence";
        public string ODataNameSpace => $"{RootNameSpace}.Presentation.Api.OData";
        public string Events => $"{RootNameSpace}.Application.Events";


        public string GetForeignKeyPropertyName(string foreignEntityName)
        {
            return $"{foreignEntityName}Id";
        }

    }
}