// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityWithNuidCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityWithNuidKeyDto>;

internal partial class PartialUpdateTestEntityWithNuidCommandHandler : PartialUpdateTestEntityWithNuidCommandHandlerBase
{
	public PartialUpdateTestEntityWithNuidCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityWithNuidCommandHandlerBase : CommandBase<PartialUpdateTestEntityWithNuidCommand, TestEntityWithNuidEntity>, IRequestHandler<PartialUpdateTestEntityWithNuidCommand, TestEntityWithNuidKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityWithNuidCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityWithNuidKeyDto> Handle(PartialUpdateTestEntityWithNuidCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityWithNuidMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityWithNuid>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityWithNuid",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityWithNuidKeyDto(entity.Id.Value);
	}
}