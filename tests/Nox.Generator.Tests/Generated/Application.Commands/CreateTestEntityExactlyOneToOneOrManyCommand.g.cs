// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityExactlyOneToOneOrManyCommand(TestEntityExactlyOneToOneOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityExactlyOneToOneOrManyKeyDto>;

internal partial class CreateTestEntityExactlyOneToOneOrManyCommandHandler : CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase
{
	public CreateTestEntityExactlyOneToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> TestEntityOneOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityOneOrManyToExactlyOneFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase : CommandBase<CreateTestEntityExactlyOneToOneOrManyCommand,TestEntityExactlyOneToOneOrManyEntity>, IRequestHandler <CreateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> TestEntityOneOrManyToExactlyOneFactory;

	public CreateTestEntityExactlyOneToOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> TestEntityOneOrManyToExactlyOneFactory,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityOneOrManyToExactlyOneFactory = TestEntityOneOrManyToExactlyOneFactory;
	}

	public virtual async Task<TestEntityExactlyOneToOneOrManyKeyDto> Handle(CreateTestEntityExactlyOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityOneOrManyToExactlyOneId is not null)
		{
			var relatedKey = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityOneOrManyToExactlyOneId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToExactlyOne", request.EntityDto.TestEntityOneOrManyToExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.TestEntityOneOrManyToExactlyOne is not null)
		{
			var relatedEntity = TestEntityOneOrManyToExactlyOneFactory.CreateEntity(request.EntityDto.TestEntityOneOrManyToExactlyOne);
			entityToCreate.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityExactlyOneToOneOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityExactlyOneToOneOrManyKeyDto(entityToCreate.Id.Value);
	}
}