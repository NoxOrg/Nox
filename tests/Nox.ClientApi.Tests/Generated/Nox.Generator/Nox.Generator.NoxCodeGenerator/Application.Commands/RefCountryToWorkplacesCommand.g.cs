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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCountryToWorkplacesCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPhysicalWorkplaces(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Workplace",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToWorkplaces(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCountryToWorkplacesCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Workplace>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetPhysicalWorkplaces(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Workplace", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Workplaces).LoadAsync();
		entity.UpdateRefToWorkplaces(relatedEntities);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCountryToWorkplacesCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPhysicalWorkplaces(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Workplace", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToWorkplaces(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCountryToWorkplacesCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Workplaces).LoadAsync();
		entity.DeleteAllRefToWorkplaces();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToWorkplacesCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToWorkplacesCommand
{
	public AppDbContext DbContext { get; }

	public RefCountryToWorkplacesCommandHandlerBase(
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

	protected async Task<CountryEntity?> GetCountry(CountryKeyDto entityKeyDto)
	{
		var keyId = Dto.CountryMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Workplace?> GetPhysicalWorkplaces(WorkplaceKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.WorkplaceMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Workplaces.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}