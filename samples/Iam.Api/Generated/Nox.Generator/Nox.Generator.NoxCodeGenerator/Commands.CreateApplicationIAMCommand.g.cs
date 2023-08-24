﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;
public record CreateApplicationIAMCommand(ApplicationIAMCreateDto EntityDto) : IRequest<ApplicationIAMKeyDto>;

public partial class CreateApplicationIAMCommandHandler: CommandBase<CreateApplicationIAMCommand,ApplicationIAM>, IRequestHandler <CreateApplicationIAMCommand, ApplicationIAMKeyDto>
{
	public IamApiDbContext DbContext { get; }
	public IEntityFactory<ApplicationIAMCreateDto,ApplicationIAM> EntityFactory { get; }

	public CreateApplicationIAMCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ApplicationIAMCreateDto,ApplicationIAM> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<ApplicationIAMKeyDto> Handle(CreateApplicationIAMCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.ApplicationIAMs.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ApplicationIAMKeyDto(entityToCreate.Id.Value);
	}
}