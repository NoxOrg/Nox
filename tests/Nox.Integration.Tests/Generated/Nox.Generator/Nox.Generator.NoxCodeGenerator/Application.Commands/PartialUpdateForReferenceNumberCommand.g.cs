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
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateForReferenceNumberCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ForReferenceNumberKeyDto>;

internal partial class PartialUpdateForReferenceNumberCommandHandler : PartialUpdateForReferenceNumberCommandHandlerBase
{
	public PartialUpdateForReferenceNumberCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateForReferenceNumberCommandHandlerBase : CommandBase<PartialUpdateForReferenceNumberCommand, ForReferenceNumberEntity>, IRequestHandler<PartialUpdateForReferenceNumberCommand, ForReferenceNumberKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> EntityFactory { get; }
	
	public PartialUpdateForReferenceNumberCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ForReferenceNumberKeyDto> Handle(PartialUpdateForReferenceNumberCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.ForReferenceNumberMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<ForReferenceNumber>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ForReferenceNumber",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new ForReferenceNumberKeyDto(entity.Id.Value);
	}
}