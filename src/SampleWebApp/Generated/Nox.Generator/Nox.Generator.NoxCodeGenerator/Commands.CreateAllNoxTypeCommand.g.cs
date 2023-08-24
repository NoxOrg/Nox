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
public record CreateAllNoxTypeCommand(AllNoxTypeCreateDto EntityDto) : IRequest<AllNoxTypeKeyDto>;

public partial class CreateAllNoxTypeCommandHandler: CommandBase<CreateAllNoxTypeCommand,AllNoxType>, IRequestHandler <CreateAllNoxTypeCommand, AllNoxTypeKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<AllNoxTypeCreateDto,AllNoxType> EntityFactory { get; }

	public CreateAllNoxTypeCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<AllNoxTypeCreateDto,AllNoxType> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<AllNoxTypeKeyDto> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.AllNoxTypes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new AllNoxTypeKeyDto(entityToCreate.Id.Value, entityToCreate.TextId.Value);
	}
}