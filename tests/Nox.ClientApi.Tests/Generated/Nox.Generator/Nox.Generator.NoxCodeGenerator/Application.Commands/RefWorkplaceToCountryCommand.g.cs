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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public abstract record RefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToCountryCommand(EntityKeyDto);

internal partial class CreateRefWorkplaceToCountryCommandHandler
	: RefWorkplaceToCountryCommandHandlerBase<CreateRefWorkplaceToCountryCommand>
{
	public CreateRefWorkplaceToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefWorkplaceToCountryCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetWorkplace(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBelongsToCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToCountryCommand(EntityKeyDto);

internal partial class DeleteRefWorkplaceToCountryCommandHandler
	: RefWorkplaceToCountryCommandHandlerBase<DeleteRefWorkplaceToCountryCommand>
{
	public DeleteRefWorkplaceToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefWorkplaceToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetWorkplace(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetBelongsToCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto)
	: RefWorkplaceToCountryCommand(EntityKeyDto);

internal partial class DeleteAllRefWorkplaceToCountryCommandHandler
	: RefWorkplaceToCountryCommandHandlerBase<DeleteAllRefWorkplaceToCountryCommand>
{
	public DeleteAllRefWorkplaceToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefWorkplaceToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetWorkplace(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountry();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefWorkplaceToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, WorkplaceEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToCountryCommand
{
	public IRepository Repository { get; }

	public RefWorkplaceToCountryCommandHandlerBase(
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

	protected async Task<WorkplaceEntity?> GetWorkplace(WorkplaceKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Workplace>(keys.ToArray(), cancellationToken);
	}

	protected async Task<ClientApi.Domain.Country?> GetBelongsToCountry(CountryKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Country>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, WorkplaceEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}