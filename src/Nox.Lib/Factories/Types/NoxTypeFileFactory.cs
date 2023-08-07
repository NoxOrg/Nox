using Nox.Solution;
using Nox.Types;
using File = Nox.Types.File;

namespace Nox.Factories.Types
{
    public class NoxTypeFileFactory : NoxTypeFactoryBase<File>
    {
        public NoxTypeFileFactory(NoxSolution solution) : base(solution)
        {
        }

        public override File? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return File.From((value.Url, value.PrettyName, value.SizeInBytes) , attributeDefinition.FileTypeOptions ?? new FileTypeOptions());
        }
    }
}