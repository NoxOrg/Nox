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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefPaymentProviderToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetPaymentProvider(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentProviderRelatedPaymentDetails(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentDetail",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToPaymentDetails(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefPaymentProviderToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetPaymentProvider(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.PaymentDetail>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetPaymentProviderRelatedPaymentDetails(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("PaymentDetail", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToPaymentDetails(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefPaymentProviderToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetPaymentProvider(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetPaymentProviderRelatedPaymentDetails(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("PaymentDetail", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToPaymentDetails(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefPaymentProviderToPaymentDetailsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetPaymentProvider(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("PaymentProvider",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToPaymentDetails();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefPaymentProviderToPaymentDetailsCommandHandlerBase<TRequest> : CommandBase<TRequest, PaymentProviderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefPaymentProviderToPaymentDetailsCommand
{
	public IRepository Repository { get; }

	public RefPaymentProviderToPaymentDetailsCommandHandlerBase(
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

	protected async Task<PaymentProviderEntity?> GetPaymentProvider(PaymentProviderKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.PaymentProviderMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Cryptocash.Domain.PaymentProvider>(keys.ToArray(), x => x.PaymentDetails, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.PaymentDetail?> GetPaymentProviderRelatedPaymentDetails(PaymentDetailKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.PaymentDetailMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Cryptocash.Domain.PaymentDetail>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, PaymentProviderEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}