// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using Nox.Solution.Extensions;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateAllNoxTypeCommand(AllNoxTypeCreateDto EntityDto) : IRequest<System.Int64>;

public class CreateAllNoxTypeCommandHandler: IRequestHandler<CreateAllNoxTypeCommand, System.Int64>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<AllNoxTypeCreateDto,AllNoxType> EntityFactory { get; }

    public  CreateAllNoxTypeCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<AllNoxTypeCreateDto,AllNoxType> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<System.Int64> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.AllNoxTypes.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return default(System.Int64)!;
}
}