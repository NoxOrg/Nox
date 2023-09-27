﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public abstract record RefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToBelongsToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefWorkplaceToBelongsToCountryCommandHandler
	: RefWorkplaceToBelongsToCountryCommandHandlerBase<CreateRefWorkplaceToBelongsToCountryCommand>
{
	public CreateRefWorkplaceToBelongsToCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToBelongsToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefWorkplaceToBelongsToCountryCommandHandler
	: RefWorkplaceToBelongsToCountryCommandHandlerBase<DeleteRefWorkplaceToBelongsToCountryCommand>
{
	public DeleteRefWorkplaceToBelongsToCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto)
	: RefWorkplaceToBelongsToCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefWorkplaceToBelongsToCountryCommandHandler
	: RefWorkplaceToBelongsToCountryCommandHandlerBase<DeleteAllRefWorkplaceToBelongsToCountryCommand>
{
	public DeleteAllRefWorkplaceToBelongsToCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefWorkplaceToBelongsToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, Workplace>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToBelongsToCountryCommand
{
	public ClientApiDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefWorkplaceToBelongsToCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Workplace, Nox.Types.Nuid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Country? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Country, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToBelongsToCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBelongsToCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToBelongsToCountry();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}