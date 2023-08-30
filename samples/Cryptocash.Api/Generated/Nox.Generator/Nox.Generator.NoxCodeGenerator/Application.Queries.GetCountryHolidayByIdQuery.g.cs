﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCountryHolidayByIdQuery(System.Int64 keyId) : IRequest <CountryHolidayDto?>;

public partial class GetCountryHolidayByIdQueryHandler:  QueryBase<CountryHolidayDto?>, IRequestHandler<GetCountryHolidayByIdQuery, CountryHolidayDto?>
{
    public  GetCountryHolidayByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CountryHolidayDto?> Handle(GetCountryHolidayByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CountryHolidays
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(OnResponse(item));
    }
}