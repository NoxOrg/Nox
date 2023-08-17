using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeMarkdownFactory : NoxTypeFactoryBase<Markdown>
    {
        public NoxTypeMarkdownFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Markdown? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            
            return Markdown.From(value, simpleTypeDefinition.MarkdownTypeOptions ?? new MarkdownTypeOptions());
        }
    }
}
