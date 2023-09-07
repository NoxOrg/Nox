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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeePhoneNumber = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Commands;
public record AddEmployeePhoneNumberCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberCreateDto EntityDto) : IRequest <EmployeePhoneNumberKeyDto?>;

public partial class AddEmployeePhoneNumberCommandHandler: CommandBase<AddEmployeePhoneNumberCommand, EmployeePhoneNumber>, IRequestHandler <AddEmployeePhoneNumberCommand, EmployeePhoneNumberKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<EmployeePhoneNumberCreateDto,EmployeePhoneNumber> _entityFactory;

	public AddEmployeePhoneNumberCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<EmployeePhoneNumberCreateDto,EmployeePhoneNumber> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public async Task<EmployeePhoneNumberKeyDto?> Handle(AddEmployeePhoneNumberCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,DatabaseNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.EmployeePhoneNumbers.Add(entity);

		OnCompleted(entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}