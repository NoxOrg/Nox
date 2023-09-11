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

namespace ClientApi.Application.Commands;
public record UpdateCountryLocalNameCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto, CountryLocalNameUpdateDto EntityDto) : IRequest <CountryLocalNameKeyDto?>;

public partial class UpdateCountryLocalNameCommandHandler: CommandBase<UpdateCountryLocalNameCommand, CountryLocalName>, IRequestHandler <UpdateCountryLocalNameCommand, CountryLocalNameKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<CountryLocalName> EntityMapper { get; }

	public UpdateCountryLocalNameCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryLocalName> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryLocalNameKeyDto?> Handle(UpdateCountryLocalNameCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,AutoNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<CountryLocalName,AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryLocalName>(), request.EntityDto);
		
		OnCompleted(request, entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}