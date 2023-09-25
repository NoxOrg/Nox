using FluentValidation;
using MediatR;
using ClientApi.Application.Queries;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

/// <summary>
/// Example of a security filter for Get All Entities. Uses the IQueryable to add additional filters to the result
/// Executed after the default handler updating the result with a filter
/// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientAutoNumberCommand>.
/// </summary>
internal partial class GetCountriesQueryHandler
{
    protected override IQueryable<CountryDto> OnResponse(IQueryable<CountryDto> response)
    {
          return response.Where(country => country.Id < 50);
    }
}

