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

public record DeleteStoreByIdCommand(System.String keyId) : IRequest<bool>;

public class DeleteStoreByIdCommandHandler: CommandBase, IRequestHandler<DeleteStoreByIdCommand, bool>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }

    public  DeleteStoreByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IUserProvider userProvider,
        ISystemProvider systemProvider) : base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }    

    public async Task<bool> Handle(DeleteStoreByIdCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Store,Text>("Id", request.keyId);

        var entity = await DbContext.Stores.FindAsync(keyId);
        if (entity is null || entity.IsDeleted.Value == true)
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