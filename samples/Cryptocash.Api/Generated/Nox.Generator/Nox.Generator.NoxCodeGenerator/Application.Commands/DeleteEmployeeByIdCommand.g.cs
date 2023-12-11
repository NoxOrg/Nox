// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public partial record DeleteEmployeeByIdCommand(IEnumerable<EmployeeKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteEmployeeByIdCommandHandler : DeleteEmployeeByIdCommandHandlerBase
{
	public DeleteEmployeeByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteEmployeeByIdCommandHandlerBase : CommandCollectionBase<DeleteEmployeeByIdCommand, EmployeeEntity>, IRequestHandler<DeleteEmployeeByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEmployeeByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<EmployeeEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Employees.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}