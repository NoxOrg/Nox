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
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateSecondTestEntityZeroOrOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityZeroOrOneKeyDto>;

internal partial class PartialUpdateSecondTestEntityZeroOrOneCommandHandler : PartialUpdateSecondTestEntityZeroOrOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityZeroOrOneCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneEntity>, IRequestHandler<PartialUpdateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateSecondTestEntityZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrOneKeyDto> Handle(PartialUpdateSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.SecondTestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityZeroOrOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new SecondTestEntityZeroOrOneKeyDto(entity.Id.Value);
	}
}