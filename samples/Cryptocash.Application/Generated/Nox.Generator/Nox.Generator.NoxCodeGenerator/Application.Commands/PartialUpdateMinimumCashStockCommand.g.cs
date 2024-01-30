// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateMinimumCashStockCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <MinimumCashStockKeyDto>;

internal partial class PartialUpdateMinimumCashStockCommandHandler : PartialUpdateMinimumCashStockCommandHandlerBase
{
	public PartialUpdateMinimumCashStockCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateMinimumCashStockCommandHandlerBase : CommandBase<PartialUpdateMinimumCashStockCommand, MinimumCashStockEntity>, IRequestHandler<PartialUpdateMinimumCashStockCommand, MinimumCashStockKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> EntityFactory { get; }
	
	public PartialUpdateMinimumCashStockCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<MinimumCashStockKeyDto> Handle(PartialUpdateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.MinimumCashStockMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<MinimumCashStock>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entity.Id.Value);
	}
}