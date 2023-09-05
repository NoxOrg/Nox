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
using StoreSecurityPasswords = SampleWebApp.Domain.StoreSecurityPasswords;

namespace SampleWebApp.Application.Commands;
public record CreateStoreSecurityPasswordsCommand(StoreSecurityPasswordsCreateDto EntityDto) : IRequest<StoreSecurityPasswordsKeyDto>;

public partial class CreateStoreSecurityPasswordsCommandHandler: CommandBase<CreateStoreSecurityPasswordsCommand,StoreSecurityPasswords>, IRequestHandler <CreateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }

	public CreateStoreSecurityPasswordsCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<StoreSecurityPasswordsKeyDto> Handle(CreateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();		
	
		OnCompleted(entityToCreate);
		DbContext.StoreSecurityPasswords.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreSecurityPasswordsKeyDto(entityToCreate.Id.Value);
	}
}