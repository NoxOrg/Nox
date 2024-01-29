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
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;
public partial record  UpsertWorkplacesOwnershipsTranslationsCommand(IEnumerable<WorkplaceOwnershipLocalizedDto> WorkplaceOwnershipLocalizedDtos) : IRequest<IEnumerable<WorkplaceOwnershipLocalizedDto>>;

internal partial class UpsertWorkplacesOwnershipsTranslationsCommandHandler : UpsertWorkplacesOwnershipsTranslationsCommandHandlerBase
{
	public UpsertWorkplacesOwnershipsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class UpsertWorkplacesOwnershipsTranslationsCommandHandlerBase : CommandCollectionBase<UpsertWorkplacesOwnershipsTranslationsCommand, WorkplaceOwnershipLocalized>, IRequestHandler<UpsertWorkplacesOwnershipsTranslationsCommand, IEnumerable<WorkplaceOwnershipLocalizedDto>>
{
	public IRepository Repository { get; }
	public UpsertWorkplacesOwnershipsTranslationsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<IEnumerable<WorkplaceOwnershipLocalizedDto>> Handle(UpsertWorkplacesOwnershipsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var cultureCodes = command.WorkplaceOwnershipLocalizedDtos.DistinctBy(d=>d.CultureCode).Select(d=>CultureCode.From(d.CultureCode)).ToList();
		var localizedEntities = await Repository.Query<WorkplaceOwnershipLocalized>()
			.Where(x => cultureCodes.Contains(x.CultureCode))			
			.ToListAsync(cancellationToken);
		
		var entities = new List<WorkplaceOwnershipLocalized>();
		foreach(var dto in command.WorkplaceOwnershipLocalizedDtos)
		{
            var entity = localizedEntities.SingleOrDefault(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode));
	        if(entity is not null)
			{
                entity.Name = dto.Name;
                entities.Add(entity);
            }
			else
			{
				var e = new WorkplaceOwnershipLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
				await Repository.AddAsync(e, cancellationToken);
				entities.Add(e);
			}
        }
		
		//Update Default in Entity 
		command.WorkplaceOwnershipLocalizedDtos.Where(dto=>dto.CultureCode == DefaultCultureCode.Value).ForEach(dto =>
		{
			var e = new WorkplaceOwnership { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };			
			Repository.Update(e);
		});
		

		await OnCompletedAsync(command, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return command.WorkplaceOwnershipLocalizedDtos;
	}
}
public class UpsertWorkplacesOwnershipsTranslationsCommandValidator : AbstractValidator<UpsertWorkplacesOwnershipsTranslationsCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1000, 4000, 5000, };
	
    public UpsertWorkplacesOwnershipsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.WorkplaceOwnershipLocalizedDtos)
			.Must(x => x != null && x.Count() > 0)
			.WithMessage($"{nameof(UpsertWorkplacesOwnershipsTranslationsCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationsCommand.WorkplaceOwnershipLocalizedDtos)} is required.");
		
		RuleForEach(x => x.WorkplaceOwnershipLocalizedDtos)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.CultureCode))
			.WithMessage((_,x) => $"{nameof(UpsertWorkplacesOwnershipsTranslationsCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationsCommand.WorkplaceOwnershipLocalizedDtos)} contains unsupported culture code: {x.CultureCode}.");
		
		RuleForEach(x => x.WorkplaceOwnershipLocalizedDtos)
			.Must(x => _supportedIds.Contains(x.Id))
			.WithMessage((_,x) => $"{nameof(UpsertWorkplacesOwnershipsTranslationsCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationsCommand.WorkplaceOwnershipLocalizedDtos)} contains unsupported Id: {x.Id}.");
    }
}