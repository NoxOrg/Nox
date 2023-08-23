// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using IamApi.Infrastructure.Persistence;
using IamApi.Domain;

namespace IamApi.Application.Commands;

public record DeleteApplicationIAMByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteApplicationIAMByIdCommandHandler: CommandBase<DeleteApplicationIAMByIdCommand>, IRequestHandler<DeleteApplicationIAMByIdCommand, bool>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }

	public DeleteApplicationIAMByIdCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<bool> Handle(DeleteApplicationIAMByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<ApplicationIAM,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ApplicationIAMs.FindAsync(keyId);
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