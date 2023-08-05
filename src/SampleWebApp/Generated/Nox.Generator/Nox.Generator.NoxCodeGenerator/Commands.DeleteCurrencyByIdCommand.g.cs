﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Commands;

public record DeleteCurrencyByIdCommand(System.String key) : IRequest<bool>;

public class DeleteCurrencyByIdCommandHandler: IRequestHandler<DeleteCurrencyByIdCommand, bool>
{
    public  DeleteCurrencyByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(DeleteCurrencyByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.Currencies.FindAsync(request.key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}