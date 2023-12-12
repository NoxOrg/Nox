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
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;
public partial record  UpsertWorkplacesOwnershipsTranslationsCommand(IEnumerable<WorkplaceOwnershipLocalizedDto> WorkplaceOwnershipLocalizedDtos) : IRequest<IEnumerable<WorkplaceOwnershipLocalizedDto>>;

internal partial class UpsertWorkplacesOwnershipsTranslationsCommandHandler : UpsertWorkplacesOwnershipsTranslationsCommandHandlerBase
{
	public UpsertWorkplacesOwnershipsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class UpsertWorkplacesOwnershipsTranslationsCommandHandlerBase : CommandCollectionBase<UpsertWorkplacesOwnershipsTranslationsCommand, WorkplaceOwnershipLocalized>, IRequestHandler<UpsertWorkplacesOwnershipsTranslationsCommand, IEnumerable<WorkplaceOwnershipLocalizedDto>>
{
	public AppDbContext DbContext { get; }
	public UpsertWorkplacesOwnershipsTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<IEnumerable<WorkplaceOwnershipLocalizedDto>> Handle(UpsertWorkplacesOwnershipsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var cultureCodes = command.WorkplaceOwnershipLocalizedDtos.DistinctBy(d=>d.CultureCode).Select(d=>CultureCode.From(d.CultureCode)).ToList();
		
		var localizedEntities = await DbContext.WorkplacesOwnershipsLocalized.Where(x => cultureCodes.Contains(x.CultureCode)).AsNoTracking().ToListAsync(cancellationToken);
		
		var entities = new List<WorkplaceOwnershipLocalized>();
		
		command.WorkplaceOwnershipLocalizedDtos.Where(dto=> !localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new WorkplaceOwnershipLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Added;
			entities.Add(e);
		});
		
		command.WorkplaceOwnershipLocalizedDtos.Where(dto=> localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new WorkplaceOwnershipLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Modified;
			entities.Add(e);
		});
		
		command.WorkplaceOwnershipLocalizedDtos.Where(dto=>dto.CultureCode == DefaultCultureCode.Value).ForEach(dto =>
		{
			var e = new WorkplaceOwnership { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };
			DbContext.Entry(e).State = EntityState.Modified;
		});
		

		await OnCompletedAsync(command, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return command.WorkplaceOwnershipLocalizedDtos;
	}
}
public class UpsertWorkplacesOwnershipsTranslationsCommandValidator : AbstractValidator<UpsertWorkplacesOwnershipsTranslationsCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
	private static readonly Nox.Types.CultureCode[] _supportedCultureCodes = new Nox.Types.CultureCode[] { Nox.Types.CultureCode.From("en-US"), Nox.Types.CultureCode.From("it-IT"), Nox.Types.CultureCode.From("fr-FR"), Nox.Types.CultureCode.From("de-DE"), };
	private static readonly int[] _supportedIds = new int[] { 1000, 4000, 5000, };
	
    public UpsertWorkplacesOwnershipsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.WorkplaceOwnershipLocalizedDtos)
			.Must(x => x != null && x.Count() > 0)
			.WithMessage($"{nameof(UpsertWorkplacesOwnershipsTranslationsCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationsCommand.WorkplaceOwnershipLocalizedDtos)} is required.");
		
		RuleForEach(x => x.WorkplaceOwnershipLocalizedDtos)
			.Must(x => _supportedCultureCodes.Contains(Nox.Types.CultureCode.From(x.CultureCode)))
			.WithMessage((_,x) => $"{nameof(UpsertWorkplacesOwnershipsTranslationsCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationsCommand.WorkplaceOwnershipLocalizedDtos)} contains unsupported culture code: {x.CultureCode}.");
		
		RuleForEach(x => x.WorkplaceOwnershipLocalizedDtos)
			.Must(x => _supportedIds.Contains(x.Id))
			.WithMessage((_,x) => $"{nameof(UpsertWorkplacesOwnershipsTranslationsCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationsCommand.WorkplaceOwnershipLocalizedDtos)} contains unsupported Id: {x.Id}.");
    }
}