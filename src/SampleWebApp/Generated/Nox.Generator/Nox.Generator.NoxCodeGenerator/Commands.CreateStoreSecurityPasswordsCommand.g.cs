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
public record CreateStoreSecurityPasswordsCommand(StoreSecurityPasswordsCreateDto EntityDto) : IRequest<System.String>;

public class CreateStoreSecurityPasswordsCommandHandler: IRequestHandler<CreateStoreSecurityPasswordsCommand, System.String>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> EntityFactory { get; }

    public  CreateStoreSecurityPasswordsCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<System.String> Handle(CreateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.StoreSecurityPasswords.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return default(System.String)!;
}
}