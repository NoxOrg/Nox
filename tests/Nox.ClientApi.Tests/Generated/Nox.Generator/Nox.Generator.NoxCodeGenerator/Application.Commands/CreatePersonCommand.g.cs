﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Commands;

public partial record CreatePersonCommand(PersonCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<PersonKeyDto>;

internal partial class CreatePersonCommandHandler : CreatePersonCommandHandlerBase
{
	public CreatePersonCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreatePersonCommandHandlerBase : CommandBase<CreatePersonCommand,PersonEntity>, IRequestHandler <CreatePersonCommand, PersonKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> EntityFactory;

	protected CreatePersonCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<PersonKeyDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<ClientApi.Domain.Person>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new PersonKeyDto(entityToCreate.Id.Value);
	}
}

public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonValidator()
    {
    }
}