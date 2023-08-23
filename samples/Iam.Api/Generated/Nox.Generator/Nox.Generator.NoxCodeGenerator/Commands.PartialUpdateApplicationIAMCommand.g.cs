﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record PartialUpdateApplicationIAMCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <ApplicationIAMKeyDto?>;

public class PartialUpdateApplicationIAMCommandHandler: CommandBase<PartialUpdateApplicationIAMCommand>, IRequestHandler<PartialUpdateApplicationIAMCommand, ApplicationIAMKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }
	public IEntityMapper<ApplicationIAM> EntityMapper { get; }

	public PartialUpdateApplicationIAMCommandHandler(
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

	public async Task<ApplicationIAMKeyDto?> Handle(PartialUpdateApplicationIAMCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<ApplicationIAM,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ApplicationIAMs.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ApplicationIAM>(), request.UpdatedProperties);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ApplicationIAMKeyDto(entity.Id.Value);
	}
}