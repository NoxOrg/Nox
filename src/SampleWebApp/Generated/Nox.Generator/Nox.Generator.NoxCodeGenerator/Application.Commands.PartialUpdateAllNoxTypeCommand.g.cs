﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;
using AllNoxType = SampleWebApp.Domain.AllNoxType;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateAllNoxTypeCommand(System.Int64 keyId, System.String keyTextId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <AllNoxTypeKeyDto?>;

public class PartialUpdateAllNoxTypeCommandHandler: CommandBase<PartialUpdateAllNoxTypeCommand, AllNoxType>, IRequestHandler<PartialUpdateAllNoxTypeCommand, AllNoxTypeKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<AllNoxType> EntityMapper { get; }

	public PartialUpdateAllNoxTypeCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<AllNoxType> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<AllNoxTypeKeyDto?> Handle(PartialUpdateAllNoxTypeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<AllNoxType,DatabaseNumber>("Id", request.keyId);
		var keyTextId = CreateNoxTypeForKey<AllNoxType,Text>("TextId", request.keyTextId);

		var entity = await DbContext.AllNoxTypes.FindAsync(keyId, keyTextId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<AllNoxType>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new AllNoxTypeKeyDto(entity.Id.Value, entity.TextId.Value);
	}
}