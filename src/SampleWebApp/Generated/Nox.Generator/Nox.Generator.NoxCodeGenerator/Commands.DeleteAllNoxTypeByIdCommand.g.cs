// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteAllNoxTypeByIdCommand(System.Int32 key) : IRequest<bool>;

public class DeleteAllNoxTypeByIdCommandHandler: IRequestHandler<DeleteAllNoxTypeByIdCommand, bool>
{
    public  DeleteAllNoxTypeByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(DeleteAllNoxTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.AllNoxTypes.FindAsync(request.key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}