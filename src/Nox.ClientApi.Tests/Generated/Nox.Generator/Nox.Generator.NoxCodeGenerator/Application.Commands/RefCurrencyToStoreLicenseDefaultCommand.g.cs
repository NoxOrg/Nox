
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

public abstract record RefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseDefaultCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCurrencyToStoreLicenseDefaultCommandHandler
	: RefCurrencyToStoreLicenseDefaultCommandHandlerBase<CreateRefCurrencyToStoreLicenseDefaultCommand>
{
	public CreateRefCurrencyToStoreLicenseDefaultCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseDefaultCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCurrencyToStoreLicenseDefaultCommandHandler
	: RefCurrencyToStoreLicenseDefaultCommandHandlerBase<DeleteRefCurrencyToStoreLicenseDefaultCommand>
{
	public DeleteRefCurrencyToStoreLicenseDefaultCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToStoreLicenseDefaultCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCurrencyToStoreLicenseDefaultCommandHandler
	: RefCurrencyToStoreLicenseDefaultCommandHandlerBase<DeleteAllRefCurrencyToStoreLicenseDefaultCommand>
{
	public DeleteAllRefCurrencyToStoreLicenseDefaultCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCurrencyToStoreLicenseDefaultCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToStoreLicenseDefaultCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCurrencyToStoreLicenseDefaultCommandHandlerBase(
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
				entity.CreateRefToStoreLicenseDefault(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToStoreLicenseDefault(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.StoreLicenseDefault).LoadAsync();
				entity.DeleteAllRefToStoreLicenseDefault();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}