// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteCountryLocalNamesByIdCommand(System.String key) : IRequest<bool>;

public class DeleteCountryLocalNamesByIdCommandHandler: IRequestHandler<DeleteCountryLocalNamesByIdCommand, bool>
{
    public  DeleteCountryLocalNamesByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(DeleteCountryLocalNamesByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.CountryLocalNames.FindAsync(request.key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}