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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityLocalizationCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityLocalizationKeyDto>;

internal partial class PartialUpdateTestEntityLocalizationCommandHandler : PartialUpdateTestEntityLocalizationCommandHandlerBase
{
	public PartialUpdateTestEntityLocalizationCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityLocalizationCommandHandlerBase : CommandBase<PartialUpdateTestEntityLocalizationCommand, TestEntityLocalizationEntity>, IRequestHandler<PartialUpdateTestEntityLocalizationCommand, TestEntityLocalizationKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityLocalizationCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityLocalizationKeyDto> Handle(PartialUpdateTestEntityLocalizationCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityLocalizationMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityLocalization>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityLocalization",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityLocalizationKeyDto(entity.Id.Value);
	}
}