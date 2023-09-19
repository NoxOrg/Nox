﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;
public record UpdateCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, CountryBarCodeUpdateDto EntityDto, System.Guid? Etag) : IRequest <CountryBarCodeKeyDto?>;


public partial class UpdateCountryBarCodeForCountryCommandHandler: CommandBase<UpdateCountryBarCodeForCountryCommand, CountryBarCode>, IRequestHandler <UpdateCountryBarCodeForCountryCommand, CountryBarCodeKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<CountryBarCode> EntityMapper { get; }

	public UpdateCountryBarCodeForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryBarCode> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryBarCodeKeyDto?> Handle(UpdateCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var entity = parentEntity.CountryBarCode;
				
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryBarCode>(), request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryBarCodeKeyDto();
	}
}