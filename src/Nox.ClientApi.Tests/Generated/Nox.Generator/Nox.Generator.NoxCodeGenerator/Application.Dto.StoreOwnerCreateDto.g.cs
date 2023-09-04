// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerCreateDto : StoreOwnerUpdateDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

    public StoreOwner ToEntity()
    {
        var entity = new StoreOwner();
        entity.Id = StoreOwner.CreateId(Id);
        entity.Name = StoreOwner.CreateName(Name);
        if (VatNumber is not null)entity.VatNumber = StoreOwner.CreateVatNumber(VatNumber.NonNullValue<VatNumberDto>());
        //entity.Stores = Stores.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}