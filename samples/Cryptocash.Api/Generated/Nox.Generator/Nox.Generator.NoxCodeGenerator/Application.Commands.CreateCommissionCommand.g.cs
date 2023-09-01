﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Commission = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;
public record CreateCommissionCommand(CommissionCreateDto EntityDto) : IRequest<CommissionKeyDto>;

public partial class CreateCommissionCommandHandler: CommandBase<CreateCommissionCommand,Commission>, IRequestHandler <CreateCommissionCommand, CommissionKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CommissionCreateDto,Commission> EntityFactory { get; }

	public CreateCommissionCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CommissionCreateDto,Commission> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CommissionKeyDto> Handle(CreateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.Commissions.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CommissionKeyDto(entityToCreate.Id.Value);
	}
}