﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record UpdateThirdTestEntityZeroOrOneCommand(System.String keyId, ThirdTestEntityZeroOrOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ThirdTestEntityZeroOrOneKeyDto?>;

internal partial class UpdateThirdTestEntityZeroOrOneCommandHandler : UpdateThirdTestEntityZeroOrOneCommandHandlerBase
{
	public UpdateThirdTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateThirdTestEntityZeroOrOneCommandHandlerBase : CommandBase<UpdateThirdTestEntityZeroOrOneCommand, ThirdTestEntityZeroOrOneEntity>, IRequestHandler<UpdateThirdTestEntityZeroOrOneCommand, ThirdTestEntityZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> _entityFactory;

	public UpdateThirdTestEntityZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityZeroOrOneKeyDto?> Handle(UpdateThirdTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.ThirdTestEntityExactlyOneId is not null)
		{
			var thirdTestEntityExactlyOneKey = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateId(request.EntityDto.ThirdTestEntityExactlyOneId.NonNullValue<System.String>());
			var thirdTestEntityExactlyOneEntity = await DbContext.ThirdTestEntityExactlyOnes.FindAsync(thirdTestEntityExactlyOneKey);
						
			if(thirdTestEntityExactlyOneEntity is not null)
				entity.CreateRefToThirdTestEntityExactlyOne(thirdTestEntityExactlyOneEntity);
			else
				throw new RelatedEntityNotFoundException("ThirdTestEntityExactlyOne", request.EntityDto.ThirdTestEntityExactlyOneId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToThirdTestEntityExactlyOne();
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ThirdTestEntityZeroOrOneKeyDto(entity.Id.Value);
	}
}