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

public abstract record RefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto);

internal partial class CreateRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<CreateRefCurrencyToStoreLicenseSoldInCommand>
{
	public CreateRefCurrencyToStoreLicenseSoldInCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCurrencyToStoreLicenseSoldInCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreLicenseSoldIn(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStoreLicenseSoldIn(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCurrencyToStoreLicenseSoldInCommand(CurrencyKeyDto EntityKeyDto, List<StoreLicenseKeyDto> RelatedEntitiesKeysDtos)
	: RefCurrencyToStoreLicenseSoldInCommand(EntityKeyDto);

internal partial class UpdateRefCurrencyToStoreLicenseSoldInCommandHandler
	: RefCurrencyToStoreLicenseSoldInCommandHandlerBase<UpdateRefCurrencyToStoreLicenseSoldInCommand>
{
	public UpdateRefCurrencyToStoreLicenseSoldInCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCurrencyToStoreLicenseSoldInCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.StoreLicense>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStoreLicenseSoldIn(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("StoreLicense", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToStoreLicenseSoldIn(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCurrencyToStoreLicenseSoldInCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreLicenseSoldIn(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStoreLicenseSoldIn(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCurrencyToStoreLicenseSoldInCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStoreLicenseSoldIn();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToStoreLicenseSoldInCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToStoreLicenseSoldInCommand
{
	public IRepository Repository { get; }

	public RefCurrencyToStoreLicenseSoldInCommandHandlerBase(
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
		return await Repository.FindAndIncludeAsync<Currency>(keys.ToArray(), x => x.StoreLicenseSoldIn, cancellationToken);
	}

	protected async Task<ClientApi.Domain.StoreLicense?> GetStoreLicenseSoldIn(StoreLicenseKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
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