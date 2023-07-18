using Microsoft.CodeAnalysis;
using Nox.Types;
using System;
using System.Linq;
using System.Reflection;

namespace Nox.Generator
{
    static internal class NoxTypesToODataHelper
    {
        /// <summary>
        /// Preferred Dynamic implementation - currently loading Nox.Types assembly randomly fails, need to be investigated.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static (string FieldName, string Type)[] GetTypeDynamic(NoxType type)
        {
            // Assume objects and collections are represented as strings - TBD
            if (type == NoxType.Object || type == NoxType.Collection || type == NoxType.Array)
            {
                return new[] { (string.Empty, "string") };
            }

            var typeName = type.ToString(); // Assume that Enum member name can be used as type name
            var typeImplementation = Type.GetType($"Nox.Types.{typeName}, Nox.Types");

            // Check compound attribute
            var compoundType = typeof(NoxType)
                .GetField(typeName)
                .GetCustomAttribute<CompoundTypeAttribute>(false);

            if (typeImplementation != null)
            {
                if (compoundType != null)
                {
                    // Return all compound properties
                    return typeImplementation
                        .GetProperties()
                        .Where(p => p.Name != "Value")
                        .Select(p => (p.Name, p.PropertyType.ToString()))
                        .ToArray();
                }
                else
                {
                    // Try to create an instance and retrieve the underlying type
                    if (Activator.CreateInstance(typeImplementation) is INoxType instance)
                    {
                        return new[] { (string.Empty, instance.GetUnderlyingType().ToString()) };
                    }
                }
            }

            // Use string by default
            return new[] { (string.Empty, "string") };
        }

        internal static (string FieldName, string Type)[] GetType(NoxType type)
        {
            return type switch
            {
                NoxType.Text => GetSimpleTypeUnderlyingType(new Text()),
                NoxType.Number => GetSimpleTypeUnderlyingType(new Number()),
                NoxType.Date => GetSimpleTypeUnderlyingType(new Date()),


                NoxType.Money => GetMoneyDefinition(),
                NoxType.LatLong => GetLatLongDefinition(),
                NoxType.VatNumber => GetVatNumberDefinition(),
                NoxType.StreetAddress => GetStreetAddressDefinition(),

                _ => new[] { (string.Empty, "string") },
            };
        }

        private static (string FieldName, string Type)[] GetStreetAddressDefinition()
        {
            var streetAddress = new StreetAddress();
            return new[] {
            (nameof(streetAddress.AddressLine1), streetAddress.AddressLine1.GetType().ToString()),
            (nameof(streetAddress.AddressLine2), streetAddress.AddressLine2.GetType().ToString()),
            (nameof(streetAddress.AdministrativeArea1), streetAddress.AdministrativeArea1.GetType().ToString()),
            (nameof(streetAddress.AdministrativeArea2), streetAddress.AdministrativeArea2.GetType().ToString()),
            (nameof(streetAddress.Locality), streetAddress.Locality.GetType().ToString()),
            (nameof(streetAddress.StreetNumber), streetAddress.StreetNumber.GetType().ToString()),
            (nameof(streetAddress.Route), streetAddress.Route.GetType().ToString()),
            (nameof(streetAddress.Neighborhood), streetAddress.Neighborhood.GetType().ToString()),
        };
        }

        private static (string FieldName, string Type)[] GetVatNumberDefinition()
        {
            var vatNumber = new VatNumber();
            return new[] {
            (nameof(vatNumber.Value.VatNumber), vatNumber.Value.VatNumber.GetType().ToString()),
            (nameof(vatNumber.Value.countryCode2), vatNumber.Value.countryCode2.GetUnderlyingType().ToString())
        };
        }

        private static (string Empty, string)[] GetSimpleTypeUnderlyingType(INoxType instance)
        {
            return new[] { (string.Empty, instance.GetUnderlyingType().ToString()) };
        }

        private static (string FieldName, string Type)[] GetLatLongDefinition()
        {
            var latLong = new LatLong();
            return new[] {
            (nameof(latLong.Longitude), latLong.Longitude.GetType().ToString()),
            (nameof(latLong.Latitude), latLong.Latitude.GetType().ToString())
        };
        }

        private static (string FieldName, string Type)[] GetMoneyDefinition()
        {
            var money = new Money();
            return new[] {
            (nameof(money.Amount), money.Amount.GetType().ToString()),
            (nameof(money.CurrencyCode), money.CurrencyCode.GetType().ToString())
        };
        }
    }
}
