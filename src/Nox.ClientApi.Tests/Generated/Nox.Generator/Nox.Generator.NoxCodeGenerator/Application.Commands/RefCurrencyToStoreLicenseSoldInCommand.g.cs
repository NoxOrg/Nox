
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
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Commands;

public abstract record RefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<CreateRefCurrencyToStoreLicenseSoldInCommand>
{
	public CreateRefCurrencyToStoreLicenseSoldInCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<DeleteRefCurrencyToStoreLicenseSoldInCommand>
{
	public DeleteRefCurrencyToStoreLicenseSoldInCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<DeleteAllRefCurrencyToStoreLicenseSoldInCommand>
{
	public DeleteAllRefCurrencyToStoreLicenseSoldInCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCurrencyToStoreLicenseSoldInCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToStoreLicenseSoldInCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCurrencyToStoreLicenseSoldInCommandHandlerBase(
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
		var keyId = ClientApi.Domain.CurrencyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.StoreLicense? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToStoreLicenseSoldIn(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToStoreLicenseSoldIn(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.StoreLicenseSoldIn).LoadAsync();
				entity.DeleteAllRefToStoreLicenseSoldIn();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}