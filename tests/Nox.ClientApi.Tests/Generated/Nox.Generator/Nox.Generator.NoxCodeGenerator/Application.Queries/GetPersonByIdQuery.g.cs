// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

public partial record GetPersonByIdQuery(System.Guid keyId) : IRequest <IQueryable<PersonDto>>;

internal partial class GetPersonByIdQueryHandler:GetPersonByIdQueryHandlerBase
{
    public GetPersonByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPersonByIdQueryHandlerBase:  QueryBase<IQueryable<PersonDto>>, IRequestHandler<GetPersonByIdQuery, IQueryable<PersonDto>>
{
    public  GetPersonByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<PersonDto>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<PersonDto>()
            .Include(e => e.UserContactSelection)
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}