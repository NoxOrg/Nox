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
public record CreateHolidaysCommand(HolidaysCreateDto EntityDto) : IRequest<HolidaysKeyDto>;

public partial class CreateHolidaysCommandHandler: CommandBase<CreateHolidaysCommand,Holidays>, IRequestHandler <CreateHolidaysCommand, HolidaysKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<HolidaysCreateDto,Holidays> EntityFactory { get; }

	public CreateHolidaysCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<HolidaysCreateDto,Holidays> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<HolidaysKeyDto> Handle(CreateHolidaysCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.Holidays.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new HolidaysKeyDto(entityToCreate.Id.Value);
	}
}