
// Generated

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

namespace Cryptocash.Application.Commands;

public record CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler: CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase
{
	public CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase: CommandBase<CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand, Employee>, 
	IRequestHandler <CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CashStockOrder, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCashStockOrderEmployeeReviewingCashStockOrder(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}