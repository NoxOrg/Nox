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
using Nox.Exceptions;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public abstract record RefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToDefaultCurrencyCommand(EntityKeyDto);

internal partial class CreateRefStoreLicenseToDefaultCurrencyCommandHandler
	: RefStoreLicenseToDefaultCurrencyCommandHandlerBase<CreateRefStoreLicenseToDefaultCurrencyCommand>
{
	public CreateRefStoreLicenseToDefaultCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreLicenseToDefaultCurrencyCommand request)
    {
		var entity = await GetStoreLicense(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrency(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToDefaultCurrency(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToDefaultCurrencyCommand(EntityKeyDto);

internal partial class DeleteRefStoreLicenseToDefaultCurrencyCommandHandler
	: RefStoreLicenseToDefaultCurrencyCommandHandlerBase<DeleteRefStoreLicenseToDefaultCurrencyCommand>
{
	public DeleteRefStoreLicenseToDefaultCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreLicenseToDefaultCurrencyCommand request)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrency(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToDefaultCurrency(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto)
	: RefStoreLicenseToDefaultCurrencyCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreLicenseToDefaultCurrencyCommandHandler
	: RefStoreLicenseToDefaultCurrencyCommandHandlerBase<DeleteAllRefStoreLicenseToDefaultCurrencyCommand>
{
	public DeleteAllRefStoreLicenseToDefaultCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreLicenseToDefaultCurrencyCommand request)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToDefaultCurrency();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreLicenseToDefaultCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToDefaultCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreLicenseToDefaultCurrencyCommandHandlerBase(
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

	protected async Task<StoreLicenseEntity?> GetStoreLicense(StoreLicenseKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.StoreLicenses.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Currency?> GetCurrency(CurrencyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.CurrencyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Currencies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreLicenseEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}
		return true;
	}
}