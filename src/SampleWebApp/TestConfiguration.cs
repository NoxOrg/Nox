using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Sqlite.ToMoveEF;
using System.Diagnostics.Metrics;
using SampleWebApp.Domain;
using Nox.Types.EntityFramework.Sqlite;


/// <summary>
/// Ignore just for testing purposes...
/// </summary>
public partial class TestConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {

        //builder.HasKey(e => e.Id);

        //builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CountryId.From(v));

        SqliteDatabaseConfiguration _databaseConfiguration = new SqliteDatabaseConfiguration();
        var _noxSolution = new NoxSolution();

        _databaseConfiguration.ConfigureEntityProperty(_noxSolution, "Name", builder,e => e.Name);
        _databaseConfiguration.ConfigureEntityProperty(_noxSolution, "AreaInSquareKilometres", builder, e => e.AreaInSquareKilometres);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.FormalName);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.AlphaCode3);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.AlphaCode2);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.NumericCode);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.DialingCodes);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.Capital);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.Demonym);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.AreaInSquareKilometres);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.GeoCoord);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.GeoRegion);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.GeoSubRegion);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.GeoWorldRegion);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.Population);

        //_databaseConfiguration.ConfigureEntityProperty(_noxSolution, builder, e => e.TopLevelDomains);

        //builder.HasMany(x => x.Currencies).WithMany();
    }
}