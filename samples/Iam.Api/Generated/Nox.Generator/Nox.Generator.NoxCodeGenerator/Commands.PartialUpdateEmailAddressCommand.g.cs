﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record PartialUpdateEmailAddressCommand(System.String keyEmail, Dictionary<string, dynamic> UpdatedProperties) : IRequest <EmailAddressKeyDto?>;

public class PartialUpdateEmailAddressCommandHandler: CommandBase<PartialUpdateEmailAddressCommand, EmailAddress>, IRequestHandler<PartialUpdateEmailAddressCommand, EmailAddressKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<EmailAddress> EntityMapper { get; }

	public PartialUpdateEmailAddressCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<EmailAddress> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<EmailAddressKeyDto?> Handle(PartialUpdateEmailAddressCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyEmail = CreateNoxTypeForKey<EmailAddress,Email>("Email", request.keyEmail);

		var entity = await DbContext.EmailAddresses.FindAsync(keyEmail);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<EmailAddress>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new EmailAddressKeyDto(entity.Email.Value);
	}
}