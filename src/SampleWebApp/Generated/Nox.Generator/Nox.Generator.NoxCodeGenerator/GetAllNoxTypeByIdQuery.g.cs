﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Domain;

public record GetAllNoxTypeByIdQuery(String key) : IRequest<OAllNoxType?>;

public class GetAllNoxTypeByIdQueryHandler: IRequestHandler<GetAllNoxTypeByIdQuery, OAllNoxType?>
{
    public  GetAllNoxTypeByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<OAllNoxType?> Handle(GetAllNoxTypeByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.AllNoxTypes.SingleOrDefault(r => r.Id.Equals(request.key));
        return Task.FromResult(item);
    }
}