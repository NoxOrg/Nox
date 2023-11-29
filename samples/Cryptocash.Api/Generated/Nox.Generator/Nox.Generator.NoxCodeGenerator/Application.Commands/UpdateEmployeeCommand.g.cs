﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public partial record UpdateEmployeeCommand(System.Int64 keyId, EmployeeUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<EmployeeKeyDto?>;

internal partial class UpdateEmployeeCommandHandler : UpdateEmployeeCommandHandlerBase
{
	public UpdateEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateEmployeeCommandHandlerBase : CommandBase<UpdateEmployeeCommand, EmployeeEntity>, IRequestHandler<UpdateEmployeeCommand, EmployeeKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> _entityFactory;

	public UpdateEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmployeeKeyDto?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.keyId);

		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		await DbContext.Entry(entity).Collection(x => x.EmployeePhoneNumbers).LoadAsync();
		var keysToUpdateEmployeePhoneNumbers = request.EntityDto.EmployeePhoneNumbers
			.Where(x => x.Id != null)
			.Select(x => Cryptocash.Domain.EmployeePhoneNumberMetadata.CreateId(x.Id.NonNullValue<System.Int64>()));
		foreach(var ownedEntity in entity.EmployeePhoneNumbers)
		{
			if(!keysToUpdateEmployeePhoneNumbers.Any(x => x == ownedEntity.Id))
				DbContext.Entry(ownedEntity).State = EntityState.Deleted;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeeKeyDto(entity.Id.Value);
	}
}

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeValidator()
    {
    }
}