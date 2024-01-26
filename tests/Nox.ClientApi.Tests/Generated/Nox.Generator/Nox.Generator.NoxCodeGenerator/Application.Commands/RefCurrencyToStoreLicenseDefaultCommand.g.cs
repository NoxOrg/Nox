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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCurrencyToStoreLicenseDefaultCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreLicenseDefault(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStoreLicenseDefault(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCurrencyToStoreLicenseDefaultCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.StoreLicense>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStoreLicenseDefault(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("StoreLicense", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToStoreLicenseDefault(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCurrencyToStoreLicenseDefaultCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreLicenseDefault(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStoreLicenseDefault(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCurrencyToStoreLicenseDefaultCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStoreLicenseDefault();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToStoreLicenseDefaultCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToStoreLicenseDefaultCommand
{
	public IRepository Repository { get; }

	public RefCurrencyToStoreLicenseDefaultCommandHandlerBase(
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

	protected async Task<CurrencyEntity?> GetCurrency(CurrencyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Currency>(keys.ToArray(), x => x.StoreLicenseDefault, cancellationToken);
	}

	protected async Task<ClientApi.Domain.StoreLicense?> GetStoreLicenseDefault(StoreLicenseKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreLicenseMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<StoreLicense>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CurrencyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}