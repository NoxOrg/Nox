// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using IamApi.Application.Dto;
using IamApi.Infrastructure.Persistence;

namespace IamApi.Application.Queries;

public record GetUserIamByIdQuery(System.Int64 keyId) : IRequest<UserIamDto?>;

public class GetUserIamByIdQueryHandler: IRequestHandler<GetUserIamByIdQuery, UserIamDto?>
{
    public  GetUserIamByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<UserIamDto?> Handle(GetUserIamByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.UserIams
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}