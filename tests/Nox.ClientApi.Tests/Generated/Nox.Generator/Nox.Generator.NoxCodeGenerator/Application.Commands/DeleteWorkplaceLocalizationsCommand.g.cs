// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using WorkplaceLocalizedEntity = ClientApi.Domain.WorkplaceLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteWorkplaceLocalizationsCommand(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteWorkplaceLocalizationsCommandHandler : DeleteWorkplaceLocalizationsCommandHandlerBase
{
    public DeleteWorkplaceLocalizationsCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteWorkplaceLocalizationsCommandHandlerBase : CommandBase<DeleteWorkplaceLocalizationsCommand, WorkplaceLocalizedEntity>, IRequestHandler<DeleteWorkplaceLocalizationsCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteWorkplaceLocalizationsCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteWorkplaceLocalizationsCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(command.keyId);
        
        var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{keyId.ToString()}");
		}

		var entityLocalized = await DbContext.WorkplacesLocalized.FirstOrDefaultAsync(x =>x.Id == entity.Id && x.CultureCode == command.CultureCode);
        
        if (entityLocalized is null)
        {
				throw new EntityNotFoundException("Workplace",  $"{keyId.ToString()}", command.CultureCode.ToString());
        }
        
        await OnCompletedAsync(command, entityLocalized);
        
        DbContext.Remove(entityLocalized);
        
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteWorkplaceLocalizationsCommandValidator : AbstractValidator<DeleteWorkplaceLocalizationsCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public DeleteWorkplaceLocalizationsCommandValidator()
    {
		RuleFor(x => x.CultureCode)
			.Must(x => x != _defaultCultureCode)
			.WithMessage($"{nameof(DeleteWorkplaceLocalizationsCommand)} : {nameof(DeleteWorkplaceLocalizationsCommand.CultureCode)} cannot be the default culture code: {_defaultCultureCode.Value}.");
			
    }
}	