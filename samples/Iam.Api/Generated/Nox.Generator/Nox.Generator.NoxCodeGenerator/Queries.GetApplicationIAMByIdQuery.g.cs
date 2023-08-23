// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetApplicationIAMByIdQuery(System.Int64 keyId) : IRequest<ApplicationIAMDto?>;

public class GetApplicationIAMByIdQueryHandler: IRequestHandler<GetApplicationIAMByIdQuery, ApplicationIAMDto?>
{
    public  GetApplicationIAMByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<ApplicationIAMDto?> Handle(GetApplicationIAMByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.ApplicationIAMs
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}