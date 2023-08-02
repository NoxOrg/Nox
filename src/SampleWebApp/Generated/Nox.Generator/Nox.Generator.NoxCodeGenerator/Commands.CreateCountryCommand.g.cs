// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Commands;

public record CreateCountryCommand() : IRequest<OCountry>;

public class CreateCountryCommandHandler: IRequestHandler<CreateCountryCommand, OCountry>
{
    public  CreateCountryCommandHandler(SampleWebAppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public SampleWebAppDbContext DbContext { get; }

    public async Task<OCountry> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {       
        await Task.Delay(1000);
        return default(OCountry)!;
    }
}