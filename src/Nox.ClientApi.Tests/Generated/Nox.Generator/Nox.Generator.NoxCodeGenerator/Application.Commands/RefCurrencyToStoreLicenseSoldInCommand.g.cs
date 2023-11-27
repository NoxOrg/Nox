
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

public abstract record RefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto);

internal partial class CreateRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<CreateRefCurrencyToStoreLicenseSoldInCommand>
{
	public CreateRefCurrencyToStoreLicenseSoldInCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCurrencyToStoreLicenseSoldInCommand request)
    {
		var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetStoreLicense(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToStoreLicenseSoldIn(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, List<StoreLicenseKeyDto> RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto);

internal partial class UpdateRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<UpdateRefCurrencyToStoreLicenseSoldInCommand>
{
	public UpdateRefCurrencyToStoreLicenseSoldInCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCurrencyToStoreLicenseSoldInCommand request)
    {
		var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<ClientApi.Domain.StoreLicense>();
		foreach(var keyDto in request.RelatedEntityKeyDto)
		{
			var relatedEntity = await GetStoreLicense(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.StoreLicenseSoldIn).LoadAsync();
		entity.UpdateRefToStoreLicenseSoldIn(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto);

internal partial class DeleteRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<DeleteRefCurrencyToStoreLicenseSoldInCommand>
{
	public DeleteRefCurrencyToStoreLicenseSoldInCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCurrencyToStoreLicenseSoldInCommand request)
    {
        var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetStoreLicense(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToStoreLicenseSoldIn(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto);

internal partial class DeleteAllRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<DeleteAllRefCurrencyToStoreLicenseSoldInCommand>
{
	public DeleteAllRefCurrencyToStoreLicenseSoldInCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCurrencyToStoreLicenseSoldInCommand request)
    {
        var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.StoreLicenseSoldIn).LoadAsync();
		entity.DeleteAllRefToStoreLicenseSoldIn();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToStoreLicenseSoldInCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToStoreLicenseSoldInCommand
{
	public AppDbContext DbContext { get; }

	public RefCurrencyToStoreLicenseSoldInCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<CurrencyEntity?> GetCurrency(CurrencyKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.CurrencyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Currencies.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.StoreLicense?> GetStoreLicense(StoreLicenseKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.StoreLicenses.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CurrencyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}