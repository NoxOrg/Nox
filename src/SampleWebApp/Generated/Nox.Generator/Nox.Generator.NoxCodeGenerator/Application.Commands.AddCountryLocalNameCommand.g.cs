﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record AddCountryLocalNameCommand(CountryKeyDto ParentKeyDto, CountryLocalNameCreateDto EntityDto) : IRequest <CountryLocalNameKeyDto?>;

public partial class AddCountryLocalNameCommandHandler: CommandBase<AddCountryLocalNameCommand, CountryLocalName>, IRequestHandler <AddCountryLocalNameCommand, CountryLocalNameKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<CountryLocalNameCreateDto,CountryLocalName> EntityFactory { get; }

	public AddCountryLocalNameCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryLocalNameCreateDto,CountryLocalName> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CountryLocalNameKeyDto?> Handle(AddCountryLocalNameCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,DatabaseNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = EntityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.CountryLocalNames.Add(entity);

		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}