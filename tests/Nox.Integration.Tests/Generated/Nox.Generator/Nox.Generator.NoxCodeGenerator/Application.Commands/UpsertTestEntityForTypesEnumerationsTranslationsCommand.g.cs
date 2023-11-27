// Generated

#nullable enable

using MediatR;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Exceptions;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;
public partial record  UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand(IEnumerable<TestEntityForTypesEnumerationTestFieldLocalizedDto> TestEntityForTypesEnumerationTestFieldLocalizedDtos) : IRequest<IEnumerable<TestEntityForTypesEnumerationTestFieldLocalizedDto>>;

internal partial class UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler : UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase
{
	public UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase : CommandBase<UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand, TestEntityForTypesEnumerationTestFieldLocalized>, IRequestHandler<UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand, IEnumerable<TestEntityForTypesEnumerationTestFieldLocalizedDto>>
{
	public AppDbContext DbContext { get; }

	public UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<IEnumerable<TestEntityForTypesEnumerationTestFieldLocalizedDto>> Handle(UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		if(command.TestEntityForTypesEnumerationTestFieldLocalizedDtos == null || command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.Count() == 0)
		{
			throw new ArgumentNullException($"No {nameof(command.TestEntityForTypesEnumerationTestFieldLocalizedDtos)} found.");
		}
		
		var cultureCode = command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.First().CultureCode;
		var supportedCultureCodes = NoxSolution.Application?.Localization?.SupportedCultures?.ToHashSet();
		var cultureCodeValue = Nox.Types.CultureCode.From(cultureCode);
		
		if (supportedCultureCodes == null || !supportedCultureCodes.Contains(cultureCode))
		{
			throw new CultureCodeNotSupportedException($"Culture code {cultureCode} not supported.");
		}
		
		if (!command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.All(x => x.CultureCode == cultureCode))
		{
			throw new CultureCodeMismatchException($"Culture code {cultureCode} does not match.");
		}
		
		var ids = command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.Select(dto=> dto.Id).ToList();
		var query =
			from Enum in DbContext.TestEntityForTypesEnumerationTestFields
			join localized in DbContext.TestEntityForTypesEnumerationTestFieldsLocalized
				on  new {Id = Enum.Id, Culture = cultureCodeValue}  equals new  {Id = localized.Id, Culture = localized.CultureCode} into localizedEnumsJoin
			from LocalizedEnum in localizedEnumsJoin.DefaultIfEmpty()
			select new { Enum.Id, LocalizedId = LocalizedEnum.Id };
		
		
		var queryResult = await query.AsNoTracking().ToListAsync(cancellationToken);
			
		if(!(queryResult.Count == ids.Count && queryResult.All(x=> ids.Contains(x.Id.Value))))
		{
			throw new InvalidEnumIdsException($"Provided ids are invalid for {nameof(DbContext.TestEntityForTypesEnumerationTestFields)}.");
		}
		
		var localizedEntities = 
			command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.Select(dto => new TestEntityForTypesEnumerationTestFieldLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = cultureCodeValue, Name = dto.Name}).ToList();

		if (queryResult.First().LocalizedId == null)
		{
			DbContext.TestEntityForTypesEnumerationTestFieldsLocalized.AddRange(localizedEntities);
		}
		else
		{
			localizedEntities.ForEach(e=> DbContext.Entry(e).State = EntityState.Modified);
		}

		if (NoxSolution.Application?.Localization?.DefaultCulture == cultureCode)
		{
			command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.ForEach(dto =>
			{
				var e = new TestEntityForTypesEnumerationTestField { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };
				DbContext.Entry(e).State = EntityState.Modified;
			});
		}

		await OnBatchCompletedAsync(command, localizedEntities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return command.TestEntityForTypesEnumerationTestFieldLocalizedDtos;
	}
}