﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Currency = SampleWebApp.Domain.Currency;

namespace SampleWebApp.Application.Commands;

public record DeleteCurrencyByIdCommand(System.UInt32 keyId, System.Guid? Etag) : IRequest<bool>;

public class DeleteCurrencyByIdCommandHandler: CommandBase<DeleteCurrencyByIdCommand,Currency>, IRequestHandler<DeleteCurrencyByIdCommand, bool>
{
	public SampleWebAppDbContext DbContext { get; }

	public DeleteCurrencyByIdCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCurrencyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nuid>("Id", request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}