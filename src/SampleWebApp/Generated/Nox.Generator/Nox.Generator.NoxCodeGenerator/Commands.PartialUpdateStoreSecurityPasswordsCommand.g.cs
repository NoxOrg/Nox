﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateStoreSecurityPasswordsCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <StoreSecurityPasswordsKeyDto?>;

public class PartialUpdateStoreSecurityPasswordsCommandHandler: CommandBase<PartialUpdateStoreSecurityPasswordsCommand>, IRequestHandler<PartialUpdateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<StoreSecurityPasswords> EntityMapper { get; }

	public PartialUpdateStoreSecurityPasswordsCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<StoreSecurityPasswords> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<StoreSecurityPasswordsKeyDto?> Handle(PartialUpdateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);

		var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<StoreSecurityPasswords>(), request.UpdatedProperties);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreSecurityPasswordsKeyDto(entity.Id.Value);
	}
}