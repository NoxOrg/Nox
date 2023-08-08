using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeTranslatedTextFactory : NoxTypeFactoryBase<TranslatedText>
    {
        public NoxTypeTranslatedTextFactory(NoxSolution solution) : base(solution)
        {
        }

        public override TranslatedText? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return TranslatedText.From((CultureCode.From(value.CultureCode), value.Phrase), simpleTypeDefinition.TranslatedTextTypeOptions ?? new TranslatedTextTypeOptions());
        }
    }
}