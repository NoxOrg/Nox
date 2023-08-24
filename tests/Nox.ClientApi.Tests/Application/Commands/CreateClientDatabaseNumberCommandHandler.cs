using Nox.Application.Commands;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using MediatR;

namespace ClientApi.Application.Commands;

    /// <summary>
    /// Example to extend a Nox command and change a request
    /// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientDatabaseNumberCommand>.
    /// </summary>
    public partial class CreateClientDatabaseNumberCommandHandler 
    {
        protected override void OnExecuting(CreateClientDatabaseNumberCommand request, CancellationToken cancellationToken)
        {
            if (request.EntityDto.Number < 0)
            {
                request.EntityDto.Number = 0;
            }
            base.OnExecuting(request, cancellationToken);
        }
    }

