﻿using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[AdditionalProperties(false)]
public class ServerBase
{
    [Required]
    [Pattern(@"^[^\s]*$")]
    [Title("The unique name of this server component in the solution.")]
    [Description("The name of this server component in the solution. The name must be unique in the solution configuration")]
    public string Name { get; internal set; } = null!;

    [Required]
    [Title("Hostname, IP address or URI.")]
    [Description("The name, address, URI or IP of the server to connect to.")]
    [AllowVariable]
    public string ServerUri { get; internal set; } = null!;

    [Title("Server port")]
    [Description("The port to connect to.")]
    [AllowVariable]
    public int? Port { get; internal set; }

    [Title("Username.")]
    [Description("The username to use when connecting to this server.")]
    [AllowVariable]
    public string? User { get; internal set; }

    [Title("Password.")]
    [Description("The password to use when connecting to this server.")]
    [AllowVariable]
    public string? Password { get; internal set; }

    [Title("Additional options.")]
    [Description("A list of additional options to set when connecting to this server.")]
    [AllowVariable]
    public string? Options { get; internal set; }
}