﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdateEmployeePhoneNumberCommand(System.Int64 keyId, EmployeePhoneNumberUpdateDto EntityDto) : IRequest<EmployeePhoneNumberKeyDto?>;

public class UpdateEmployeePhoneNumberCommandHandler: CommandBase<UpdateEmployeePhoneNumberCommand>, IRequestHandler<UpdateEmployeePhoneNumberCommand, EmployeePhoneNumberKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<EmployeePhoneNumber> EntityMapper { get; }

	public UpdateEmployeePhoneNumberCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<EmployeePhoneNumber> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<EmployeePhoneNumberKeyDto?> Handle(UpdateEmployeePhoneNumberCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<EmployeePhoneNumber,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.EmployeePhoneNumbers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<EmployeePhoneNumber>(), request.EntityDto);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}