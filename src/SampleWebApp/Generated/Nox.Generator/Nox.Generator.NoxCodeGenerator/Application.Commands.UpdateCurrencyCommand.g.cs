﻿﻿// Generated

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
using Currency = SampleWebApp.Domain.Currency;

namespace SampleWebApp.Application.Commands;

public record UpdateCurrencyCommand(System.UInt32 keyId, CurrencyUpdateDto EntityDto, System.Guid? Etag) : IRequest<CurrencyKeyDto?>;

public class UpdateCurrencyCommandHandler: CommandBase<UpdateCurrencyCommand, Currency>, IRequestHandler<UpdateCurrencyCommand, CurrencyKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<Currency> EntityMapper { get; }

	public UpdateCurrencyCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Currency> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CurrencyKeyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nuid>("Id", request.keyId);
	
		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Currency>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CurrencyKeyDto(entity.Id.Value);
	}
}