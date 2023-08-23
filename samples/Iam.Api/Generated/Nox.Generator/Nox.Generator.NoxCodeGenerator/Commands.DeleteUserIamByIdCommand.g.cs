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

public record DeleteUserIamByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteUserIamByIdCommandHandler: CommandBase<DeleteUserIamByIdCommand>, IRequestHandler<DeleteUserIamByIdCommand, bool>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }

	public DeleteUserIamByIdCommandHandler(
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

	public async Task<bool> Handle(DeleteUserIamByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<UserIam,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.UserIams.FindAsync(keyId);
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