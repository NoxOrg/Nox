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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Store = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;
public record CreateStoreCommand(StoreCreateDto EntityDto) : IRequest<StoreKeyDto>;

public partial class CreateStoreCommandHandler: CommandBase<CreateStoreCommand,Store>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	public ClientApiDbContext DbContext { get; }

	public CreateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();
		entityToCreate.EnsureId();		
	
		OnCompleted(entityToCreate);
		DbContext.Stores.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreKeyDto(entityToCreate.Id.Value);
	}
}