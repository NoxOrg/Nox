using System;
using System.IO;
using Nox.Solution.Exceptions;

namespace Nox.Solution.Builders;

public class NoxUriBuilder
{
    public Uri Uri { get; }

    public NoxUriBuilder(ServerBase serverBase, string scheme, string description)
    {
        var uriString = serverBase.ServerUri;
        Uri? uri = null;
        var isValid = Uri.TryCreate(uriString, UriKind.Absolute, out uri);
        if (isValid) //contains at least a scheme and a host
        {
            if (!uri!.Scheme.Equals(scheme, StringComparison.OrdinalIgnoreCase)) throw new NoxUriBuilderException(string.Format(ValidationResources.ServerUriInvalidScheme, description, scheme));
            Uri = uri;
        }
        else //assume that only a host name or ip address was supplied or it is a relative folder path
        {
            UriBuilder builder;

            if (serverBase.ServerUri.StartsWith(".")) //relative file location, create a proper file uri using absolute path
            {
                var absolutePath = Path.GetFullPath(serverBase.ServerUri);
                builder = new UriBuilder("file", absolutePath);
            }
            else
            {

                if (serverBase.Port.HasValue)
                {
                    builder = new UriBuilder(scheme, serverBase.ServerUri, serverBase.Port!.Value);
                }
                else
                {
                    builder = new UriBuilder(scheme, serverBase.ServerUri);
                }

                if (!string.IsNullOrWhiteSpace(serverBase.User)) builder.UserName = serverBase.User;
                if (!string.IsNullOrWhiteSpace(serverBase.Password)) builder.Password = serverBase.Password;
                if (!string.IsNullOrWhiteSpace(serverBase.Options)) builder.Path = serverBase.Options;
            }

            Uri = builder.Uri;
        }

        
    }
}