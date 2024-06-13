using System;
using System.Data;

namespace Nox.Generator.Application.Integration.MappingHelpers;

public static class MappingTypeExtensions
{
    public static (MappingDataType type, string typeName, string defaultValue) ToTransformDataType(this Type primitive, bool isNullable)
    {
        switch (primitive.Name.ToLower())
        {
            case "boolean":
                return isNullable ? (MappingDataType.Boolean, "System.Boolean?", "") : (MappingDataType.Boolean, "System.Boolean", "");
            case "datetime":
                return isNullable ? (MappingDataType.DateTime, "System.DateTime?", "") : (MappingDataType.DateTime, "System.DateTime", "");
            case "dateonly":
                return isNullable ? (MappingDataType.DateOnly, "System.DateOnly?", "") : (MappingDataType.DateOnly, "System.DateOnly", "");
            case "datetimeoffset":
                return isNullable ? (MappingDataType.DateTimeOffset, "System.DateTimeOffset?", "") : (MappingDataType.DateTimeOffset, "System.DateTimeOffset", "");
            case "decimal":
                return isNullable ? (MappingDataType.Decimal, "System.Decimal?", "") : (MappingDataType.Decimal, "System.Decimal", "");
            case "double":
                return isNullable ? (MappingDataType.Double, "System.Double?", "") : (MappingDataType.Double, "System.Double", "");
            case "guid":
                return isNullable ? (MappingDataType.Guid, "System.Guid?", "") : (MappingDataType.Guid, "System.Guid", "");
            case "int16":
                return isNullable ? (MappingDataType.Int16, "System.Int16?", "") : (MappingDataType.Int16, "System.Int16", "");
            case "int32":
                return isNullable ? (MappingDataType.Int32, "System.Int32?", "") : (MappingDataType.Int32, "System.Int32", "");
            case "int64":
                return isNullable ? (MappingDataType.Int64, "System.Int64?", "") : (MappingDataType.Int64, "System.Int64", "");
            case "timeonly":
                return isNullable ? (MappingDataType.TimeOnly, "System.TimeOnly?", "") : (MappingDataType.TimeOnly, "System.TimeOnly", "");
            case "uint16":
                return isNullable ? (MappingDataType.UIn16, "System.UInt16?", "") : (MappingDataType.UIn16, "System.UInt16", "");
            case "uint32":
                return isNullable ? (MappingDataType.UInt32, "System.UInt32?", "") : (MappingDataType.UInt32, "System.UInt32", "");
            case "uint64":
                return isNullable ? (MappingDataType.UInt64, "System.UInt64?", "") : (MappingDataType.UInt64, "System.UInt64", "");
            default:
                return isNullable ? (MappingDataType.String, "System.String?", "") : (MappingDataType.String, "System.String", " = string.Empty;");
        }
    }

    public static (MappingDataType type, string typeName, string defaultValue) ToTransformDataType(this IntegrationMapDataType mapType, bool isNullable)
    {
        switch (mapType)
        {
            case IntegrationMapDataType.Boolean:
                return isNullable ? (MappingDataType.Boolean, "System.Boolean?", "") : (MappingDataType.Boolean, "System.Boolean", "");
            case IntegrationMapDataType.Date:
                return isNullable ? (MappingDataType.DateOnly, "System.DateOnly?", "") : (MappingDataType.DateOnly, "System.DateOnly", "");
            case IntegrationMapDataType.Decimal:
                return isNullable ? (MappingDataType.Double, "System.Double?", "") : (MappingDataType.Double, "System.Double", "");
            case IntegrationMapDataType.UniqueIdentifier:
                return isNullable ? (MappingDataType.Guid, "System.Guid?", "") : (MappingDataType.Guid, "System.Guid", "");
            case IntegrationMapDataType.Integer:
                return isNullable ? (MappingDataType.Int64, "System.Int64?", "") : (MappingDataType.Int64, "System.Int64", "");
            case IntegrationMapDataType.String:
                return isNullable ? (MappingDataType.String, "System.String?", "") : (MappingDataType.String, "System.String", " = string.Empty;");
            case IntegrationMapDataType.Time:
                return isNullable ? (MappingDataType.TimeOnly, "System.TimeOnly?", "") : (MappingDataType.TimeOnly, "System.TimeOnly", "");
            case IntegrationMapDataType.DateTime:
                return isNullable ? (MappingDataType.DateTime, "System.DateTime?", "") : (MappingDataType.DateTime, "System.DateTime", "");
            default:
                return isNullable ? (MappingDataType.String, "System.String?", "") : (MappingDataType.String, "System.String", " = string.Empty;");
        }
    }
}
