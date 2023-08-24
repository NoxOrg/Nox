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

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record CreateStoreSecurityPasswordsCommand(StoreSecurityPasswordsCreateDto EntityDto) : IRequest<StoreSecurityPasswordsKeyDto>;

public partial class CreateStoreSecurityPasswordsCommandHandler: CommandBase<CreateStoreSecurityPasswordsCommand,StoreSecurityPasswords>, IRequestHandler <CreateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> EntityFactory { get; }

	public CreateStoreSecurityPasswordsCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<StoreSecurityPasswordsKeyDto> Handle(CreateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.StoreSecurityPasswords.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreSecurityPasswordsKeyDto{ Id = entityToCreate.Id.Value };
	}
}