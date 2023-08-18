﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Commands;

public record DeleteCountryByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteCountryByIdCommandHandler: CommandBase, IRequestHandler<DeleteCountryByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteCountryByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Country,DatabaseNumber>("Id", request.keyId);

        var entity = await DbContext.Countries.FindAsync(keyId);
        if (entity is null || entity.IsDeleted.Value == true)
        {
            return false;
        }
        //entity.Deleted();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}