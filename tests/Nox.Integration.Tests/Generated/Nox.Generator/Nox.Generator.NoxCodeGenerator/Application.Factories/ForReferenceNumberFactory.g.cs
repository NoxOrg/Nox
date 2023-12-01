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

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Factories;

internal abstract class ForReferenceNumberFactoryBase : IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public ForReferenceNumberFactoryBase
    (
        )
    {
    }

    public virtual ForReferenceNumberEntity CreateEntity(ForReferenceNumberCreateDto createDto)
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

    public virtual void UpdateEntity(ForReferenceNumberEntity entity, ForReferenceNumberUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(ForReferenceNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.ForReferenceNumber ToEntity(ForReferenceNumberCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.ForReferenceNumber();
        return entity;
    }

    private void UpdateEntityInternal(ForReferenceNumberEntity entity, ForReferenceNumberUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
    }

    private void PartialUpdateEntityInternal(ForReferenceNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class ForReferenceNumberFactory : ForReferenceNumberFactoryBase
{
}