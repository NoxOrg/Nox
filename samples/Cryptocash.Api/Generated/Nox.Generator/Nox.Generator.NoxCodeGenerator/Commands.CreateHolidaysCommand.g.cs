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

namespace CryptocashApi.Application.Commands;
public record CreateHolidaysCommand(HolidaysCreateDto EntityDto) : IRequest<HolidaysKeyDto>;

public partial class CreateHolidaysCommandHandler: CommandBase<CreateHolidaysCommand>, IRequestHandler <CreateHolidaysCommand, HolidaysKeyDto>
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
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.Holidays.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new HolidaysKeyDto(entityToCreate.Id.Value);
	}
}