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
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityForTypesCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityForTypesKeyDto>;

internal partial class PartialUpdateTestEntityForTypesCommandHandler : PartialUpdateTestEntityForTypesCommandHandlerBase
{
	public PartialUpdateTestEntityForTypesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityForTypesCommandHandlerBase : CommandBase<PartialUpdateTestEntityForTypesCommand, TestEntityForTypesEntity>, IRequestHandler<PartialUpdateTestEntityForTypesCommand, TestEntityForTypesKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityForTypesCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityForTypesKeyDto> Handle(PartialUpdateTestEntityForTypesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityForTypesMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityForTypes>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityForTypes",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityForTypesKeyDto(entity.Id.Value);
	}
}