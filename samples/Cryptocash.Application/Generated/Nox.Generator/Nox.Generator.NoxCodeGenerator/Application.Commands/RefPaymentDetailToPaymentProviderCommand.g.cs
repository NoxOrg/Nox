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
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public abstract record RefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentProviderCommand(EntityKeyDto);

internal partial class CreateRefPaymentDetailToPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentProviderCommandHandlerBase<CreateRefPaymentDetailToPaymentProviderCommand>
{
	public CreateRefPaymentDetailToPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefPaymentDetailToPaymentProviderCommand request)
    {
		var entity = await GetPaymentDetail(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetailsRelatedPaymentProvider(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentProvider",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToPaymentProvider(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto, PaymentProviderKeyDto RelatedEntityKeyDto)
	: RefPaymentDetailToPaymentProviderCommand(EntityKeyDto);

internal partial class DeleteRefPaymentDetailToPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentProviderCommandHandlerBase<DeleteRefPaymentDetailToPaymentProviderCommand>
{
	public DeleteRefPaymentDetailToPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefPaymentDetailToPaymentProviderCommand request)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetailsRelatedPaymentProvider(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentProvider", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToPaymentProvider(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefPaymentDetailToPaymentProviderCommand(PaymentDetailKeyDto EntityKeyDto)
	: RefPaymentDetailToPaymentProviderCommand(EntityKeyDto);

internal partial class DeleteAllRefPaymentDetailToPaymentProviderCommandHandler
	: RefPaymentDetailToPaymentProviderCommandHandlerBase<DeleteAllRefPaymentDetailToPaymentProviderCommand>
{
	public DeleteAllRefPaymentDetailToPaymentProviderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefPaymentDetailToPaymentProviderCommand request)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToPaymentProvider();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefPaymentDetailToPaymentProviderCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentDetailEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToPaymentProviderCommand
{
	public AppDbContext DbContext { get; }

	public RefPaymentDetailToPaymentProviderCommandHandlerBase(
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

	protected async Task<PaymentDetailEntity?> GetPaymentDetail(PaymentDetailKeyDto entityKeyDto)
	{
		var keyId = Dto.PaymentDetailMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.PaymentDetails.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.PaymentProvider?> GetPaymentDetailsRelatedPaymentProvider(PaymentProviderKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.PaymentProviderMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.PaymentProviders.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, PaymentDetailEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}