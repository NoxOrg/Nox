// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteStoreByIdCommand(String key) : IRequest<bool>;

public class DeleteStoreByIdCommandHandler: IRequestHandler<DeleteStoreByIdCommand, bool>
{
    public  DeleteStoreByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(DeleteStoreByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.Stores.FindAsync(request.key);
        if (entity == null)
        {
            return false;
        }

        DataDbContext.Stores.Remove(entity);
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}