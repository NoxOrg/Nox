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
using Commission = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public record UpdateCommissionCommand(System.Int64 keyId, CommissionUpdateDto EntityDto, System.Guid? Etag) : IRequest<CommissionKeyDto?>;

internal partial class UpdateCommissionCommandHandler: UpdateCommissionCommandHandlerBase
{
	public UpdateCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

internal abstract class UpdateCommissionCommandHandlerBase: CommandBase<UpdateCommissionCommand, Commission>, IRequestHandler<UpdateCommissionCommand, CommissionKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> _entityFactory;

	public UpdateCommissionCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Commission, CommissionCreateDto, CommissionUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CommissionKeyDto?> Handle(UpdateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Commission,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Commissions.FindAsync(keyId);
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

		return new CommissionKeyDto(entity.Id.Value);
	}
}