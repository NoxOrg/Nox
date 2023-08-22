﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record CreateStoreSecurityPasswordsCommand(StoreSecurityPasswordsCreateDto EntityDto) : IRequest<StoreSecurityPasswordsKeyDto>;

public class CreateStoreSecurityPasswordsCommandHandler: IRequestHandler<CreateStoreSecurityPasswordsCommand, StoreSecurityPasswordsKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> EntityFactory { get; }

	public CreateStoreSecurityPasswordsCommandHandler(
		SampleWebAppDbContext dbContext,
		IEntityFactory<StoreSecurityPasswordsCreateDto,StoreSecurityPasswords> entityFactory)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<StoreSecurityPasswordsKeyDto> Handle(CreateStoreSecurityPasswordsCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.StoreSecurityPasswords.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreSecurityPasswordsKeyDto(entityToCreate.Id.Value);
	}
}