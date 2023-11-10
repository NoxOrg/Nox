// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;
using WorkplaceLocalizedEntity = ClientApi.Domain.WorkplaceLocalized;

namespace ClientApi.Application.Commands;
		

public record CreateWorkplaceTranslationsCommand(WorkplaceLocalizedCreateDto WorkplaceLocalizedCreateDto, System.UInt32 Id, System.String CultureCode) : IRequest<WorkplaceLocalizedKeyDto>;

internal partial class CreateWorkplaceTranslationsCommandHandler : CreateWorkplaceTranslationsCommandHandlerBase
{
	public CreateWorkplaceTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceLocalizedCreateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityLocalizedFactory)
	{
	}
}


internal abstract class CreateWorkplaceTranslationsCommandHandlerBase : CommandBase<CreateWorkplaceTranslationsCommand, WorkplaceLocalizedEntity>, IRequestHandler <CreateWorkplaceTranslationsCommand, WorkplaceLocalizedKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceLocalizedCreateDto> EntityLocalizedFactory;
	

	public CreateWorkplaceTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceLocalizedCreateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<WorkplaceLocalizedKeyDto> Handle(CreateWorkplaceTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		command.WorkplaceLocalizedCreateDto.Id = command.Id;
		command.WorkplaceLocalizedCreateDto.CultureCode = command.CultureCode;
		var entityLocalizedToCreate = EntityLocalizedFactory.CreateLocalizedEntity(command.WorkplaceLocalizedCreateDto);
		await OnCompletedAsync(command, entityLocalizedToCreate);
		DbContext.WorkplacesLocalized.Add(entityLocalizedToCreate);
		await DbContext.SaveChangesAsync();
		return new WorkplaceLocalizedKeyDto(entityLocalizedToCreate.Id.Value, entityLocalizedToCreate.CultureCode.Value);
	}
}