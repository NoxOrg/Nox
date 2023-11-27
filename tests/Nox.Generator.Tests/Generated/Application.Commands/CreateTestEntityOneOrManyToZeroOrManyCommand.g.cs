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
using FluentValidation;
using Microsoft.Extensions.Logging;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record CreateTestEntityOneOrManyToZeroOrManyCommand(TestEntityOneOrManyToZeroOrManyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TestEntityOneOrManyToZeroOrManyKeyDto>;

internal partial class CreateTestEntityOneOrManyToZeroOrManyCommandHandler : CreateTestEntityOneOrManyToZeroOrManyCommandHandlerBase
{
	public CreateTestEntityOneOrManyToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> TestEntityZeroOrManyToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,TestEntityZeroOrManyToOneOrManyFactory, entityFactory)
	{
	}
}


internal abstract class CreateTestEntityOneOrManyToZeroOrManyCommandHandlerBase : CommandBase<CreateTestEntityOneOrManyToZeroOrManyCommand,TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler <CreateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrManyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> TestEntityZeroOrManyToOneOrManyFactory;

	public CreateTestEntityOneOrManyToZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> TestEntityZeroOrManyToOneOrManyFactory,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TestEntityZeroOrManyToOneOrManyFactory = TestEntityZeroOrManyToOneOrManyFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrManyKeyDto> Handle(CreateTestEntityOneOrManyToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.TestEntityZeroOrManyToOneOrManiesId.Any())
		{
			foreach(var relatedId in request.EntityDto.TestEntityZeroOrManyToOneOrManiesId)
			{
				var relatedKey = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToOneOrManies", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.TestEntityZeroOrManyToOneOrManies)
			{
				var relatedEntity = TestEntityZeroOrManyToOneOrManyFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.TestEntityOneOrManyToZeroOrManies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrManyKeyDto(entityToCreate.Id.Value);
	}
}