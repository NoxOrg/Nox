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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryLocalName = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public record AddCountryLocalNameCommand(CountryKeyDto ParentKeyDto, CountryLocalNameCreateDto EntityDto, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto?>;

public partial class AddCountryLocalNameCommandHandler: CommandBase<AddCountryLocalNameCommand, CountryLocalName>, IRequestHandler <AddCountryLocalNameCommand, CountryLocalNameKeyDto?>
{
	public ClientApiDbContext DbContext { get; }

	public AddCountryLocalNameCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;		
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

		var entity = request.EntityDto.ToEntity();
		
		parentEntity.CountryLocalNames.Add(entity);
		parentEntity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;
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