﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdateCustomerCommand(System.Int64 keyId, CustomerUpdateDto EntityDto) : IRequest<CustomerKeyDto?>;

public class UpdateCustomerCommandHandler: CommandBase, IRequestHandler<UpdateCustomerCommand, CustomerKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<Customer> EntityMapper { get; }

	public UpdateCustomerCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Customer> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}
	
	public async Task<CustomerKeyDto?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Customer>(), request.EntityDto);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new CustomerKeyDto(entity.Id.Value);
	}
}