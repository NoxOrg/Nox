﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;

public record UpdateAllNoxTypeCommand(System.Int64 keyId, System.String keyTextId, AllNoxTypeUpdateDto EntityDto) : IRequest<AllNoxTypeKeyDto?>;

public class UpdateAllNoxTypeCommandHandler: CommandBase<UpdateAllNoxTypeCommand>, IRequestHandler<UpdateAllNoxTypeCommand, AllNoxTypeKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<AllNoxType> EntityMapper { get; }

	public UpdateAllNoxTypeCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<AllNoxType> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}
	
	public async Task<AllNoxTypeKeyDto?> Handle(UpdateAllNoxTypeCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<AllNoxType,DatabaseNumber>("Id", request.keyId);
		var keyTextId = CreateNoxTypeForKey<AllNoxType,Text>("TextId", request.keyTextId);
	
		var entity = await DbContext.AllNoxTypes.FindAsync(keyId, keyTextId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<AllNoxType>(), request.EntityDto);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new AllNoxTypeKeyDto(entity.Id.Value, entity.TextId.Value);
	}
}