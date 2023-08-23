// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Commands;

public record DeleteCurrencyCashBalanceByIdCommand(System.String keyStoreId, System.UInt32 keyCurrencyId) : IRequest<bool>;

public class DeleteCurrencyCashBalanceByIdCommandHandler: CommandBase<DeleteCurrencyCashBalanceByIdCommand>, IRequestHandler<DeleteCurrencyCashBalanceByIdCommand, bool>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public SampleWebAppDbContext DbContext { get; }

	public DeleteCurrencyCashBalanceByIdCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<bool> Handle(DeleteCurrencyCashBalanceByIdCommand request, CancellationToken cancellationToken)
	{
		var keyStoreId = CreateNoxTypeForKey<CurrencyCashBalance,Text>("StoreId", request.keyStoreId);
		var keyCurrencyId = CreateNoxTypeForKey<CurrencyCashBalance,Nuid>("CurrencyId", request.keyCurrencyId);

		var entity = await DbContext.CurrencyCashBalances.FindAsync(keyStoreId, keyCurrencyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}
		var deletedBy = _userProvider.GetUser();
		var deletedVia = _systemProvider.GetSystem();
		entity.Deleted(deletedBy, deletedVia);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}