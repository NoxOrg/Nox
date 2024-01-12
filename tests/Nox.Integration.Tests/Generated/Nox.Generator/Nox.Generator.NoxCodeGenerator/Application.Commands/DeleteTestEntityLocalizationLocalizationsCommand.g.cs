// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityLocalizationLocalizedEntity = TestWebApp.Domain.TestEntityLocalizationLocalized;

namespace TestWebApp.Application.Commands;

public partial record  DeleteTestEntityLocalizationLocalizationsCommand(System.String keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTestEntityLocalizationLocalizationsCommandHandler : DeleteTestEntityLocalizationLocalizationsCommandHandlerBase
{
    public DeleteTestEntityLocalizationLocalizationsCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteTestEntityLocalizationLocalizationsCommandHandlerBase : CommandBase<DeleteTestEntityLocalizationLocalizationsCommand, TestEntityLocalizationLocalizedEntity>, IRequestHandler<DeleteTestEntityLocalizationLocalizationsCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteTestEntityLocalizationLocalizationsCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteTestEntityLocalizationLocalizationsCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var keyId = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateId(command.keyId);
        
        var entity = await DbContext.TestEntityLocalizations.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityLocalization",  $"{keyId.ToString()}");
		}

		var entityLocalized = await DbContext.TestEntityLocalizationsLocalized.FirstOrDefaultAsync(x =>x.Id == entity.Id && x.CultureCode == command.CultureCode);
        
        if (entityLocalized is null)
        {
				throw new EntityNotFoundException("TestEntityLocalization",  $"{keyId.ToString()}", command.CultureCode.ToString());
        }
        
        await OnCompletedAsync(command, entityLocalized);
        
        DbContext.Remove(entityLocalized);
        
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteTestEntityLocalizationLocalizationsCommandValidator : AbstractValidator<DeleteTestEntityLocalizationLocalizationsCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en_US");

    public DeleteTestEntityLocalizationLocalizationsCommandValidator()
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x != _defaultCultureCode)
			.WithMessage($"{nameof(DeleteTestEntityLocalizationLocalizationsCommand)} : {nameof(DeleteTestEntityLocalizationLocalizationsCommand.CultureCode)} cannot be the default culture code: {_defaultCultureCode.Value}.");
			
    }
}	