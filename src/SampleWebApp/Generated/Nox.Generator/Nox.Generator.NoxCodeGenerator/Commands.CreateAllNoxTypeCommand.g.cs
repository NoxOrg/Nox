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
public record CreateAllNoxTypeCommand(AllNoxTypeCreateDto EntityDto) : IRequest<AllNoxTypeKeyDto>;

public class CreateAllNoxTypeCommandHandler: IRequestHandler<CreateAllNoxTypeCommand, AllNoxTypeKeyDto>
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

    public async Task<AllNoxTypeKeyDto> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

        DbContext.AllNoxTypes.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return new AllNoxTypeKeyDto(entityToCreate.Id.Value, entityToCreate.TextId.Value);
    }
}