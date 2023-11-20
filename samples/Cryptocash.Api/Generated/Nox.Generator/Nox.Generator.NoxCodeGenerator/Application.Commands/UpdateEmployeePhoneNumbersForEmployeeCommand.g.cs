﻿
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Commands;
public partial record UpdateEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberKeyDto EntityKeyDto, EmployeePhoneNumberUpdateDto EntityDto, System.Guid? Etag) : IRequest <EmployeePhoneNumberKeyDto?>;

internal partial class UpdateEmployeePhoneNumbersForEmployeeCommandHandler : UpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase
{
	public UpdateEmployeePhoneNumbersForEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase : CommandBase<UpdateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler <UpdateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> _entityFactory;

	public UpdateEmployeePhoneNumbersForEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmployeePhoneNumberKeyDto?> Handle(UpdateEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}