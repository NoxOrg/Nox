// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public partial record DeleteEmployeeByIdCommand(IEnumerable<EmployeeKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteEmployeeByIdCommandHandler : DeleteEmployeeByIdCommandHandlerBase
{
	public DeleteEmployeeByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteEmployeeByIdCommandHandlerBase : CommandCollectionBase<DeleteEmployeeByIdCommand, EmployeeEntity>, IRequestHandler<DeleteEmployeeByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteEmployeeByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<EmployeeEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.EmployeeMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<Employee>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Employee",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<EmployeeEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}