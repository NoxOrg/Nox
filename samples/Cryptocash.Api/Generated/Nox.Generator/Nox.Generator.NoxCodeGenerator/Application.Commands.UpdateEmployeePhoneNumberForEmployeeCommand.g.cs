﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record UpdateEmployeePhoneNumberForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto, EmployeePhoneNumberUpdateDto EntityDto, System.Guid? Etag) : IRequest <EmployeePhoneNumberKeyDto?>;

public partial class UpdateEmployeePhoneNumberForEmployeeCommandHandler : UpdateEmployeePhoneNumberForEmployeeCommandHandlerBase
{
	public UpdateEmployeePhoneNumberForEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmployeePhoneNumber, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> entityFactory)
		: base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

public partial class UpdateEmployeePhoneNumberForEmployeeCommandHandlerBase : CommandBase<UpdateEmployeePhoneNumberForEmployeeCommand, EmployeePhoneNumber>, IRequestHandler <UpdateEmployeePhoneNumberForEmployeeCommand, EmployeePhoneNumberKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<EmployeePhoneNumber, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> _entityFactory;

	public UpdateEmployeePhoneNumberForEmployeeCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmployeePhoneNumber, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmployeePhoneNumberKeyDto?> Handle(UpdateEmployeePhoneNumberForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<EmployeePhoneNumber,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeeContactPhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}