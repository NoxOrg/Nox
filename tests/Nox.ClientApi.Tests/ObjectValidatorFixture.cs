using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

internal class ObjectValidatorFixture : IObjectModelValidator
{

    public void Validate(ActionContext actionContext,
        ValidationStateDictionary? validationState,
        string prefix,
        object? model)
    {
        model ??= new object();
        var context = new ValidationContext(model, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(
            model, 
            context,
            results,
            validateAllProperties: true
        );

        if (!isValid)
            results.ForEach(r =>
            {
                var key = string.Join(",",r.MemberNames);
                actionContext.ModelState.AddModelError(key, r.ErrorMessage!);
            });
    }
}