﻿// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Factories;

internal abstract class BookingFactoryBase : IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public BookingFactoryBase
    (
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual BookingEntity CreateEntity(BookingCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(BookingEntity entity, BookingUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(BookingEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.Booking ToEntity(BookingCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Booking();
        entity.AmountFrom = Cryptocash.Domain.BookingMetadata.CreateAmountFrom(createDto.AmountFrom);
        entity.AmountTo = Cryptocash.Domain.BookingMetadata.CreateAmountTo(createDto.AmountTo);
        entity.RequestedPickUpDate = Cryptocash.Domain.BookingMetadata.CreateRequestedPickUpDate(createDto.RequestedPickUpDate);
        entity.SetIfNotNull(createDto.PickedUpDateTime, (entity) => entity.PickedUpDateTime =Cryptocash.Domain.BookingMetadata.CreatePickedUpDateTime(createDto.PickedUpDateTime.NonNullValue<DateTimeRangeDto>()));
        entity.SetIfNotNull(createDto.ExpiryDateTime, (entity) => entity.ExpiryDateTime =Cryptocash.Domain.BookingMetadata.CreateExpiryDateTime(createDto.ExpiryDateTime.NonNullValue<System.DateTimeOffset>()));
        entity.SetIfNotNull(createDto.CancelledDateTime, (entity) => entity.CancelledDateTime =Cryptocash.Domain.BookingMetadata.CreateCancelledDateTime(createDto.CancelledDateTime.NonNullValue<System.DateTimeOffset>()));
        entity.SetIfNotNull(createDto.VatNumber, (entity) => entity.VatNumber =Cryptocash.Domain.BookingMetadata.CreateVatNumber(createDto.VatNumber.NonNullValue<VatNumberDto>()));
        entity.EnsureId(createDto.Id);
        return entity;
    }

    private void UpdateEntityInternal(BookingEntity entity, BookingUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.AmountFrom = Cryptocash.Domain.BookingMetadata.CreateAmountFrom(updateDto.AmountFrom.NonNullValue<MoneyDto>());
        entity.AmountTo = Cryptocash.Domain.BookingMetadata.CreateAmountTo(updateDto.AmountTo.NonNullValue<MoneyDto>());
        entity.RequestedPickUpDate = Cryptocash.Domain.BookingMetadata.CreateRequestedPickUpDate(updateDto.RequestedPickUpDate.NonNullValue<DateTimeRangeDto>());
        if(updateDto.PickedUpDateTime is null)
        {
             entity.PickedUpDateTime = null;
        }
        else
        {
            entity.PickedUpDateTime = Cryptocash.Domain.BookingMetadata.CreatePickedUpDateTime(updateDto.PickedUpDateTime.ToValueFromNonNull<DateTimeRangeDto>());
        }
        if(updateDto.ExpiryDateTime is null)
        {
             entity.ExpiryDateTime = null;
        }
        else
        {
            entity.ExpiryDateTime = Cryptocash.Domain.BookingMetadata.CreateExpiryDateTime(updateDto.ExpiryDateTime.ToValueFromNonNull<System.DateTimeOffset>());
        }
        if(updateDto.CancelledDateTime is null)
        {
             entity.CancelledDateTime = null;
        }
        else
        {
            entity.CancelledDateTime = Cryptocash.Domain.BookingMetadata.CreateCancelledDateTime(updateDto.CancelledDateTime.ToValueFromNonNull<System.DateTimeOffset>());
        }
        if(updateDto.VatNumber is null)
        {
             entity.VatNumber = null;
        }
        else
        {
            entity.VatNumber = Cryptocash.Domain.BookingMetadata.CreateVatNumber(updateDto.VatNumber.ToValueFromNonNull<VatNumberDto>());
        }
    }

    private void PartialUpdateEntityInternal(BookingEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("AmountFrom", out var AmountFromUpdateValue))
        {
            if (AmountFromUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AmountFrom' can't be null");
            }
            {
                var updated = entity.AmountFrom ?? new Nox.Types.Money();
                foreach(var pair in AmountFromUpdateValue)
                {
                    var property = typeof(Nox.Types.Money).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.AmountFrom = Cryptocash.Domain.BookingMetadata.CreateAmountFrom(updated);
            }
        }

        if (updatedProperties.TryGetValue("AmountTo", out var AmountToUpdateValue))
        {
            if (AmountToUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AmountTo' can't be null");
            }
            {
                var updated = entity.AmountTo ?? new Nox.Types.Money();
                foreach(var pair in AmountToUpdateValue)
                {
                    var property = typeof(Nox.Types.Money).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.AmountTo = Cryptocash.Domain.BookingMetadata.CreateAmountTo(updated);
            }
        }

        if (updatedProperties.TryGetValue("RequestedPickUpDate", out var RequestedPickUpDateUpdateValue))
        {
            if (RequestedPickUpDateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'RequestedPickUpDate' can't be null");
            }
            {
                var updated = entity.RequestedPickUpDate ?? new Nox.Types.DateTimeRange();
                foreach(var pair in RequestedPickUpDateUpdateValue)
                {
                    var property = typeof(Nox.Types.DateTimeRange).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.RequestedPickUpDate = Cryptocash.Domain.BookingMetadata.CreateRequestedPickUpDate(updated);
            }
        }

        if (updatedProperties.TryGetValue("PickedUpDateTime", out var PickedUpDateTimeUpdateValue))
        {
            if (PickedUpDateTimeUpdateValue == null) { entity.PickedUpDateTime = null; }
            else
            {
                var updated = entity.PickedUpDateTime ?? new Nox.Types.DateTimeRange();
                foreach(var pair in PickedUpDateTimeUpdateValue)
                {
                    var property = typeof(Nox.Types.DateTimeRange).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.PickedUpDateTime = Cryptocash.Domain.BookingMetadata.CreatePickedUpDateTime(updated);
            }
        }

        if (updatedProperties.TryGetValue("ExpiryDateTime", out var ExpiryDateTimeUpdateValue))
        {
            if (ExpiryDateTimeUpdateValue == null) { entity.ExpiryDateTime = null; }
            else
            {
                entity.ExpiryDateTime = Cryptocash.Domain.BookingMetadata.CreateExpiryDateTime(ExpiryDateTimeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CancelledDateTime", out var CancelledDateTimeUpdateValue))
        {
            if (CancelledDateTimeUpdateValue == null) { entity.CancelledDateTime = null; }
            else
            {
                entity.CancelledDateTime = Cryptocash.Domain.BookingMetadata.CreateCancelledDateTime(CancelledDateTimeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("VatNumber", out var VatNumberUpdateValue))
        {
            if (VatNumberUpdateValue == null) { entity.VatNumber = null; }
            else
            {
                var updated = entity.VatNumber ?? new Nox.Types.VatNumber();
                foreach(var pair in VatNumberUpdateValue)
                {
                    var property = typeof(Nox.Types.VatNumber).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.VatNumber = Cryptocash.Domain.BookingMetadata.CreateVatNumber(updated);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class BookingFactory : BookingFactoryBase
{
    public BookingFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}