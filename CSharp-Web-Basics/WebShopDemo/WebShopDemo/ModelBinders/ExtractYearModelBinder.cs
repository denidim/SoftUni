﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebShopDemo.ModelBinders
{
    public class ExtractYearModelBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext context)
        {
            var value = context.ValueProvider.GetValue("firstCooked").FirstValue;

            if(DateTime.TryParse(value,out var valueAsDateTime))
            {
                context.Result = ModelBindingResult.Success(valueAsDateTime.Year);
            }
            else
            {
                context.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
