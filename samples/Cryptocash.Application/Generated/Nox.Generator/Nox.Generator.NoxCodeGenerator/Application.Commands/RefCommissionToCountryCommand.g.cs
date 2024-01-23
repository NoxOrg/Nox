// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCommissionToCountryCommand request)
    {
		var entity = await GetCommission(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommissionFeesForCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCommissionToCountryCommand request)
    {
        var entity = await GetCommission(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommissionFeesForCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCommissionToCountryCommand request)
    {
        var entity = await GetCommission(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountry();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCommissionToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CommissionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCommissionToCountryCommand
{
	public AppDbContext DbContext { get; }

	public RefCommissionToCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<CommissionEntity?> GetCommission(CommissionKeyDto entityKeyDto)
	{
		var keyId = Dto.CommissionMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.Commissions.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Country?> GetCommissionFeesForCountry(CountryKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.CountryMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CommissionEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}