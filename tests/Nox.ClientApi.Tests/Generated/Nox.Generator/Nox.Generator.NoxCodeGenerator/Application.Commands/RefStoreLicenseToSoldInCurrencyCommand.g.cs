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
using Dto = ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public abstract record RefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToSoldInCurrencyCommand(EntityKeyDto);

internal partial class CreateRefStoreLicenseToSoldInCurrencyCommandHandler
	: RefStoreLicenseToSoldInCurrencyCommandHandlerBase<CreateRefStoreLicenseToSoldInCurrencyCommand>
{
	public CreateRefStoreLicenseToSoldInCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreLicenseToSoldInCurrencyCommand request)
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

		entity.CreateRefToSoldInCurrency(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToSoldInCurrencyCommand(EntityKeyDto);

internal partial class DeleteRefStoreLicenseToSoldInCurrencyCommandHandler
	: RefStoreLicenseToSoldInCurrencyCommandHandlerBase<DeleteRefStoreLicenseToSoldInCurrencyCommand>
{
	public DeleteRefStoreLicenseToSoldInCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreLicenseToSoldInCurrencyCommand request)
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

		entity.DeleteRefToSoldInCurrency(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreLicenseToSoldInCurrencyCommand(StoreLicenseKeyDto EntityKeyDto)
	: RefStoreLicenseToSoldInCurrencyCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreLicenseToSoldInCurrencyCommandHandler
	: RefStoreLicenseToSoldInCurrencyCommandHandlerBase<DeleteAllRefStoreLicenseToSoldInCurrencyCommand>
{
	public DeleteAllRefStoreLicenseToSoldInCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreLicenseToSoldInCurrencyCommand request)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSoldInCurrency();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreLicenseToSoldInCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToSoldInCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreLicenseToSoldInCurrencyCommandHandlerBase(
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
		var keyId = Dto.StoreLicenseMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.StoreLicenses.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Currency?> GetCurrency(CurrencyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.CurrencyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Currencies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreLicenseEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}