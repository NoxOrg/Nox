// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = TestWebApp.Application.Dto;
using PersistenceNameSpace = TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;
public partial record GetTestEntityForTypesEnumerationTestFieldsQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>;

internal partial class GetTestEntityForTypesEnumerationTestFieldsQueryHandler: GetTestEntityForTypesEnumerationTestFieldsQueryHandlerBase
{
    public GetTestEntityForTypesEnumerationTestFieldsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForTypesEnumerationTestFieldsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>, IRequestHandler<GetTestEntityForTypesEnumerationTestFieldsQuery, IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>
{
    public  GetTestEntityForTypesEnumerationTestFieldsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>> Handle(GetTestEntityForTypesEnumerationTestFieldsQuery request, CancellationToken cancellationToken)
    {
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto> queryBuilder =
            from enumValues in ReadOnlyRepository.Query<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>()
            from enumLocalized in ReadOnlyRepository.Query<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == cultureCode).DefaultIfEmpty()
            select new DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? "[" + enumValues.Name + "]",
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
    }
}