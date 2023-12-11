using Nox.Lib.Presentation.Api.EndPointAddressBuilder;
using Nox.Solution;

namespace ClientApi.Tests
{

    public class EndPointsFixture
    {
        private IEndPointForService _endPointAddress;
        public IEndPointForEntity EndPointForEntity { get; }

        public NoxSolution NoxSolution { get; }
        public EndPointsFixture(string entityName)
        {
            NoxSolution = new NoxSolutionBuilder().Build();
            _endPointAddress = EndPointAddressBuilder.CreateBuilder(NoxSolution);
            EndPointForEntity = _endPointAddress.WithEntity(NoxSolution.Domain!.GetEntityByName(entityName));
        }
    }

    /// <summary>
    /// To be remove use <see cref="EndPointsFixture"/> instead.
    /// </summary>
    public static class Endpoints
    {
        public const string RoutePrefix = "/api/v1";
        public const string CountriesUrl = $"{RoutePrefix}/countries";
        public const string StoreLicensesUrl = $"{RoutePrefix}/storelicenses";
        public const string StoreOwnersUrl = $"{RoutePrefix}/storeowners";
        public const string StoresUrl = $"{RoutePrefix}/stores";
        public const string ClientsUrl = $"{RoutePrefix}/clients";
        public const string WorkplacesUrl = $"{RoutePrefix}/workplaces";
        public const string ReferenceNumberUrl = $"{RoutePrefix}/ReferenceNumberEntities";
        public const string RatingProgramsUrl = $"{RoutePrefix}/ratingprograms";
        public const string CurrenciesUrl = $"{RoutePrefix}/currencies";
        public const string TenantsUrl = $"{RoutePrefix}/tenants";
        public const string CountryQualityOfLifeIndicesUrl = $"{RoutePrefix}/CountryQualityOfLifeIndices";
        public const string LanguagesUrl = $"{RoutePrefix}/Languages";

    }
}
