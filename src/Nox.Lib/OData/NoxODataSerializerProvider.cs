﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;

namespace Nox.Lib;

public class NoxODataSerializerProvider : ODataSerializerProvider
{
    public NoxODataSerializerProvider(IServiceProvider sp) : base(sp)
    {
    }

    public override IODataSerializer GetODataPayloadSerializer(Type type, HttpRequest request)
    {
        if (type == typeof(ODataError) || type == typeof(SerializableError))
        {
            return new NoxODataErrorSerializer();
        }

        return base.GetODataPayloadSerializer(type, request);
    }
}