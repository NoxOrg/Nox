
// Generated
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
using Dto = Cryptocash.Application.Dto;
using Cryptocash.Domain;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Factories;

internal partial class BookingFactory : BookingFactoryBase
{
    public BookingFactory
    (
    ) : base()
    {}
}

internal abstract class BookingFactoryBase : IEntityFactory<BookingEntity, BookingCreateDto, BookingUpdateDto>
{

    public BookingFactoryBase(
        )
    {
    }

    public virtual async Task<BookingEntity> CreateEntityAsync(BookingCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(BookingEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(BookingEntity entity, BookingUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(BookingEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(BookingEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(BookingEntity));
        }   
    }

    private async Task<Cryptocash.Domain.Booking> ToEntityAsync(BookingCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Booking();
        exceptionCollector.Collect("AmountFrom", () => entity.SetIfNotNull(createDto.AmountFrom, (entity) => entity.AmountFrom = 
            Dto.BookingMetadata.CreateAmountFrom(createDto.AmountFrom.NonNullValue<MoneyDto>())));
        exceptionCollector.Collect("AmountTo", () => entity.SetIfNotNull(createDto.AmountTo, (entity) => entity.AmountTo = 
            Dto.BookingMetadata.CreateAmountTo(createDto.AmountTo.NonNullValue<MoneyDto>())));
        exceptionCollector.Collect("RequestedPickUpDate", () => entity.SetIfNotNull(createDto.RequestedPickUpDate, (entity) => entity.RequestedPickUpDate = 
            Dto.BookingMetadata.CreateRequestedPickUpDate(createDto.RequestedPickUpDate.NonNullValue<DateTimeRangeDto>())));
        exceptionCollector.Collect("PickedUpDateTime", () => entity.SetIfNotNull(createDto.PickedUpDateTime, (entity) => entity.PickedUpDateTime = 
            Dto.BookingMetadata.CreatePickedUpDateTime(createDto.PickedUpDateTime.NonNullValue<DateTimeRangeDto>())));
        exceptionCollector.Collect("ExpiryDateTime", () => entity.SetIfNotNull(createDto.ExpiryDateTime, (entity) => entity.ExpiryDateTime = 
            Dto.BookingMetadata.CreateExpiryDateTime(createDto.ExpiryDateTime.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("CancelledDateTime", () => entity.SetIfNotNull(createDto.CancelledDateTime, (entity) => entity.CancelledDateTime = 
            Dto.BookingMetadata.CreateCancelledDateTime(createDto.CancelledDateTime.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("VatNumber", () => entity.SetIfNotNull(createDto.VatNumber, (entity) => entity.VatNumber = 
            Dto.BookingMetadata.CreateVatNumber(createDto.VatNumber.NonNullValue<VatNumberDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(BookingEntity entity, BookingUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("AmountFrom",() => entity.AmountFrom = Dto.BookingMetadata.CreateAmountFrom(updateDto.AmountFrom.NonNullValue<MoneyDto>()));
        exceptionCollector.Collect("AmountTo",() => entity.AmountTo = Dto.BookingMetadata.CreateAmountTo(updateDto.AmountTo.NonNullValue<MoneyDto>()));
        exceptionCollector.Collect("RequestedPickUpDate",() => entity.RequestedPickUpDate = Dto.BookingMetadata.CreateRequestedPickUpDate(updateDto.RequestedPickUpDate.NonNullValue<DateTimeRangeDto>()));
        if(updateDto.PickedUpDateTime is null)
        {
             entity.PickedUpDateTime = null;
        }
        else
        {
            exceptionCollector.Collect("PickedUpDateTime",() =>entity.PickedUpDateTime = Dto.BookingMetadata.CreatePickedUpDateTime(updateDto.PickedUpDateTime.ToValueFromNonNull<DateTimeRangeDto>()));
        }
        if(updateDto.ExpiryDateTime is null)
        {
             entity.ExpiryDateTime = null;
        }
        else
        {
            exceptionCollector.Collect("ExpiryDateTime",() =>entity.ExpiryDateTime = Dto.BookingMetadata.CreateExpiryDateTime(updateDto.ExpiryDateTime.ToValueFromNonNull<System.DateTimeOffset>()));
        }
        if(updateDto.CancelledDateTime is null)
        {
             entity.CancelledDateTime = null;
        }
        else
        {
            exceptionCollector.Collect("CancelledDateTime",() =>entity.CancelledDateTime = Dto.BookingMetadata.CreateCancelledDateTime(updateDto.CancelledDateTime.ToValueFromNonNull<System.DateTimeOffset>()));
        }
        if(updateDto.VatNumber is null)
        {
             entity.VatNumber = null;
        }
        else
        {
            exceptionCollector.Collect("VatNumber",() =>entity.VatNumber = Dto.BookingMetadata.CreateVatNumber(updateDto.VatNumber.ToValueFromNonNull<VatNumberDto>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(BookingEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("AmountFrom", out var AmountFromUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AmountFromUpdateValue, "Attribute 'AmountFrom' can't be null.");
            {
                var entityToUpdate = entity.AmountFrom is null ? new MoneyDto() : entity.AmountFrom.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountFromUpdateValue);
                exceptionCollector.Collect("AmountFrom",() =>entity.AmountFrom = Dto.BookingMetadata.CreateAmountFrom(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("AmountTo", out var AmountToUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AmountToUpdateValue, "Attribute 'AmountTo' can't be null.");
            {
                var entityToUpdate = entity.AmountTo is null ? new MoneyDto() : entity.AmountTo.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountToUpdateValue);
                exceptionCollector.Collect("AmountTo",() =>entity.AmountTo = Dto.BookingMetadata.CreateAmountTo(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("RequestedPickUpDate", out var RequestedPickUpDateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(RequestedPickUpDateUpdateValue, "Attribute 'RequestedPickUpDate' can't be null.");
            {
                var entityToUpdate = entity.RequestedPickUpDate is null ? new DateTimeRangeDto() : entity.RequestedPickUpDate.ToDto();
                DateTimeRangeDto.UpdateFromDictionary(entityToUpdate, RequestedPickUpDateUpdateValue);
                exceptionCollector.Collect("RequestedPickUpDate",() =>entity.RequestedPickUpDate = Dto.BookingMetadata.CreateRequestedPickUpDate(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("PickedUpDateTime", out var PickedUpDateTimeUpdateValue))
        {
            if (PickedUpDateTimeUpdateValue == null) { entity.PickedUpDateTime = null; }
            else
            {
                var entityToUpdate = entity.PickedUpDateTime is null ? new DateTimeRangeDto() : entity.PickedUpDateTime.ToDto();
                DateTimeRangeDto.UpdateFromDictionary(entityToUpdate, PickedUpDateTimeUpdateValue);
                exceptionCollector.Collect("PickedUpDateTime",() =>entity.PickedUpDateTime = Dto.BookingMetadata.CreatePickedUpDateTime(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("ExpiryDateTime", out var ExpiryDateTimeUpdateValue))
        {
            if (ExpiryDateTimeUpdateValue == null) { entity.ExpiryDateTime = null; }
            else
            {
                exceptionCollector.Collect("ExpiryDateTime",() =>entity.ExpiryDateTime = Dto.BookingMetadata.CreateExpiryDateTime(ExpiryDateTimeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CancelledDateTime", out var CancelledDateTimeUpdateValue))
        {
            if (CancelledDateTimeUpdateValue == null) { entity.CancelledDateTime = null; }
            else
            {
                exceptionCollector.Collect("CancelledDateTime",() =>entity.CancelledDateTime = Dto.BookingMetadata.CreateCancelledDateTime(CancelledDateTimeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("VatNumber", out var VatNumberUpdateValue))
        {
            if (VatNumberUpdateValue == null) { entity.VatNumber = null; }
            else
            {
                var entityToUpdate = entity.VatNumber is null ? new VatNumberDto() : entity.VatNumber.ToDto();
                VatNumberDto.UpdateFromDictionary(entityToUpdate, VatNumberUpdateValue);
                exceptionCollector.Collect("VatNumber",() =>entity.VatNumber = Dto.BookingMetadata.CreateVatNumber(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}