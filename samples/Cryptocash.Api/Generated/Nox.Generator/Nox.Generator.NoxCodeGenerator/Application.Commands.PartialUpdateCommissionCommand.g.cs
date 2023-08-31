﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;
using Commission = CryptocashApi.Domain.Commission;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCommissionCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CommissionKeyDto?>;

public class PartialUpdateCommissionCommandHandler: CommandBase<PartialUpdateCommissionCommand, Commission>, IRequestHandler<PartialUpdateCommissionCommand, CommissionKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<Commission> EntityMapper { get; }

	public PartialUpdateCommissionCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Commission> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CommissionKeyDto?> Handle(PartialUpdateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Commission,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Commission>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CommissionKeyDto(entity.Id.Value);
	}
}