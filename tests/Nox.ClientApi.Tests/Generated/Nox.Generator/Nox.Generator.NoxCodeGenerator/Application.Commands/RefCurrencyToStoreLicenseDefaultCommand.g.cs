
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

public abstract record RefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseDefaultCommand(EntityKeyDto);

internal partial class CreateRefCurrencyToStoreLicenseDefaultCommandHandler
	: RefCurrencyToStoreLicenseDefaultCommandHandlerBase<CreateRefCurrencyToStoreLicenseDefaultCommand>
{
	public CreateRefCurrencyToStoreLicenseDefaultCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCurrencyToStoreLicenseDefaultCommand request)
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

		entity.CreateRefToStoreLicenseDefault(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto, List<StoreLicenseKeyDto> RelatedEntitiesKeysDtos)
	: RefCurrencyToStoreLicenseDefaultCommand(EntityKeyDto);

internal partial class UpdateRefCurrencyToStoreLicenseDefaultCommandHandler
	: RefCurrencyToStoreLicenseDefaultCommandHandlerBase<UpdateRefCurrencyToStoreLicenseDefaultCommand>
{
	public UpdateRefCurrencyToStoreLicenseDefaultCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCurrencyToStoreLicenseDefaultCommand request)
    {
		var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<ClientApi.Domain.StoreLicense>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStoreLicense(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.StoreLicenseDefault).LoadAsync();
		entity.UpdateRefToStoreLicenseDefault(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseDefaultCommand(EntityKeyDto);

internal partial class DeleteRefCurrencyToStoreLicenseDefaultCommandHandler
	: RefCurrencyToStoreLicenseDefaultCommandHandlerBase<DeleteRefCurrencyToStoreLicenseDefaultCommand>
{
	public DeleteRefCurrencyToStoreLicenseDefaultCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCurrencyToStoreLicenseDefaultCommand request)
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

		entity.DeleteRefToStoreLicenseDefault(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCurrencyToStoreLicenseDefaultCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToStoreLicenseDefaultCommand(EntityKeyDto);

internal partial class DeleteAllRefCurrencyToStoreLicenseDefaultCommandHandler
	: RefCurrencyToStoreLicenseDefaultCommandHandlerBase<DeleteAllRefCurrencyToStoreLicenseDefaultCommand>
{
	public DeleteAllRefCurrencyToStoreLicenseDefaultCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCurrencyToStoreLicenseDefaultCommand request)
    {
        var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.StoreLicenseDefault).LoadAsync();
		entity.DeleteAllRefToStoreLicenseDefault();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToStoreLicenseDefaultCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToStoreLicenseDefaultCommand
{
	public AppDbContext DbContext { get; }

	public RefCurrencyToStoreLicenseDefaultCommandHandlerBase(
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