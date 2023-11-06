
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public abstract record RefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToSoldInCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreLicenseToSoldInCurrencyCommandHandler
	: RefStoreLicenseToSoldInCurrencyCommandHandlerBase<CreateRefStoreLicenseToSoldInCurrencyCommand>
{
	public CreateRefStoreLicenseToSoldInCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToSoldInCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreLicenseToSoldInCurrencyCommandHandler
	: RefStoreLicenseToSoldInCurrencyCommandHandlerBase<DeleteRefStoreLicenseToSoldInCurrencyCommand>
{
	public DeleteRefStoreLicenseToSoldInCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto)
	: RefStoreLicenseToSoldInCurrencyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreLicenseToSoldInCurrencyCommandHandler
	: RefStoreLicenseToSoldInCurrencyCommandHandlerBase<DeleteAllRefStoreLicenseToSoldInCurrencyCommand>
{
	public DeleteAllRefStoreLicenseToSoldInCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreLicenseToSoldInCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToSoldInCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreLicenseToSoldInCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.StoreLicenses.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.Currency? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.CurrencyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Currencies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToSoldInCurrency(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSoldInCurrency(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToSoldInCurrency();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}