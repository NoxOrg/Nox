// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = TestWebApp.Application.Dto;

namespace TestWebApp.Application.Queries;
public partial record GetTestEntityForTypesEnumerationTestFieldsTranslationsQuery() : IRequest<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>;

internal partial class GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandler: GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandlerBase
{
    public GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>, IRequestHandler<GetTestEntityForTypesEnumerationTestFieldsTranslationsQuery, IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>
{
    public  GetTestEntityForTypesEnumerationTestFieldsTranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>> Handle(GetTestEntityForTypesEnumerationTestFieldsTranslationsQuery request, CancellationToken cancellationToken)
    {       
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>();
        return Task.FromResult(OnResponse(queryBuilder));       
    }  
}