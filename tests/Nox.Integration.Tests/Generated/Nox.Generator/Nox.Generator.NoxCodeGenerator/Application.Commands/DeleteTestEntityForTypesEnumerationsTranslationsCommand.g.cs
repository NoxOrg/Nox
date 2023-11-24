// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Exceptions;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;
public partial record  DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand(Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler : DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase
{
	public DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommandHandlerBase : CommandBase<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, TestEntityForTypesEnumerationTestFieldLocalized>, IRequestHandler<DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand, bool>
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

		if(NoxSolution.Application?.Localization?.DefaultCulture == command.CultureCode.Value)
		{
			throw new DefaultCultureCodeDeletionException($"Default culture code {command.CultureCode.Value} cannot be deleted.");
		}
		
		var localizedEnums = await DbContext.TestEntityForTypesEnumerationTestFieldsLocalized.Where(x => x.CultureCode == command.CultureCode).ToListAsync(cancellationToken);
		
		if(localizedEnums == null || localizedEnums.Count == 0)
		{
			return false;
		}
		
		await OnBatchCompletedAsync(command, localizedEnums);
		
		DbContext.RemoveRange(localizedEnums);
		
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}