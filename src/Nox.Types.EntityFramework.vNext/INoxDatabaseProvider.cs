using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;


namespace Nox.Types.EntityFramework.vNext
{
    public interface INoxDatabaseProvider
    {
        void ConfigureEntity(EntityTypeBuilder builder, Entity entity);
    }
}