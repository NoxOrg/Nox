﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record UpdateApplicationIAMCommand(System.Int64 keyId, ApplicationIAMUpdateDto EntityDto) : IRequest<ApplicationIAMKeyDto?>;

public class UpdateApplicationIAMCommandHandler: CommandBase<UpdateApplicationIAMCommand>, IRequestHandler<UpdateApplicationIAMCommand, ApplicationIAMKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }
	public IEntityMapper<ApplicationIAM> EntityMapper { get; }

	public UpdateApplicationIAMCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ApplicationIAM> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}
	
	public async Task<ApplicationIAMKeyDto?> Handle(UpdateApplicationIAMCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<ApplicationIAM,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.ApplicationIAMs.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<ApplicationIAM>(), request.EntityDto);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new ApplicationIAMKeyDto(entity.Id.Value);
	}
}