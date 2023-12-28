// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateEmployeeCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmployeeKeyDto>;

internal partial class PartialUpdateEmployeeCommandHandler : PartialUpdateEmployeeCommandHandlerBase
{
	public PartialUpdateEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmployeeCommandHandlerBase : CommandBase<PartialUpdateEmployeeCommand, EmployeeEntity>, IRequestHandler<PartialUpdateEmployeeCommand, EmployeeKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> EntityFactory { get; }
	
	public PartialUpdateEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EmployeeKeyDto> Handle(PartialUpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.keyId);

		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entity.Id.Value);
	}
}