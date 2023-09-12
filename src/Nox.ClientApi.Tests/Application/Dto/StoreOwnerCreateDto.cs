using Nox.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Extensions;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;

/// <summary>
/// 
/// </summary>
public partial class StoreOwnerCreateDto
{
   // public override string TemporaryOwnerName { get; set; } = String.Empty;
}