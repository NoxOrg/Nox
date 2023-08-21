﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;

public record UpdateCountryLocalNamesCommand(System.String keyId, CountryLocalNamesUpdateDto EntityDto) : IRequest<CountryLocalNamesKeyDto?>;

public class UpdateCountryLocalNamesCommandHandler: CommandBase, IRequestHandler<UpdateCountryLocalNamesCommand, CountryLocalNamesKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public SampleWebAppDbContext DbContext { get; }    
	public IEntityMapper<CountryLocalNames> EntityMapper { get; }

	public  UpdateCountryLocalNamesCommandHandler(
		SampleWebAppDbContext dbContext,        
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryLocalNames> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;        
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}
	
	public async Task<CountryLocalNamesKeyDto?> Handle(UpdateCountryLocalNamesCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<CountryLocalNames,Text>("Id", request.keyId);
	
		var entity = await DbContext.CountryLocalNames.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryLocalNames>(), request.EntityDto);        
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new CountryLocalNamesKeyDto(entity.Id.Value);
	}
}