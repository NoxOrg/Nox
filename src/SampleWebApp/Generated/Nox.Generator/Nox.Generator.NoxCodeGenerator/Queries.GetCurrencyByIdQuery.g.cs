// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries;

public record GetCurrencyByIdQuery(System.UInt32 keyId) : IRequest <CurrencyDto?>;

public partial class GetCurrencyByIdQueryHandler:  QueryBase<CurrencyDto?>, IRequestHandler<GetCurrencyByIdQuery, CurrencyDto?>
{
    public  GetCurrencyByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CurrencyDto?> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.Currencies
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}