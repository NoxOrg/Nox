// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;
public partial record  DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand(Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler : DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase
{
	public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase : CommandCollectionBase<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, TestEntityForTypesEnumerationTestFieldLocalized>, IRequestHandler<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		var localizedEnums = await DbContext.TestEntityForTypesEnumerationTestFieldsLocalized.Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
		if(!localizedEnums.Any())
		{
			return false;
		}
		
		await OnCompletedAsync(command, localizedEnums);
		
		DbContext.RemoveRange(localizedEnums);
		
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}

public class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandValidator : AbstractValidator<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandValidator()
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x != _defaultCultureCode)
			.WithMessage($"{nameof(DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand)} : {nameof(DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand.CultureCode)} cannot be the default culture code: {_defaultCultureCode.Value}.");
			
    }
}