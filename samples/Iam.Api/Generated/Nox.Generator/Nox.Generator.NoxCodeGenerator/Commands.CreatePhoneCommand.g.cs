﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;
public record CreatePhoneCommand(PhoneCreateDto EntityDto) : IRequest<PhoneKeyDto>;

public partial class CreatePhoneCommandHandler: CommandBase<CreatePhoneCommand,Phone>, IRequestHandler <CreatePhoneCommand, PhoneKeyDto>
{
	public IamApiDbContext DbContext { get; }
	public IEntityFactory<PhoneCreateDto,Phone> EntityFactory { get; }

	public CreatePhoneCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<PhoneCreateDto,Phone> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<PhoneKeyDto> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.Phones.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new PhoneKeyDto(entityToCreate.PhoneNumber.Value);
	}
}