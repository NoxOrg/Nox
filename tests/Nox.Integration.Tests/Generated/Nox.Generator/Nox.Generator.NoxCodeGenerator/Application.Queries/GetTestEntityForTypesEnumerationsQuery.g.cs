// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = TestWebApp.Application.Dto;
using PersistenceNameSpace = TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;
public partial record GetTestEntityForTypesEnumerationTestFieldsQuery(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>;

internal partial class GetTestEntityForTypesEnumerationTestFieldsQueryHandler: GetTestEntityForTypesEnumerationTestFieldsQueryHandlerBase
{
    public GetTestEntityForTypesEnumerationTestFieldsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetTestEntityForTypesEnumerationTestFieldsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>, IRequestHandler<GetTestEntityForTypesEnumerationTestFieldsQuery, IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>
{
    public  GetTestEntityForTypesEnumerationTestFieldsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>> Handle(GetTestEntityForTypesEnumerationTestFieldsQuery request, CancellationToken cancellationToken)
    {
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto> queryBuilder =
            from enumValues in DataDbContext.TestEntityForTypesEnumerationTestFields.AsNoTracking()
            from enumLocalized in DataDbContext.TestEntityForTypesEnumerationTestFieldsLocalized.AsNoTracking()
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