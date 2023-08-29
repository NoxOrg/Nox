﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record AddEmployeePhoneNumberCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberCreateDto EntityDto) : IRequest <EmployeePhoneNumberKeyDto?>;

public partial class AddEmployeePhoneNumberCommandHandler: CommandBase<AddEmployeePhoneNumberCommand, EmployeePhoneNumber>, IRequestHandler <AddEmployeePhoneNumberCommand, EmployeePhoneNumberKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<EmployeePhoneNumberCreateDto,EmployeePhoneNumber> EntityFactory { get; }

	public AddEmployeePhoneNumberCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmployeePhoneNumberCreateDto,EmployeePhoneNumber> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<EmployeePhoneNumberKeyDto?> Handle(AddEmployeePhoneNumberCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,DatabaseNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = EntityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.EmployeePhoneNumbers.Add(entity);

		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}