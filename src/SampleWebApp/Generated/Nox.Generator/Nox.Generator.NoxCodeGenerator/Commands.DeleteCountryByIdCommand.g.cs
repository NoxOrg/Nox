// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteCountryByIdCommand(System.String key) : IRequest<bool>;

public class DeleteCountryByIdCommandHandler: IRequestHandler<DeleteCountryByIdCommand, bool>
{
    public  DeleteCountryByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.Countries.FindAsync(request.key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}