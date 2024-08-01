// Generated

#nullable enable

using MediatR;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Types.Abstractions.Extensions;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;
public partial record UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand(Enumeration Id, TestEntityForTypesEnumerationTestFieldLocalizedUpsertDto TestEntityForTypesEnumerationTestFieldLocalizedUpsertDto, CultureCode CultureCode) : IRequest<TestEntityForTypesEnumerationTestFieldLocalizedKeyDto>;

internal partial class UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommandHandler : UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommandHandlerBase
{
	public UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommandHandlerBase : CommandBase<UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand, TestEntityForTypesEnumerationTestFieldLocalized>, IRequestHandler<UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand, TestEntityForTypesEnumerationTestFieldLocalizedKeyDto>
{
	
	public IRepository Repository { get; }
	public UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<TestEntityForTypesEnumerationTestFieldLocalizedKeyDto> Handle(UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		
		var localizedEntity = await Repository.Query<TestEntityForTypesEnumerationTestFieldLocalized>()
			.Where(x =>x.Id == command.Id && x.CultureCode == command.CultureCode)			
			.FirstOrDefaultAsync(cancellationToken);
		
		if(localizedEntity is not null)
		{
			localizedEntity.Name = command.TestEntityForTypesEnumerationTestFieldLocalizedUpsertDto.Name;
		}
		else
		{
			localizedEntity = new TestEntityForTypesEnumerationTestFieldLocalized {Id = command.Id, CultureCode = command.CultureCode, Name = command.TestEntityForTypesEnumerationTestFieldLocalizedUpsertDto.Name};
			await Repository.AddAsync(localizedEntity, cancellationToken);
		}
		
		if(command.CultureCode == DefaultCultureCode)
		{
			var e = new TestEntityForTypesEnumerationTestField { Id = command.Id, Name = command.TestEntityForTypesEnumerationTestFieldLocalizedUpsertDto.Name };			
			Repository.Update(e);
		}
		
		

		await OnCompletedAsync(command, localizedEntity);
		await Repository.SaveChangesAsync(cancellationToken);
		return new TestEntityForTypesEnumerationTestFieldLocalizedKeyDto(command.Id.Value, command.CultureCode.Value);
	}
}
public class UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommandValidator : AbstractValidator<UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1, 2, 3, };
	
    public UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand)} : {nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand.CultureCode)}  not supported: {x.Value}.");
		
		RuleFor(x => x.Id)
			.Must(x => _supportedIds.Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand)} : {nameof(UpsertTestEntityForTypesEnumerationTestFieldsTranslationCommand.Id)} not supported: {x.Value}.");
    }
}