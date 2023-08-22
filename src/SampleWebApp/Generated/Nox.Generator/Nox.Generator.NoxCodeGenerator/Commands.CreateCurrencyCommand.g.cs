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
public record CreateCurrencyCommand(CurrencyCreateDto EntityDto) : IRequest<CurrencyKeyDto>;

public class CreateCurrencyCommandHandler: IRequestHandler<CreateCurrencyCommand, CurrencyKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<CurrencyCreateDto,Currency> EntityFactory { get; }

	public CreateCurrencyCommandHandler(
		SampleWebAppDbContext dbContext,
		IEntityFactory<CurrencyCreateDto,Currency> entityFactory)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CurrencyKeyDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		entityToCreate.EnsureId();
	
		DbContext.Currencies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entityToCreate.Id.Value);
	}
}