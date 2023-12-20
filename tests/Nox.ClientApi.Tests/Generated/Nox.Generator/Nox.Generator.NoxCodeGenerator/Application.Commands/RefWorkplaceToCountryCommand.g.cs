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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefWorkplaceToCountryCommand request)
    {
		var entity = await GetWorkplace(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefWorkplaceToCountryCommand request)
    {
        var entity = await GetWorkplace(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefWorkplaceToCountryCommand request)
    {
        var entity = await GetWorkplace(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		entity.DeleteAllRefToCountry();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefWorkplaceToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, WorkplaceEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToCountryCommand
{
	public AppDbContext DbContext { get; }

	public RefWorkplaceToCountryCommandHandlerBase(
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

	protected async Task<WorkplaceEntity?> GetWorkplace(WorkplaceKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Workplaces.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Country?> GetCountry(CountryKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.CountryMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, WorkplaceEntity entity)
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