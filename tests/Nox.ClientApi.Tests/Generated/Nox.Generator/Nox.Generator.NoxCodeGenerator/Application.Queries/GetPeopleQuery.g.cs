// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record GetPeopleQuery() : IRequest<IQueryable<PersonDto>>;

internal partial class GetPeopleQueryHandler: GetPeopleQueryHandlerBase
{
    public GetPeopleQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetPeopleQueryHandlerBase : QueryBase<IQueryable<PersonDto>>, IRequestHandler<GetPeopleQuery, IQueryable<PersonDto>>
{
    public  GetPeopleQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<PersonDto>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<PersonDto>()
            .Include(e => e.UserContactSelection);
       return Task.FromResult(OnResponse(query));
    }
}