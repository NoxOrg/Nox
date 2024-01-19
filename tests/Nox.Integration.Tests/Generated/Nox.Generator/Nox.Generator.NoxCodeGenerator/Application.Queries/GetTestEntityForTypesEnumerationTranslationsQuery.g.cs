// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;

using DtoNameSpace = TestWebApp.Application.Dto;
using PersistenceNameSpace = TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;
public partial record GetTestEntityForTypesEnumerationTestFieldsTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>;

internal partial class GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandler: GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandlerBase
{
    public GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>, IRequestHandler<GetTestEntityForTypesEnumerationTestFieldsTranslationsQuery, IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>
{
    public  GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>> Handle(GetTestEntityForTypesEnumerationTestFieldsTranslationsQuery request, CancellationToken cancellationToken)
    {
       
        var queryBuilder = DataDbContext.TestEntityForTypesEnumerationTestFieldsLocalized
            .AsNoTracking<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));
       
    }  
}