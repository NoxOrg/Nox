﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Commands;
public partial record CreateEmployeePhoneNumbersForEmployeeCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmployeePhoneNumberKeyDto>;

internal partial class CreateEmployeePhoneNumbersForEmployeeCommandHandler : CreateEmployeePhoneNumbersForEmployeeCommandHandlerBase
{
	public CreateEmployeePhoneNumbersForEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateEmployeePhoneNumbersForEmployeeCommandHandlerBase : CommandBase<CreateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberEntity>, IRequestHandler<CreateEmployeePhoneNumbersForEmployeeCommand, EmployeePhoneNumberKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> _entityFactory;

	protected CreateEmployeePhoneNumbersForEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<EmployeePhoneNumberKeyDto?> Handle(CreateEmployeePhoneNumbersForEmployeeCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToEmployeePhoneNumbers(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;

		var result = await _dbContext.SaveChangesAsync();

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}

public class CreateEmployeePhoneNumbersForEmployeeValidator : AbstractValidator<CreateEmployeePhoneNumbersForEmployeeCommand>
{
    public CreateEmployeePhoneNumbersForEmployeeValidator()
    {
		RuleFor(x => x.EntityDto.Id).Null().WithMessage("Id must be null as it is auto generated.");
    }
}