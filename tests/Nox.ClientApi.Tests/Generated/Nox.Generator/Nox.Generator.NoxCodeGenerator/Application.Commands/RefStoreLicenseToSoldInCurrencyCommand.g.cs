// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreLicenseToSoldInCurrencyCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSoldInCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSoldInCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreLicenseToSoldInCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSoldInCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSoldInCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreLicenseToSoldInCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSoldInCurrency();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreLicenseToSoldInCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToSoldInCurrencyCommand
{
	public IRepository Repository { get; }

	public RefStoreLicenseToSoldInCurrencyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<StoreLicenseEntity?> GetStoreLicense(StoreLicenseKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreLicenseMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<StoreLicense>(keys.ToArray(), cancellationToken);
	}

	protected async Task<ClientApi.Domain.Currency?> GetSoldInCurrency(CurrencyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Currency>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreLicenseEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}