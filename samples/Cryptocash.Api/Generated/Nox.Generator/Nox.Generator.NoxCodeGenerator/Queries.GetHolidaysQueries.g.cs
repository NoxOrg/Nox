﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetHolidaysQuery() : IRequest<IQueryable<HolidaysDto>>;

public class GetHolidaysQueryHandler : IRequestHandler<GetHolidaysQuery, IQueryable<HolidaysDto>>
{
    public  GetHolidaysQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<HolidaysDto>> Handle(GetHolidaysQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<HolidaysDto>)DataDbContext.Holidays
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}