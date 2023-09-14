using System;// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using Transaction = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Factories;

public abstract class TransactionFactoryBase: IEntityFactory<Transaction,TransactionCreateDto>
{

    public TransactionFactoryBase
    (
        )
    {
    }

    public virtual Transaction CreateEntity(TransactionCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.Transaction ToEntity(TransactionCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Transaction();
        entity.TransactionType = Cryptocash.Domain.Transaction.CreateTransactionType(createDto.TransactionType);
        entity.ProcessedOnDateTime = Cryptocash.Domain.Transaction.CreateProcessedOnDateTime(createDto.ProcessedOnDateTime);
        entity.Amount = Cryptocash.Domain.Transaction.CreateAmount(createDto.Amount);
        entity.Reference = Cryptocash.Domain.Transaction.CreateReference(createDto.Reference);
        //entity.Customer = Customer.ToEntity();
        //entity.Booking = Booking.ToEntity();
        return entity;
    }
}

public partial class TransactionFactory : TransactionFactoryBase
{
}