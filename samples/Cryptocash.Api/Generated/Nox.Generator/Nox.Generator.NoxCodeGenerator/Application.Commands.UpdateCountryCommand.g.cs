﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Country = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record UpdateCountryCommand(System.String keyId, CountryUpdateDto EntityDto, System.Guid? Etag) : IRequest<CountryKeyDto?>;

public partial class UpdateCountryCommandHandler: UpdateCountryCommandHandlerBase
{
	public UpdateCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Country> entityMapper): base(dbContext, noxSolution, serviceProvider, entityMapper)
	{
	}
}
public abstract class UpdateCountryCommandHandlerBase: CommandBase<UpdateCountryCommand, Country>, IRequestHandler<UpdateCountryCommand, CountryKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Country> EntityMapper { get; }

	public UpdateCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Country> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public virtual async Task<CountryKeyDto?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.CountryCode2>("Id", request.keyId);
	
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Country>(), request.EntityDto);
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