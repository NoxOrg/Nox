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
public record CreateCurrencyCashBalanceResponse(System.String keyStoreId, System.UInt32 keyCurrencyId);

public record CreateCurrencyCashBalanceCommand(CurrencyCashBalanceCreateDto EntityDto) : IRequest<CreateCurrencyCashBalanceResponse>;

public class CreateCurrencyCashBalanceCommandHandler: IRequestHandler<CreateCurrencyCashBalanceCommand, CreateCurrencyCashBalanceResponse>
{
    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> EntityFactory { get; }

    public  CreateCurrencyCashBalanceCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<CreateCurrencyCashBalanceResponse> Handle(CreateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.CurrencyCashBalances.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.StoreId.Value;
        return new CreateCurrencyCashBalanceResponse(default(System.String)!, default(System.UInt32)!);
}
}