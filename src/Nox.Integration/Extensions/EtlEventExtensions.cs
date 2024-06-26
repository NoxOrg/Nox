using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Exceptions;
using Nox.Integration.Helpers;

namespace Nox.Integration.Extensions;

public static class EtlEventExtensions
{
    public static IEtlEventDto ResolvePayload<TRecord>(this TRecord record, IEtlEvent<IEtlEventDto> @event)
    {
        var payloadType = @event.Dto!.GetType();
        var payload = Activator.CreateInstance(payloadType);
        var recordProperties = typeof(TRecord).GetProperties();
        
        foreach (var prop in payloadType.GetProperties())
        {
            var sourceVal = ObjectHelpers.GetPropertyValue(record, prop.Name, recordProperties);
            if (sourceVal != null)
            {
                try
                {
                    prop.SetValue(payload, sourceVal);
                }
                catch (ArgumentException)
                {
                    if (!TryChangeType(sourceVal, prop.PropertyType, out var result))
                    {
                        throw new NoxIntegrationTypeConversionException($"Unable to convert source type ({sourceVal.GetType().Name}) to target type ({prop.PropertyType.Name}).");
                    }

                    prop.SetValue(payload, result);
                }
                catch
                {
                    throw new NoxIntegrationTypeConversionException($"Unable to convert source type ({sourceVal.GetType().Name}) to target type ({prop.PropertyType.Name}).");
                }
            }
        }
        return (IEtlEventDto)payload!;
    }

    private static bool TryChangeType(object sourceValue, Type type, out object outValue)
    {
        try
        {
            if (sourceValue.GetType().Name == "DateTime" && type.Name == "DateTimeOffset")
            {
                outValue = new DateTimeOffset((DateTime)sourceValue);
            }
            else
            {
                outValue = Convert.ChangeType(sourceValue, type);    
            }
            return true; 
        }
        catch
        {
            //Ignore error
        }

        outValue = default!;

        return false;
    }

    
}