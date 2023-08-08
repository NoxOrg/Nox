// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteMultipleIdsTypeByIdCommand(System.String key) : IRequest<bool>;

public class DeleteMultipleIdsTypeByIdCommandHandler: IRequestHandler<DeleteMultipleIdsTypeByIdCommand, bool>
{
    public  DeleteMultipleIdsTypeByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(DeleteMultipleIdsTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.MultipleIdsTypes.FindAsync(request.key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}