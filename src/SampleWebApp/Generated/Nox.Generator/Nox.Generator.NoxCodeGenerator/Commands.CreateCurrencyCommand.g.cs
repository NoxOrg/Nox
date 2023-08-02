// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Commands;

public record CreateCurrencyCommand() : IRequest<OCurrency>;

public class CreateCurrencyCommandHandler: IRequestHandler<CreateCurrencyCommand, OCurrency>
{
    public  CreateCurrencyCommandHandler(SampleWebAppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public SampleWebAppDbContext DbContext { get; }

    public async Task<OCurrency> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {       
        await Task.Delay(1000);
        return default(OCurrency)!;
    }
}