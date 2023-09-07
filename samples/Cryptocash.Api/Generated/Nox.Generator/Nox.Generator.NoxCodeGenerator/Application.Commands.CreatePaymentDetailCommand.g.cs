﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using PaymentDetail = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Commands;

public record CreatePaymentDetailCommand(PaymentDetailCreateDto EntityDto) : IRequest<PaymentDetailKeyDto>;

public partial class CreatePaymentDetailCommandHandler: CommandBase<CreatePaymentDetailCommand,PaymentDetail>, IRequestHandler <CreatePaymentDetailCommand, PaymentDetailKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<PaymentDetailCreateDto,PaymentDetail> _entityFactory;

	public CreatePaymentDetailCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<PaymentDetailCreateDto,PaymentDetail> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<PaymentDetailKeyDto> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
					
		OnCompleted(entityToCreate);
		_dbContext.PaymentDetails.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new PaymentDetailKeyDto(entityToCreate.Id.Value);
	}
}