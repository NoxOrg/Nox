// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateEmployeeCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <EmployeeKeyDto>;

internal partial class PartialUpdateEmployeeCommandHandler : PartialUpdateEmployeeCommandHandlerBase
{
	public PartialUpdateEmployeeCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateEmployeeCommandHandlerBase : CommandBase<PartialUpdateEmployeeCommand, EmployeeEntity>, IRequestHandler<PartialUpdateEmployeeCommand, EmployeeKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> EntityFactory { get; }
	
	public PartialUpdateEmployeeCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<EmployeeKeyDto> Handle(PartialUpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.EmployeeMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Employee>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Employee",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new EmployeeKeyDto(entity.Id.Value);
	}
}