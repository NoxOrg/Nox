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
using Holiday = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Commands;
public record AddHolidayCommand(CountryKeyDto ParentKeyDto, HolidayCreateDto EntityDto) : IRequest <HolidayKeyDto?>;

public partial class AddHolidayCommandHandler: CommandBase<AddHolidayCommand, Holiday>, IRequestHandler <AddHolidayCommand, HolidayKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Holiday,HolidayCreateDto> _entityFactory;

	public AddHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Holiday,HolidayCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public async Task<HolidayKeyDto?> Handle(AddHolidayCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.Holidays.Add(entity);

		OnCompleted(entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new HolidayKeyDto(entity.Id.Value);
	}
}