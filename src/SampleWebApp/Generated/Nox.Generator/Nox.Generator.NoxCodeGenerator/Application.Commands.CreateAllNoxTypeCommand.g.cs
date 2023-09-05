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
using AllNoxType = SampleWebApp.Domain.AllNoxType;

namespace SampleWebApp.Application.Commands;
public record CreateAllNoxTypeCommand(AllNoxTypeCreateDto EntityDto) : IRequest<AllNoxTypeKeyDto>;

public partial class CreateAllNoxTypeCommandHandler: CommandBase<CreateAllNoxTypeCommand,AllNoxType>, IRequestHandler <CreateAllNoxTypeCommand, AllNoxTypeKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }

	public CreateAllNoxTypeCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<AllNoxTypeKeyDto> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();		
	
		OnCompleted(entityToCreate);
		DbContext.AllNoxTypes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new AllNoxTypeKeyDto(entityToCreate.Id.Value, entityToCreate.TextId.Value);
	}
}