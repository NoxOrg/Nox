// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Commands;

public record CreateAllNoxTypeCommand() : IRequest<OAllNoxType>;

public class CreateAllNoxTypeCommandHandler: IRequestHandler<CreateAllNoxTypeCommand, OAllNoxType>
{
    public  CreateAllNoxTypeCommandHandler(SampleWebAppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public SampleWebAppDbContext DbContext { get; }

    public async Task<OAllNoxType> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {       
        await Task.Delay(1000);
        return default(OAllNoxType)!;
    }
}