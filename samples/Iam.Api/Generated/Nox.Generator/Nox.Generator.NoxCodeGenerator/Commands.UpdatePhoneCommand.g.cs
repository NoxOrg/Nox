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

public record UpdatePhoneCommand(System.String keyPhoneNumber, PhoneUpdateDto EntityDto) : IRequest<PhoneKeyDto?>;

public class UpdatePhoneCommandHandler: CommandBase<UpdatePhoneCommand, Phone>, IRequestHandler<UpdatePhoneCommand, PhoneKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<Phone> EntityMapper { get; }

	public UpdatePhoneCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Phone> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<PhoneKeyDto?> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyPhoneNumber = CreateNoxTypeForKey<Phone,PhoneNumber>("PhoneNumber", request.keyPhoneNumber);
	
		var entity = await DbContext.Phones.FindAsync(keyPhoneNumber);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Phone>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new PhoneKeyDto(entity.PhoneNumber.Value);
	}
}