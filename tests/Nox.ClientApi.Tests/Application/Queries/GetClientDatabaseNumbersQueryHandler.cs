using FluentValidation;
using MediatR;
using ClientApi.Application.Queries;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Queries;

/// <summary>
/// Example of a security filter for Get All Entities. Uses the IQueryable to add additional filters to the result
/// Executed after the default handler updating the result with a filter
/// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientDatabaseNumberCommand>.
/// </summary>
public partial class GetClientDatabaseNumbersQueryHandler
{
    protected override IQueryable<ClientDatabaseNumberDto> OnResponse(IQueryable<ClientDatabaseNumberDto> response)
    {
          return response.Where(client => client.Id < 50);
    }
}

