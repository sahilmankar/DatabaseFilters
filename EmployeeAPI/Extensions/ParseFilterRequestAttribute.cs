using System.Text.Json;
using EmployeeAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[AttributeUsage(AttributeTargets.Parameter)]
// convert the json querystring into object
public class FilterRequestConvertorAttribute : ModelBinderAttribute
{
    public FilterRequestConvertorAttribute(): base(typeof(FilterRequestModelBinder)) { }
}

public class FilterRequestModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (
            valueProviderResult == ValueProviderResult.None
            || string.IsNullOrEmpty(valueProviderResult.FirstValue)
        )
        {
            bindingContext.Result = ModelBindingResult.Success(new FilterRequest());
            return Task.CompletedTask;
        }

        try
        {
            string? jsonString = valueProviderResult.FirstValue;

            FilterRequest? filterRequest = JsonSerializer.Deserialize<FilterRequest>(
                jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            bindingContext.Result = ModelBindingResult.Success(filterRequest);
        }
        catch (JsonException)
        {
            bindingContext.Result = ModelBindingResult.Success(new FilterRequest());
        }

        return Task.CompletedTask;
    }
}
