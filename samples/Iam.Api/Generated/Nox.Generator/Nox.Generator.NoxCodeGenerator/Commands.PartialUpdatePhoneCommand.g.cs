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

public record PartialUpdatePhoneCommand(System.String keyPhoneNumber, Dictionary<string, dynamic> UpdatedProperties) : IRequest <PhoneKeyDto?>;

public class PartialUpdatePhoneCommandHandler: CommandBase<PartialUpdatePhoneCommand, Phone>, IRequestHandler<PartialUpdatePhoneCommand, PhoneKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<Phone> EntityMapper { get; }

	public PartialUpdatePhoneCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Phone> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<PhoneKeyDto?> Handle(PartialUpdatePhoneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyPhoneNumber = CreateNoxTypeForKey<Phone,PhoneNumber>("PhoneNumber", request.keyPhoneNumber);

		var entity = await DbContext.Phones.FindAsync(keyPhoneNumber);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Phone>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new PhoneKeyDto(entity.PhoneNumber.Value);
	}
}