using FluentValidation;
using MediatR;
using ClientApi.Application.Queries;
using ClientApi.Application.Dto;

namespace Nox.ClientApi.Tests.Application.Queries
{
    /// <summary>
    /// Example of a security filter for Get All Entities. Uses the IQueryable to add additional filters to the result
    /// Executed after the default handler updating the result with a filter
    /// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientDatabaseNumberCommand>.
    /// 
    /// </summary>
    public class GetClientDatabaseNumbersQuerySecurityFilter : IPipelineBehavior<GetClientDatabaseNumbersQuery, IQueryable<ClientDatabaseNumberDto>>
    {
        public async Task<IQueryable<ClientDatabaseNumberDto>> Handle(GetClientDatabaseNumbersQuery request, RequestHandlerDelegate<IQueryable<ClientDatabaseNumberDto>> next, CancellationToken cancellationToken)
        {
          var result = await next();

           return result.Where(client => client.Id < 50);
        }
    }
}