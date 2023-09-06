﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;
using AllNoxType = SampleWebApp.Domain.AllNoxType;

namespace SampleWebApp.Application.Commands;

public record UpdateAllNoxTypeCommand(System.Int64 keyId, System.String keyTextId, AllNoxTypeUpdateDto EntityDto) : IRequest<AllNoxTypeKeyDto?>;

public class UpdateAllNoxTypeCommandHandler: CommandBase<UpdateAllNoxTypeCommand, AllNoxType>, IRequestHandler<UpdateAllNoxTypeCommand, AllNoxTypeKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<AllNoxType> EntityMapper { get; }

	public UpdateAllNoxTypeCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<AllNoxType> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<AllNoxTypeKeyDto?> Handle(UpdateAllNoxTypeCommand request, CancellationToken cancellationToken)
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
		EntityMapper.MapToEntity(entity, GetEntityDefinition<AllNoxType>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new AllNoxTypeKeyDto(entity.Id.Value, entity.TextId.Value);
	}
}