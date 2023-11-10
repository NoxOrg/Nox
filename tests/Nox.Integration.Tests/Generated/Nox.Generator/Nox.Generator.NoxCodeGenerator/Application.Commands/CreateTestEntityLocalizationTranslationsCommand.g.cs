// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Types;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;
using TestEntityLocalizationLocalizedEntity = TestWebApp.Domain.TestEntityLocalizationLocalized;

namespace TestWebApp.Application.Commands;
		

public record CreateTestEntityLocalizationTranslationsCommand(TestEntityLocalizationLocalizedCreateDto TestEntityLocalizationLocalizedCreateDto, System.String Id, System.String CultureCode) : IRequest<TestEntityLocalizationLocalizedKeyDto>;

internal partial class CreateTestEntityLocalizationTranslationsCommandHandler : CreateTestEntityLocalizationTranslationsCommandHandlerBase
{
	public CreateTestEntityLocalizationTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationLocalizedCreateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityLocalizedFactory)
	{
	}
}


internal abstract class CreateTestEntityLocalizationTranslationsCommandHandlerBase : CommandBase<CreateTestEntityLocalizationTranslationsCommand, TestEntityLocalizationLocalizedEntity>, IRequestHandler <CreateTestEntityLocalizationTranslationsCommand, TestEntityLocalizationLocalizedKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationLocalizedCreateDto> EntityLocalizedFactory;
	

	public CreateTestEntityLocalizationTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationLocalizedCreateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<TestEntityLocalizationLocalizedKeyDto> Handle(CreateTestEntityLocalizationTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		command.TestEntityLocalizationLocalizedCreateDto.Id = command.Id;
		command.TestEntityLocalizationLocalizedCreateDto.CultureCode = command.CultureCode;
		var entityLocalizedToCreate = EntityLocalizedFactory.CreateLocalizedEntity(command.TestEntityLocalizationLocalizedCreateDto);
		await OnCompletedAsync(command, entityLocalizedToCreate);
		DbContext.TestEntityLocalizationsLocalized.Add(entityLocalizedToCreate);
		await DbContext.SaveChangesAsync();
		return new TestEntityLocalizationLocalizedKeyDto(entityLocalizedToCreate.Id.Value, entityLocalizedToCreate.CultureCode.Value);
	}
}