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

public record DeleteCountryByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCountryByIdCommandHandler: CommandBase<DeleteCountryByIdCommand>, IRequestHandler<DeleteCountryByIdCommand, bool>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public SampleWebAppDbContext DbContext { get; }

	public DeleteCountryByIdCommandHandler(
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

	public async Task<bool> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<Country,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
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