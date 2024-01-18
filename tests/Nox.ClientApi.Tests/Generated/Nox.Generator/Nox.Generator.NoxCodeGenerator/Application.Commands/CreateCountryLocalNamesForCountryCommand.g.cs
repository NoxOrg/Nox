﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public partial record CreateCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto>;

internal partial class CreateCountryLocalNamesForCountryCommandHandler : CreateCountryLocalNamesForCountryCommandHandlerBase
{
	public CreateCountryLocalNamesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateCountryLocalNamesForCountryCommandHandlerBase : CommandBase<CreateCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler<CreateCountryLocalNamesForCountryCommand, CountryLocalNameKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> _entityFactory;
	
	protected CreateCountryLocalNamesForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<CountryLocalNameKeyDto?> Handle(CreateCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToCountryLocalNames(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}

public class CreateCountryLocalNamesForCountryValidator : AbstractValidator<CreateCountryLocalNamesForCountryCommand>
{
    public CreateCountryLocalNamesForCountryValidator()
    {
		RuleFor(x => x.EntityDto.Id).Null().WithMessage("Id must be null as it is auto generated.");
    }
}