﻿﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateCurrencyBankNotesCommand(CurrencyBankNotesCreateDto EntityDto) : IRequest<CurrencyBankNotesKeyDto>;

public partial class CreateCurrencyBankNotesCommandHandler: CommandBase<CreateCurrencyBankNotesCommand>, IRequestHandler <CreateCurrencyBankNotesCommand, CurrencyBankNotesKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<CurrencyBankNotesCreateDto,CurrencyBankNotes> EntityFactory { get; }

	public CreateCurrencyBankNotesCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CurrencyBankNotesCreateDto,CurrencyBankNotes> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CurrencyBankNotesKeyDto> Handle(CreateCurrencyBankNotesCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.CurrencyBankNotes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyBankNotesKeyDto(entityToCreate.Id.Value);
	}
}