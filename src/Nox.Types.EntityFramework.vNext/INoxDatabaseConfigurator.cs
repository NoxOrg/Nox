using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;


namespace Nox.Types.EntityFramework.vNext
{
    public interface INoxDatabaseConfigurator
    {
        void ConfigureEntity(EntityTypeBuilder builder, Entity entity);
    }
}