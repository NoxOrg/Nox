using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

/// <summary>
/// Example of fully override and implement a default query handler
/// </summary>
public partial class GetCountryByIdQueryHandler
{
    public override Task<IQueryable<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        /* Fully Implement the handler if needed */
        return base.Handle(request, cancellationToken);
    }
}
