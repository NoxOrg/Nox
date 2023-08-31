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

namespace Cryptocash.Application.Commands;
public record CreateBankNotesCommand(BankNotesCreateDto EntityDto) : IRequest<BankNotesKeyDto>;

public partial class CreateBankNotesCommandHandler: CommandBase<CreateBankNotesCommand,BankNotes>, IRequestHandler <CreateBankNotesCommand, BankNotesKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<BankNotesCreateDto,BankNotes> EntityFactory { get; }

	public CreateBankNotesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<BankNotesCreateDto,BankNotes> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<BankNotesKeyDto> Handle(CreateBankNotesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.BankNotes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new BankNotesKeyDto(entityToCreate.Id.Value);
	}
}