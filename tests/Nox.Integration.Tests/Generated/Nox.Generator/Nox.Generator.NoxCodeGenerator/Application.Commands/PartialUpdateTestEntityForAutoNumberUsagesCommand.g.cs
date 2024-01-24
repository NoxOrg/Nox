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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityForAutoNumberUsagesCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityForAutoNumberUsagesKeyDto>;

internal partial class PartialUpdateTestEntityForAutoNumberUsagesCommandHandler : PartialUpdateTestEntityForAutoNumberUsagesCommandHandlerBase
{
	public PartialUpdateTestEntityForAutoNumberUsagesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityForAutoNumberUsagesCommandHandlerBase : CommandBase<PartialUpdateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesEntity>, IRequestHandler<PartialUpdateTestEntityForAutoNumberUsagesCommand, TestEntityForAutoNumberUsagesKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityForAutoNumberUsagesCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForAutoNumberUsagesKeyDto> Handle(PartialUpdateTestEntityForAutoNumberUsagesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityForAutoNumberUsagesMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityForAutoNumberUsages>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityForAutoNumberUsages",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityForAutoNumberUsagesKeyDto(entity.Id.Value);
	}
}