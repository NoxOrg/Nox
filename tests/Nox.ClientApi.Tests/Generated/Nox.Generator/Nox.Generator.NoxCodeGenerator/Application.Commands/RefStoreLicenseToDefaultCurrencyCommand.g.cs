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

public abstract record RefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreLicenseToDefaultCurrencyCommand(StoreLicenseKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToDefaultCurrencyCommand(EntityKeyDto);

internal partial class CreateRefStoreLicenseToDefaultCurrencyCommandHandler
	: RefStoreLicenseToDefaultCurrencyCommandHandlerBase<CreateRefStoreLicenseToDefaultCurrencyCommand>
{
	public CreateRefStoreLicenseToDefaultCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreLicenseToDefaultCurrencyCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetDefaultCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToDefaultCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreLicenseToDefaultCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetDefaultCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToDefaultCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreLicenseToDefaultCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToDefaultCurrency();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreLicenseToDefaultCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToDefaultCurrencyCommand
{
	public IRepository Repository { get; }

	public RefStoreLicenseToDefaultCurrencyCommandHandlerBase(
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
		return await Repository.FindAsync<ClientApi.Domain.StoreLicense>(keys.ToArray(), cancellationToken);
	}

	protected async Task<ClientApi.Domain.Currency?> GetDefaultCurrency(CurrencyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ClientApi.Domain.Currency>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreLicenseEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}