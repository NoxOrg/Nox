﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Commands;

public partial record DeleteCurrencyByIdCommand(IEnumerable<CurrencyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCurrencyByIdCommandHandler : DeleteCurrencyByIdCommandHandlerBase
{
	public DeleteCurrencyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCurrencyByIdCommandHandlerBase : CommandCollectionBase<DeleteCurrencyByIdCommand, CurrencyEntity>, IRequestHandler<DeleteCurrencyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCurrencyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCurrencyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CurrencyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CurrencyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<CurrencyEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CurrencyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}