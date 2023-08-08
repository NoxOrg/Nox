using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public override File? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return File.From((value.Url, value.PrettyName, value.SizeInBytes), simpleTypeDefinition.FileTypeOptions ?? new FileTypeOptions());
        }
    }
}