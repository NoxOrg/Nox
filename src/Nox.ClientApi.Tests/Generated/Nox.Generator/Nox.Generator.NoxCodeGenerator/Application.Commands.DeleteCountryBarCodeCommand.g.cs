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
public record DeleteCountryBarCodeCommand(CountryKeyDto ParentKeyDto) : IRequest <bool>;


public partial class DeleteCountryBarCodeCommandHandler: CommandBase<DeleteCountryBarCodeCommand, CountryBarCode>, IRequestHandler <DeleteCountryBarCodeCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteCountryBarCodeCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteCountryBarCodeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,AutoNumber>("Id", request.ParentKeyDto.keyId);
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