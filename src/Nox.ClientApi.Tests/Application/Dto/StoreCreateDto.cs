using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto;

/// <summary>
/// Example how to add additional properties to Create Dto used in Post OData End points
/// this applies in similar way UpdateDto
/// <seealso cref="CreateStoreCommandHandler"/> how to use the additional properties
/// </summary>
public partial class StoreCreateDto
{
    [Required(ErrorMessage = "Define if the owner is temporary or not")]
    public bool IsTemporary { get; set; }
}