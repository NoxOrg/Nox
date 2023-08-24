﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record PartialUpdateApplicationIAMCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <ApplicationIAMKeyDto?>;

public class PartialUpdateApplicationIAMCommandHandler: CommandBase<PartialUpdateApplicationIAMCommand, ApplicationIAM>, IRequestHandler<PartialUpdateApplicationIAMCommand, ApplicationIAMKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<ApplicationIAM> EntityMapper { get; }

	public PartialUpdateApplicationIAMCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ApplicationIAM> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<ApplicationIAMKeyDto?> Handle(PartialUpdateApplicationIAMCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<ApplicationIAM,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ApplicationIAMs.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ApplicationIAM>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ApplicationIAMKeyDto(entity.Id.Value);
	}
}