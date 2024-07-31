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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityZeroOrOneToExactlyOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityZeroOrOneToExactlyOneKeyDto>;

internal partial class PartialUpdateTestEntityZeroOrOneToExactlyOneCommandHandler : PartialUpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase
{
	public PartialUpdateTestEntityZeroOrOneToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneEntity>, IRequestHandler<PartialUpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToExactlyOneKeyDto> Handle(PartialUpdateTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrOneToExactlyOneKeyDto(entity.Id.Value);
	}
}