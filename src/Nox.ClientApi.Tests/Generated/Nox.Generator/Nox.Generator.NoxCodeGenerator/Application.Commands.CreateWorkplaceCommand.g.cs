﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record CreateWorkplaceCommand(WorkplaceCreateDto EntityDto) : IRequest<WorkplaceKeyDto>;

public partial class CreateWorkplaceCommandHandler: CommandBase<CreateWorkplaceCommand,Workplace>, IRequestHandler <CreateWorkplaceCommand, WorkplaceKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<Workplace,WorkplaceCreateDto> _entityFactory;
    private readonly IEntityFactory<Country,CountryCreateDto> _countryfactory;

	public CreateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Country,CountryCreateDto> countryfactory,
        IEntityFactory<Workplace,WorkplaceCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _countryfactory = countryfactory;
	}

	public async Task<WorkplaceKeyDto> Handle(CreateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.BelongsToCountry is not null)
		{ 
			var relatedEntity = _countryfactory.CreateEntity(request.EntityDto.BelongsToCountry);
			entityToCreate.CreateRefToBelongsToCountry(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.Workplaces.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new WorkplaceKeyDto(entityToCreate.Id.Value);
	}
}