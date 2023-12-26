// Generated

#nullable enable

using MediatR;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Types.Abstractions.Extensions;
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
internal abstract class UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase : CommandCollectionBase<UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand, TestEntityForTypesEnumerationTestFieldLocalized>, IRequestHandler<UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand, IEnumerable<TestEntityForTypesEnumerationTestFieldLocalizedDto>>
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
		
		var cultureCodes = command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.DistinctBy(d=>d.CultureCode).Select(d=>CultureCode.From(d.CultureCode)).ToList();
		
		var localizedEntities = await DbContext.TestEntityForTypesEnumerationTestFieldsLocalized.Where(x => cultureCodes.Contains(x.CultureCode)).AsNoTracking().ToListAsync(cancellationToken);
		
		var entities = new List<TestEntityForTypesEnumerationTestFieldLocalized>();
		
		command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.Where(dto=> !localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new TestEntityForTypesEnumerationTestFieldLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Added;
			entities.Add(e);
		});
		
		command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.Where(dto=> localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new TestEntityForTypesEnumerationTestFieldLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Modified;
			entities.Add(e);
		});
		
		command.TestEntityForTypesEnumerationTestFieldLocalizedDtos.Where(dto=>dto.CultureCode == DefaultCultureCode.Value).ForEach(dto =>
		{
			var e = new TestEntityForTypesEnumerationTestField { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };
			DbContext.Entry(e).State = EntityState.Modified;
		});
		

		await OnCompletedAsync(command, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return command.TestEntityForTypesEnumerationTestFieldLocalizedDtos;
	}
}
public class UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandValidator : AbstractValidator<UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1, 2, 3, };
	
    public UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.TestEntityForTypesEnumerationTestFieldLocalizedDtos)
			.Must(x => x != null && x.Count() > 0)
			.WithMessage($"{nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand)} : {nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand.TestEntityForTypesEnumerationTestFieldLocalizedDtos)} is required.");
		
		RuleForEach(x => x.TestEntityForTypesEnumerationTestFieldLocalizedDtos)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.CultureCode))
			.WithMessage((_,x) => $"{nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand)} : {nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand.TestEntityForTypesEnumerationTestFieldLocalizedDtos)} contains unsupported culture code: {x.CultureCode}.");
		
		RuleForEach(x => x.TestEntityForTypesEnumerationTestFieldLocalizedDtos)
			.Must(x => _supportedIds.Contains(x.Id))
			.WithMessage((_,x) => $"{nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand)} : {nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand.TestEntityForTypesEnumerationTestFieldLocalizedDtos)} contains unsupported Id: {x.Id}.");
    }
}