
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

public abstract record RefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToDefaultCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreLicenseToDefaultCurrencyCommandHandler
	: RefStoreLicenseToDefaultCurrencyCommandHandlerBase<CreateRefStoreLicenseToDefaultCurrencyCommand>
{
	public CreateRefStoreLicenseToDefaultCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToDefaultCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreLicenseToDefaultCurrencyCommandHandler
	: RefStoreLicenseToDefaultCurrencyCommandHandlerBase<DeleteRefStoreLicenseToDefaultCurrencyCommand>
{
	public DeleteRefStoreLicenseToDefaultCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto)
	: RefStoreLicenseToDefaultCurrencyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreLicenseToDefaultCurrencyCommandHandler
	: RefStoreLicenseToDefaultCurrencyCommandHandlerBase<DeleteAllRefStoreLicenseToDefaultCurrencyCommand>
{
	public DeleteAllRefStoreLicenseToDefaultCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreLicenseToDefaultCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToDefaultCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreLicenseToDefaultCurrencyCommandHandlerBase(
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
				entity.CreateRefToDefaultCurrency(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToDefaultCurrency(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToDefaultCurrency();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}