// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;


namespace SampleWebApp.Application.Commands;

public record UpdateCurrencyCommand(CurrencyDto EntityDto) : IRequest;

public class UpdateCurrencyCommandHandler: CommandBase, IRequestHandler<UpdateCurrencyCommand>
{
    public SampleWebAppDbContext DbContext { get; }    

    public  UpdateCurrencyCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(10);
        return;
        //var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        ////TODO for nuid property or key needs to call ensure id        
        //DbContext.Currencies.Add(entityToCreate);
        //await DbContext.SaveChangesAsync();
        //return entityToCreate.Id;
    }
}