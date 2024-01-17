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
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Commands;

public abstract record RefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentDetailsCommand(EntityKeyDto);

internal partial class CreateRefPaymentProviderToPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentDetailsCommandHandlerBase<CreateRefPaymentProviderToPaymentDetailsCommand>
{
	public CreateRefPaymentProviderToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefPaymentProviderToPaymentDetailsCommand request)
    {
		var entity = await GetPaymentProvider(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetail(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentDetail",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToPaymentDetails(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, List<PaymentDetailKeyDto> RelatedEntitiesKeysDtos)
	: RefPaymentProviderToPaymentDetailsCommand(EntityKeyDto);

internal partial class UpdateRefPaymentProviderToPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentDetailsCommandHandlerBase<UpdateRefPaymentProviderToPaymentDetailsCommand>
{
	public UpdateRefPaymentProviderToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefPaymentProviderToPaymentDetailsCommand request)
    {
		var entity = await GetPaymentProvider(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.PaymentDetail>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetPaymentDetail(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("PaymentDetail", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.PaymentDetails).LoadAsync();
		entity.UpdateRefToPaymentDetails(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto, PaymentDetailKeyDto RelatedEntityKeyDto)
	: RefPaymentProviderToPaymentDetailsCommand(EntityKeyDto);

internal partial class DeleteRefPaymentProviderToPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentDetailsCommandHandlerBase<DeleteRefPaymentProviderToPaymentDetailsCommand>
{
	public DeleteRefPaymentProviderToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefPaymentProviderToPaymentDetailsCommand request)
    {
        var entity = await GetPaymentProvider(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetail(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentDetail", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToPaymentDetails(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefPaymentProviderToPaymentDetailsCommand(PaymentProviderKeyDto EntityKeyDto)
	: RefPaymentProviderToPaymentDetailsCommand(EntityKeyDto);

internal partial class DeleteAllRefPaymentProviderToPaymentDetailsCommandHandler
	: RefPaymentProviderToPaymentDetailsCommandHandlerBase<DeleteAllRefPaymentProviderToPaymentDetailsCommand>
{
	public DeleteAllRefPaymentProviderToPaymentDetailsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefPaymentProviderToPaymentDetailsCommand request)
    {
        var entity = await GetPaymentProvider(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.PaymentDetails).LoadAsync();
		entity.DeleteAllRefToPaymentDetails();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefPaymentProviderToPaymentDetailsCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentProviderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentProviderToPaymentDetailsCommand
{
	public AppDbContext DbContext { get; }

	public RefPaymentProviderToPaymentDetailsCommandHandlerBase(
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

	protected async Task<PaymentProviderEntity?> GetPaymentProvider(PaymentProviderKeyDto entityKeyDto)
	{
		var keyId = Dto.PaymentProviderMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.PaymentProviders.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.PaymentDetail?> GetPaymentDetail(PaymentDetailKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.PaymentDetailMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.PaymentDetails.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, PaymentProviderEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}