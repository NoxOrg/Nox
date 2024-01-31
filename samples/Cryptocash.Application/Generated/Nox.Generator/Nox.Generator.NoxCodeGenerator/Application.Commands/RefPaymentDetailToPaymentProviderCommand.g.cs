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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefPaymentDetailToPaymentProviderCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetPaymentDetail(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetailsRelatedPaymentProvider(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentProvider",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToPaymentProvider(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefPaymentDetailToPaymentProviderCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentDetailsRelatedPaymentProvider(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentProvider", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToPaymentProvider(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefPaymentDetailToPaymentProviderCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetPaymentDetail(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentDetail",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToPaymentProvider();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefPaymentDetailToPaymentProviderCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentDetailEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentDetailToPaymentProviderCommand
{
	public IRepository Repository { get; }

	public RefPaymentDetailToPaymentProviderCommandHandlerBase(
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

	protected async Task<PaymentDetailEntity?> GetPaymentDetail(PaymentDetailKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.PaymentDetailMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<PaymentDetail>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.PaymentProvider?> GetPaymentDetailsRelatedPaymentProvider(PaymentProviderKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.PaymentProviderMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<PaymentProvider>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, PaymentDetailEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}