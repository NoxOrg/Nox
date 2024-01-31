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
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public abstract record RefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefCountryToWorkplacesCommand(EntityKeyDto);

internal partial class CreateRefCountryToWorkplacesCommandHandler
	: RefCountryToWorkplacesCommandHandlerBase<CreateRefCountryToWorkplacesCommand>
{
	public CreateRefCountryToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCountryToWorkplacesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPhysicalWorkplaces(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Workplace",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToWorkplaces(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto, List<WorkplaceKeyDto> RelatedEntitiesKeysDtos)
	: RefCountryToWorkplacesCommand(EntityKeyDto);

internal partial class UpdateRefCountryToWorkplacesCommandHandler
	: RefCountryToWorkplacesCommandHandlerBase<UpdateRefCountryToWorkplacesCommand>
{
	public UpdateRefCountryToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCountryToWorkplacesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Workplace>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetPhysicalWorkplaces(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Workplace", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToWorkplaces(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefCountryToWorkplacesCommand(EntityKeyDto);

internal partial class DeleteRefCountryToWorkplacesCommandHandler
	: RefCountryToWorkplacesCommandHandlerBase<DeleteRefCountryToWorkplacesCommand>
{
	public DeleteRefCountryToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCountryToWorkplacesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPhysicalWorkplaces(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Workplace", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToWorkplaces(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToWorkplacesCommand(EntityKeyDto);

internal partial class DeleteAllRefCountryToWorkplacesCommandHandler
	: RefCountryToWorkplacesCommandHandlerBase<DeleteAllRefCountryToWorkplacesCommand>
{
	public DeleteAllRefCountryToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCountryToWorkplacesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToWorkplaces();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToWorkplacesCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToWorkplacesCommand
{
	public IRepository Repository { get; }

	public RefCountryToWorkplacesCommandHandlerBase(
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

	protected async Task<CountryEntity?> GetCountry(CountryKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Country>(keys.ToArray(), x => x.Workplaces, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Workplace?> GetPhysicalWorkplaces(WorkplaceKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Workplace>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}