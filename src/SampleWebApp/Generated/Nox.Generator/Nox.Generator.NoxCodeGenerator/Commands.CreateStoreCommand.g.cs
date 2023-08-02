// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Commands;

public record CreateStoreCommand() : IRequest<OStore>;

public class CreateStoreCommandHandler: IRequestHandler<CreateStoreCommand, OStore>
{
    public  CreateStoreCommandHandler(SampleWebAppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public SampleWebAppDbContext DbContext { get; }

    public async Task<OStore> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {       
        await Task.Delay(1000);
        return default(OStore)!;
    }
}