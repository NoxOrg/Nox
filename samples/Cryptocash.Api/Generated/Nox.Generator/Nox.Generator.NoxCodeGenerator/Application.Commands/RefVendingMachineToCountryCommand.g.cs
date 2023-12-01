
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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToCountryCommand(VendingMachineKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefVendingMachineToCountryCommand(VendingMachineKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToCountryCommand(EntityKeyDto);

internal partial class CreateRefVendingMachineToCountryCommandHandler
	: RefVendingMachineToCountryCommandHandlerBase<CreateRefVendingMachineToCountryCommand>
{
	public CreateRefVendingMachineToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefVendingMachineToCountryCommand request)
    {
		var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefVendingMachineToCountryCommand(VendingMachineKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToCountryCommand(EntityKeyDto);

internal partial class DeleteRefVendingMachineToCountryCommandHandler
	: RefVendingMachineToCountryCommandHandlerBase<DeleteRefVendingMachineToCountryCommand>
{
	public DeleteRefVendingMachineToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefVendingMachineToCountryCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefVendingMachineToCountryCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToCountryCommand(EntityKeyDto);

internal partial class DeleteAllRefVendingMachineToCountryCommandHandler
	: RefVendingMachineToCountryCommandHandlerBase<DeleteAllRefVendingMachineToCountryCommand>
{
	public DeleteAllRefVendingMachineToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefVendingMachineToCountryCommand request)
    {
        var entity = await GetVendingMachine(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		entity.DeleteAllRefToCountry();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefVendingMachineToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToCountryCommand
{
	public AppDbContext DbContext { get; }

	public RefVendingMachineToCountryCommandHandlerBase(
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

	protected async Task<VendingMachineEntity?> GetVendingMachine(VendingMachineKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.VendingMachines.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Country?> GetCountry(CountryKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CountryMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, VendingMachineEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}