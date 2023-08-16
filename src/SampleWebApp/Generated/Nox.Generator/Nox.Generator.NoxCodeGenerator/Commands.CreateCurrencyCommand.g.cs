// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateCurrencyCommand(CurrencyCreateDto EntityDto) : IRequest<System.UInt32>;

public class CreateCurrencyCommandHandler: IRequestHandler<CreateCurrencyCommand, System.UInt32>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CurrencyCreateDto,Currency> EntityFactory { get; }

    public  CreateCurrencyCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CurrencyCreateDto,Currency> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<System.UInt32> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto); 
		entityToCreate.EnsureId();
	
        DbContext.Currencies.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return default(System.UInt32)!;
}
}