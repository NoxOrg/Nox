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
using StoreOwner = SampleWebApp.Domain.StoreOwner;

namespace SampleWebApp.Application.Commands;
public record CreateStoreOwnerCommand(StoreOwnerCreateDto EntityDto) : IRequest<StoreOwnerKeyDto>;

public partial class CreateStoreOwnerCommandHandler: CommandBase<CreateStoreOwnerCommand,StoreOwner>, IRequestHandler <CreateStoreOwnerCommand, StoreOwnerKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }

	public CreateStoreOwnerCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<StoreOwnerKeyDto> Handle(CreateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();		
	
		OnCompleted(entityToCreate);
		DbContext.StoreOwners.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entityToCreate.Id.Value);
	}
}