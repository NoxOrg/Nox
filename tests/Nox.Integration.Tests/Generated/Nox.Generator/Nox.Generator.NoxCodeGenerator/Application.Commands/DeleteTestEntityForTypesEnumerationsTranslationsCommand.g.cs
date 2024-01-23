// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Abstractions.Extensions;
using TestWebApp.Domain;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;
public partial record  DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand(Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler : DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase
{
	public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase : CommandCollectionBase<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, TestEntityForTypesEnumerationTestFieldLocalized>, IRequestHandler<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, bool>
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

		var localizedEnums = await Repository.Query<TestEntityForTypesEnumerationTestFieldLocalized>().Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
		if(!localizedEnums.Any())
		{
			return false;
		}
		
		await OnCompletedAsync(command, localizedEnums);
		
		Repository.DeleteRange(localizedEnums);
		
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