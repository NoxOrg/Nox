using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation;

public class UniqueAttributeConstraintValidator : AbstractValidator<UniqueAttributeConstraint>
{
    private readonly Entity _entity;
    
    public UniqueAttributeConstraintValidator(Entity entity)
    {
        _entity = entity;
        
        //Name must not be empty
        RuleFor(ua=>ua.Name)
            .NotEmpty()
            .WithMessage(string.Format("Unique attribute constraint name cannot be empty. Entity: {0}", _entity.Name));
        
        //Attribute names must be unique  
        RuleForEach(ua=>ua.AttributeNames)
            .SetValidator(v => new UniquePropertyValidator<string>(v.AttributeNames, x => x, "attribute name in unique constraint"));
        
        //Attribute names must exist in the entity
        RuleForEach(ua=>ua.AttributeNames).Must(ReferenceExistingEntity)
            //TODO: Add a message to resources that lists the attribute names that are not found in the entity
            .WithMessage((_, attribute) => string.Format("Attribute name '{0}' in unique attribute constraint not found in neither entity attribute(s) ({1}) nor entity key(s) ({2})", attribute, EntityAttributeNames, EntityKeyNames ));
    }
    
    private bool ReferenceExistingEntity(string attributeName)
    {
        var entity = _entity.Attributes?.FirstOrDefault(e => e.Name == attributeName);
       
        var keys = _entity.Keys?.FirstOrDefault(e => e.Name == attributeName);
        
        return entity is not null || keys is not null;
    }
    
    private string EntityAttributeNames => string.Join(", ", _entity.Attributes?.Select(x => x.Name) ?? Enumerable.Empty<string>());
    private string EntityKeyNames => string.Join(", ", _entity.Keys?.Select(x => x.Name) ?? Enumerable.Empty<string>());
}