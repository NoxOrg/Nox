// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Commands;

public record CreateStoreSecurityPasswordsCommand() : IRequest<OStoreSecurityPasswords>;

public class CreateStoreSecurityPasswordsCommandHandler: IRequestHandler<CreateStoreSecurityPasswordsCommand, OStoreSecurityPasswords>
{
    public  CreateStoreSecurityPasswordsCommandHandler(SampleWebAppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public SampleWebAppDbContext DbContext { get; }

    public async Task<OStoreSecurityPasswords> Handle(CreateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {       
        await Task.Delay(1000);
        return default(OStoreSecurityPasswords)!;
    }
}