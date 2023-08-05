using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeStreetAddressFactory : NoxTypeFactoryBase<StreetAddress>
    {
        public NoxTypeStreetAddressFactory(NoxSolution solution) : base(solution)
        {
        }

        public override StreetAddress? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return StreetAddress.From(new StreetAddressItem()
            {
                StreetNumber = value.StreetNumber,
                AddressLine1 = value.AddressLine1,
                AddressLine2 = value.AddressLine2,
                Route = value.Route,
                Locality = value.Locality,
                Neighborhood = value.Neighborhood,
                AdministrativeArea1 = value.AdministrativeArea1,
                AdministrativeArea2 = value.AdministrativeArea2,
                PostalCode = value.PostalCode,
                CountryId = value.CountryId
            });
        }
    }
}