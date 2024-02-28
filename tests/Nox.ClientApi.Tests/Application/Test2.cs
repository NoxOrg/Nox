// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands2;

public partial record UpdateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, CountryBarCodeUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryBarCodeKeyDto>;

internal partial class UpdateCountryBarCodeForCountryCommandHandler : UpdateCountryBarCodeForCountryCommandHandlerBase
{
    public UpdateCountryBarCodeForCountryCommandHandler(
        IRepository repository,
        NoxSolution noxSolution,
        IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> entityFactory)
        : base(repository, noxSolution, entityFactory)
    {
    }
}

internal partial class UpdateCountryBarCodeForCountryCommandHandlerBase : CommandBase<UpdateCountryBarCodeForCountryCommand, CountryBarCodeEntity>, IRequestHandler<UpdateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto>
{
    private readonly IRepository _repository;
    private readonly IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> _entityFactory;

    protected UpdateCountryBarCodeForCountryCommandHandlerBase(
        IRepository repository,
        NoxSolution noxSolution,
        IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> entityFactory)
        : base(noxSolution)
    {
        _repository = repository;
        _entityFactory = entityFactory;
    }

    public virtual async Task<CountryBarCodeKeyDto> Handle(UpdateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(request);

        var keys = new List<object?>(1);
        keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

        var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(), e => e.CountryBarCode, cancellationToken);
        EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "keyId");
        var entity = parentEntity.CountryBarCode;
        if (entity is null)
            entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
        else
            await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

        parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
        _repository.Update(parentEntity);
        await OnCompletedAsync(request, entity!);
        await _repository.SaveChangesAsync();

        return new CountryBarCodeKeyDto();
    }

    private async Task<CountryBarCodeEntity> CreateEntityAsync(CountryBarCodeUpsertDto upsertDto, CountryEntity parent, Nox.Types.CultureCode cultureCode)
    {
        var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
        parent.CreateRefToCountryBarCode(entity);
        return entity;
    }
}