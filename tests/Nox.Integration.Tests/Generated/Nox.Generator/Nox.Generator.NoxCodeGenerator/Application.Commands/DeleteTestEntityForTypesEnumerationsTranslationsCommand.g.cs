// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Abstractions.Extensions;
using TestWebApp.Domain;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;
public partial record  DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand(Enumeration Id, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler : DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase
{
	public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase : CommandBase<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, TestEntityForTypesEnumerationTestFieldLocalized>, IRequestHandler<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var enumEntity = await Repository.FindAsync<TestEntityForTypesEnumerationTestField>(command.Id, cancellationToken);
        EntityNotFoundException.ThrowIfNull(enumEntity, "TestEntityForTypesEnumerationTestFieldLocalized", command.Id.Value.ToString());

		var localizedEnum = await Repository.Query<TestEntityForTypesEnumerationTestFieldLocalized>()
			.FirstOrDefaultAsync(x => x.Id == command.Id && x.CultureCode == command.CultureCode, cancellationToken);
		EntityLocalizationNotFoundException.ThrowIfNull(localizedEnum, "TestEntityForTypesEnumerationTestFieldLocalized",  command.Id.Value.ToString(), command.CultureCode.ToString());
		
		Repository.Delete(localizedEnum);

        await OnCompletedAsync(command, localizedEnum);
        await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}

public class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandValidator : AbstractValidator<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand>
{
	public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x.Value != noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName())
			.WithMessage($"{nameof(DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand)} : {nameof(DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand.CultureCode)} cannot be the default culture code: {noxSolution!.Application!.Localization!.DefaultCulture!.ToDisplayName()}.");
			
    }
}