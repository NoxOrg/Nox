using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeTranslatedTextFactory : NoxTypeFactoryBase<TranslatedText>
    {
        public NoxTypeTranslatedTextFactory(NoxSolution solution) : base(solution)
        {
        }

        public override TranslatedText? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return TranslatedText.From((CultureCode.From(value.CultureCode), value.Phrase), attributeDefinition.TranslatedTextTypeOptions ?? new TranslatedTextTypeOptions());
        }
    }
}