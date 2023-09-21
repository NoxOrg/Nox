﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Country = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public record UpdateCountryCommand(System.Int64 keyId, CountryUpdateDto EntityDto, System.Guid? Etag) : IRequest<CountryKeyDto?>;

public partial class UpdateCountryCommandHandler: UpdateCountryCommandHandlerBase
{
	public UpdateCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

public abstract class UpdateCountryCommandHandlerBase: CommandBase<UpdateCountryCommand, Country>, IRequestHandler<UpdateCountryCommand, CountryKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> _entityFactory;

	public UpdateCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryKeyDto?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryKeyDto(entity.Id.Value);
	}
}