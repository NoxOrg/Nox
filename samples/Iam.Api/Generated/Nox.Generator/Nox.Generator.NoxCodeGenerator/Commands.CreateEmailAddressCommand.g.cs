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
public record CreateEmailAddressCommand(EmailAddressCreateDto EntityDto) : IRequest<EmailAddressKeyDto>;

public partial class CreateEmailAddressCommandHandler: CommandBase<CreateEmailAddressCommand,EmailAddress>, IRequestHandler <CreateEmailAddressCommand, EmailAddressKeyDto>
{
	public IamApiDbContext DbContext { get; }
	public IEntityFactory<EmailAddressCreateDto,EmailAddress> EntityFactory { get; }

	public CreateEmailAddressCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmailAddressCreateDto,EmailAddress> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<EmailAddressKeyDto> Handle(CreateEmailAddressCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.EmailAddresses.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EmailAddressKeyDto(entityToCreate.Email.Value);
	}
}