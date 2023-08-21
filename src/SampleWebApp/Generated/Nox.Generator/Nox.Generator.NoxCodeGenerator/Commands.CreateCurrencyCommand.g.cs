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
public record CreateCurrencyResponse(System.UInt32 keyId);

public record CreateCurrencyCommand(CurrencyCreateDto EntityDto) : IRequest<CreateCurrencyResponse>;

public class CreateCurrencyCommandHandler: IRequestHandler<CreateCurrencyCommand, CreateCurrencyResponse>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }
    public IEntityFactory<CurrencyCreateDto,Currency> EntityFactory { get; }

    public  CreateCurrencyCommandHandler(
        SampleWebAppDbContext dbContext,
        IEntityFactory<CurrencyCreateDto,Currency> entityFactory,
        IUserProvider userProvider,
        ISystemProvider systemProvider)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<CreateCurrencyResponse> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = CreateEntity(request);
	
        DbContext.Currencies.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return new CreateCurrencyResponse(default(System.UInt32)!);
    }

    private Currency CreateEntity(CreateCurrencyCommand request)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto); 
		entityToCreate.EnsureId();
        
        var createdBy = _userProvider.GetUser();
        var createdVia = _systemProvider.GetSystem();
        entityToCreate.Created(createdBy, createdVia);

        return entityToCreate;
    }
}