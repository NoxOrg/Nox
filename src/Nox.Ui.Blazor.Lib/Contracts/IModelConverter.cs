namespace Nox.Ui.Blazor.Lib.Contracts;

public interface IModelConverter<TEntityModel, TEntityDto> where TEntityModel : IEntityModel
{
    public TEntityDto ConvertToDto(TEntityModel entityModel);

    public TEntityModel ConvertToModel(TEntityDto entityDto);
}
