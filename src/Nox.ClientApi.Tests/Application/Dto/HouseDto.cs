using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.OData.ModelBuilder;

namespace ClientApi.Tests.Application.Dto
{
    public record HouseDto(int Id, string Name);

    public static class HouseDtoOdataExtensions
    {
        public static ODataModelBuilder ConfigureHouseDto(this ODataModelBuilder oDataModelBuilder)
        {
            //example registering custom dto in Odata
            oDataModelBuilder.EntitySet<HouseDto>("Houses");
            oDataModelBuilder.EntityType<HouseDto>().HasKey(e => new { e.Id });

            return oDataModelBuilder;
        }
    }
}
