﻿
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
			return false;
		}

		var relatedEntity = await GetWorkplace(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
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
			return false;
		}

		var relatedEntities = new List<ClientApi.Domain.Workplace>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetWorkplace(keyDto);
			if (relatedEntity == null)
			{
				return false;
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
			return false;
		}

		var relatedEntity = await GetWorkplace(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
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
			return false;
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
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Workplace?> GetWorkplace(WorkplaceKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.WorkplaceMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Workplaces.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CountryEntity entity)
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