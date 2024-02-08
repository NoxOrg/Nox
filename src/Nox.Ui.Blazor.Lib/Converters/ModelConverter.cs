using AutoMapper;
using Nox.Ui.Blazor.Lib.Contracts;

namespace Nox.Ui.Blazor.Lib.Converters;

public class ModelConverter<TEntityModel, TEntityDto> : IModelConverter<TEntityModel, TEntityDto> where TEntityModel : IEntityModel
{
    private readonly IMapper _mapper;

    public ModelConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TEntityDto ConvertToDto(TEntityModel entityModel)
    {
        return _mapper.Map<TEntityDto>(entityModel);
    }

    public TEntityModel ConvertToModel(TEntityDto entityDto)
    {
        return _mapper.Map<TEntityModel>(entityDto);
    }
}
