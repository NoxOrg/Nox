using System;
using Nox.Solution.Exceptions;

namespace Nox.Solution.Builders;

public class NoxUriBuilder
{
    private readonly UriBuilder _builder;

    public Uri Uri => _builder.Uri;

    public string Scheme
    {
        get => _builder.Scheme;
        set => _builder.Scheme = value;
    }

    public string Host
    {
        get => _builder.Host;
        set => _builder.Host = value;
    }

    public int Port
    {
        get => _builder.Port;
        set => _builder.Port = value;
    }

    public string UserName
    {
        get => _builder.UserName;
        set => _builder.UserName = value;
    }

    public string Password
    {
        get => _builder.Password;
        set => _builder.Password = value;
    }

    public string Path
    {
        get => _builder.Path;
        set => _builder.Path = value;
    }

    public NoxUriBuilder(ServerBase serverBase, string scheme, string description)
    {
        _builder = new UriBuilder();
        var uriString = serverBase.ServerUri;

        var isValid = Uri.TryCreate(uriString, UriKind.Absolute, out Uri? uri);
        
        if (isValid && uri is not null) //contains at least a scheme and a host
        {
            if (!uri.Scheme.Equals(scheme, StringComparison.OrdinalIgnoreCase)) 
                throw new NoxUriBuilderException($"The server definition for {description} has an invalid serverUri scheme, should be {scheme}. Unable to build a proper uri from the available attributes.");
            _builder.Scheme = uri.Scheme;
            _builder.Host = uri.Host;
            _builder.Port = uri.Port;
        }
        else //assume that only a host name or ip address was supplied
        {
            _builder.Scheme = scheme;
            _builder.Host = serverBase.ServerUri;
            _builder.Port = serverBase.Port!.Value;
            if (!string.IsNullOrWhiteSpace(serverBase.User)) _builder.UserName = serverBase.User!;
            if (!string.IsNullOrWhiteSpace(serverBase.Password)) _builder.Password = serverBase.Password!;
            if (!string.IsNullOrWhiteSpace(serverBase.Options)) _builder.Path = serverBase.Options!;
        }

        
    }
}