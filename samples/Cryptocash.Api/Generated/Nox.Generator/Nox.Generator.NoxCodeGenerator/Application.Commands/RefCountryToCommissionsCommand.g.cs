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
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public abstract record RefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCommissionsCommand(EntityKeyDto);

internal partial class CreateRefCountryToCommissionsCommandHandler
	: RefCountryToCommissionsCommandHandlerBase<CreateRefCountryToCommissionsCommand>
{
	public CreateRefCountryToCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCountryToCommissionsCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommission(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Commission",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCommissions(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto, List<CommissionKeyDto> RelatedEntitiesKeysDtos)
	: RefCountryToCommissionsCommand(EntityKeyDto);

internal partial class UpdateRefCountryToCommissionsCommandHandler
	: RefCountryToCommissionsCommandHandlerBase<UpdateRefCountryToCommissionsCommand>
{
	public UpdateRefCountryToCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCountryToCommissionsCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Commission>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCommission(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Commission", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Commissions).LoadAsync();
		entity.UpdateRefToCommissions(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto, CommissionKeyDto RelatedEntityKeyDto)
	: RefCountryToCommissionsCommand(EntityKeyDto);

internal partial class DeleteRefCountryToCommissionsCommandHandler
	: RefCountryToCommissionsCommandHandlerBase<DeleteRefCountryToCommissionsCommand>
{
	public DeleteRefCountryToCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCountryToCommissionsCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCommission(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Commission", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCommissions(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCountryToCommissionsCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCommissionsCommand(EntityKeyDto);

internal partial class DeleteAllRefCountryToCommissionsCommandHandler
	: RefCountryToCommissionsCommandHandlerBase<DeleteAllRefCountryToCommissionsCommand>
{
	public DeleteAllRefCountryToCommissionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCountryToCommissionsCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Commissions).LoadAsync();
		entity.DeleteAllRefToCommissions();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToCommissionsCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCommissionsCommand
{
	public AppDbContext DbContext { get; }

	public RefCountryToCommissionsCommandHandlerBase(
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

	protected async Task<CountryEntity?> GetCountry(CountryKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Commission?> GetCommission(CommissionKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CommissionMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Commissions.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}
		return true;
	}
}