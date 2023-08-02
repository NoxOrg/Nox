// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteAllNoxTypeByIdCommand(String key) : IRequest<bool>;

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
        if (entity == null)
        {
            return false;
        }

        DataDbContext.AllNoxTypes.Remove(entity);
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}