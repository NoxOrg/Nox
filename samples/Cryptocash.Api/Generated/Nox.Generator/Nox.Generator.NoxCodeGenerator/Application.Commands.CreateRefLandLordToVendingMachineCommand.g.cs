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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateRefLandLordToVendingMachineCommand(LandLordKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefLandLordToVendingMachineCommandHandler: CommandBase<CreateRefLandLordToVendingMachineCommand, LandLord>, 
	IRequestHandler <CreateRefLandLordToVendingMachineCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefLandLordToVendingMachineCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefLandLordToVendingMachineCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<LandLord,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<VendingMachine,DatabaseGuid>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}		
		entity.VendingMachines.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}