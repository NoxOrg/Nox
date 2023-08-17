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
public record CreateCurrencyResponse(System.UInt32 keyId);

public record CreateCurrencyCommand(CurrencyCreateDto EntityDto) : IRequest<CreateCurrencyResponse>;

public class CreateCurrencyCommandHandler: IRequestHandler<CreateCurrencyCommand, CreateCurrencyResponse>
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
    
    public async Task<CreateCurrencyResponse> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto); 
		entityToCreate.EnsureId();
	
        DbContext.Currencies.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return new CreateCurrencyResponse(default(System.UInt32)!);
}
}