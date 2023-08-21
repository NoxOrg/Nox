// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Factories;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateCurrencyCashBalanceResponse(System.String keyStoreId, System.UInt32 keyCurrencyId);

public record CreateCurrencyCashBalanceCommand(CurrencyCashBalanceCreateDto EntityDto) : IRequest<CreateCurrencyCashBalanceResponse>;

public class CreateCurrencyCashBalanceCommandHandler: IRequestHandler<CreateCurrencyCashBalanceCommand, CreateCurrencyCashBalanceResponse>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> EntityFactory { get; }

    public  CreateCurrencyCashBalanceCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CurrencyCashBalanceCreateDto,CurrencyCashBalance> entityFactory,
        IUserProvider userProvider,
        ISystemProvider systemProvider)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<CreateCurrencyCashBalanceResponse> Handle(CreateCurrencyCashBalanceCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = CreateEntity(request);
	
        DbContext.CurrencyCashBalances.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.StoreId.Value;
        return new CreateCurrencyCashBalanceResponse(default(System.String)!, default(System.UInt32)!);
    }

    private CurrencyCashBalance CreateEntity(CreateCurrencyCashBalanceCommand request)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
        
        var createdBy = _userProvider.GetUser();
        var createdVia = _systemProvider.GetSystem();
        entityToCreate.Created(createdBy, createdVia);

        return entityToCreate;
    }
}