// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public abstract record RefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCountryCommand(EntityKeyDto);

internal partial class CreateRefCommissionToCountryCommandHandler
	: RefCommissionToCountryCommandHandlerBase<CreateRefCommissionToCountryCommand>
{
	public CreateRefCommissionToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCommissionToCountryCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCommission(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommissionFeesForCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCommissionToCountryCommand(EntityKeyDto);

internal partial class DeleteRefCommissionToCountryCommandHandler
	: RefCommissionToCountryCommandHandlerBase<DeleteRefCommissionToCountryCommand>
{
	public DeleteRefCommissionToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCommissionToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCommission(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommissionFeesForCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCommissionToCountryCommand(CommissionKeyDto EntityKeyDto)
	: RefCommissionToCountryCommand(EntityKeyDto);

internal partial class DeleteAllRefCommissionToCountryCommandHandler
	: RefCommissionToCountryCommandHandlerBase<DeleteAllRefCommissionToCountryCommand>
{
	public DeleteAllRefCommissionToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCommissionToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCommission(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountry();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCommissionToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CommissionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToCountryCommand
{
	public IRepository Repository { get; }

	public RefCommissionToCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<CommissionEntity?> GetCommission(CommissionKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CommissionMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Commission>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Country?> GetCommissionFeesForCountry(CountryKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Country>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CommissionEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}