// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Commands;

public record DeleteCountryLocalNamesByIdCommand(System.String keyId) : IRequest<bool>;

public class DeleteCountryLocalNamesByIdCommandHandler: CommandBase, IRequestHandler<DeleteCountryLocalNamesByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteCountryLocalNamesByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteCountryLocalNamesByIdCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<CountryLocalNames,Text>("Id", request.keyId);

        var entity = await DbContext.CountryLocalNames.FindAsync(keyId);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}