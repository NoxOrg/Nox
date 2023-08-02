// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Commands;

public record CreateCountryLocalNamesCommand() : IRequest<OCountryLocalNames>;

public class CreateCountryLocalNamesCommandHandler: IRequestHandler<CreateCountryLocalNamesCommand, OCountryLocalNames>
{
    public  CreateCountryLocalNamesCommandHandler(SampleWebAppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public SampleWebAppDbContext DbContext { get; }

    public async Task<OCountryLocalNames> Handle(CreateCountryLocalNamesCommand request, CancellationToken cancellationToken)
    {       
        await Task.Delay(1000);
        return default(OCountryLocalNames)!;
    }
}