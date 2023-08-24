﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record UpdateEmailAddressCommand(System.String keyEmail, EmailAddressUpdateDto EntityDto) : IRequest<EmailAddressKeyDto?>;

public class UpdateEmailAddressCommandHandler: CommandBase<UpdateEmailAddressCommand, EmailAddress>, IRequestHandler<UpdateEmailAddressCommand, EmailAddressKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<EmailAddress> EntityMapper { get; }

	public UpdateEmailAddressCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<EmailAddress> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<EmailAddressKeyDto?> Handle(UpdateEmailAddressCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyEmail = CreateNoxTypeForKey<EmailAddress,Email>("Email", request.keyEmail);
	
		var entity = await DbContext.EmailAddresses.FindAsync(keyEmail);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<EmailAddress>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new EmailAddressKeyDto(entity.Email.Value);
	}
}