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
public record DeleteCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteCountryBarCodeForCountryCommandHandler : DeleteCountryBarCodeForCountryCommandHandlerBase
{
	public DeleteCountryBarCodeForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution, serviceProvider)
	{
	}
}

internal partial class DeleteCountryBarCodeForCountryCommandHandlerBase : CommandBase<DeleteCountryBarCodeForCountryCommand, CountryBarCode>, IRequestHandler <DeleteCountryBarCodeForCountryCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteCountryBarCodeForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var entity = parentEntity.CountryBarCode;
		if (entity == null)
		{
			return false;
		}

		parentEntity.CountryBarCode = null;

		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}