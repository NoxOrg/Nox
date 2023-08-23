﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCustomerCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CustomerKeyDto?>;

public class PartialUpdateCustomerCommandHandler: CommandBase, IRequestHandler<PartialUpdateCustomerCommand, CustomerKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<Customer> EntityMapper { get; }

	public PartialUpdateCustomerCommandHandler(
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

	public async Task<CustomerKeyDto?> Handle(PartialUpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Customer>(), request.UpdatedProperties);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CustomerKeyDto(entity.Id.Value);
	}
}