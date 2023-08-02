// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteStoreSecurityPasswordsByIdCommand(String key) : IRequest<bool>;

public class DeleteStoreSecurityPasswordsByIdCommandHandler: IRequestHandler<DeleteStoreSecurityPasswordsByIdCommand, bool>
{
    public  DeleteStoreSecurityPasswordsByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(DeleteStoreSecurityPasswordsByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.StoreSecurityPasswords.FindAsync(request.key);
        if (entity == null)
        {
            return false;
        }

        DataDbContext.StoreSecurityPasswords.Remove(entity);
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}