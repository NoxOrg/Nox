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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;
using Holidays = CryptocashApi.Domain.Holidays;

namespace CryptocashApi.Application.Commands;
public record CreateHolidaysCommand(HolidaysCreateDto EntityDto) : IRequest<HolidaysKeyDto>;

public partial class CreateHolidaysCommandHandler: CommandBase<CreateHolidaysCommand,Holidays>, IRequestHandler <CreateHolidaysCommand, HolidaysKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<HolidaysCreateDto,Holidays> EntityFactory { get; }

	public CreateHolidaysCommandHandler(
		CryptocashApiDbContext dbContext,
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