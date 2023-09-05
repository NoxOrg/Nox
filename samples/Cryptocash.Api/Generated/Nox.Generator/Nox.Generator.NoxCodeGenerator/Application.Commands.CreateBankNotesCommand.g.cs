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
using BankNotes = Cryptocash.Domain.BankNotes;

namespace Cryptocash.Application.Commands;
public record CreateBankNotesCommand(BankNotesCreateDto EntityDto) : IRequest<BankNotesKeyDto>;

public partial class CreateBankNotesCommandHandler: CommandBase<CreateBankNotesCommand,BankNotes>, IRequestHandler <CreateBankNotesCommand, BankNotesKeyDto>
{
	public CryptocashDbContext DbContext { get; }

	public CreateBankNotesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<BankNotesKeyDto> Handle(CreateBankNotesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();
	
		OnCompleted(entityToCreate);
		DbContext.BankNotes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new BankNotesKeyDto(entityToCreate.Id.Value);
	}
}