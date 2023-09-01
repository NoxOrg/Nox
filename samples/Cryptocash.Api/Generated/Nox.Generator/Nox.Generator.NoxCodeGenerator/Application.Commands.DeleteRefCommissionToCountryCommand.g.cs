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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record DeleteRefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto) : IRequest <bool>;

public partial class DeleteRefCommissionToCountryCommandHandler: CommandBase<DeleteRefCommissionToCountryCommand, Commission>, 
	IRequestHandler <DeleteRefCommissionToCountryCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefCommissionToCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefCommissionToCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Commission,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Commissions.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		entity.Country = null;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}