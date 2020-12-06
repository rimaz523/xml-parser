using Application.Common.Processors.Interfaces;
using FluentValidation;
using System;
using System.Globalization;

namespace Application.Common.Validators
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> HasXmlTag<T>(this IRuleBuilder<T, string> ruleBuilder, IXmlProcessor xmlProcessor, string tagName)
        {
            return ruleBuilder.Must((rootObject, value, context) =>
            {
                context.MessageFormatter.AppendArgument("TagName", tagName);
                return xmlProcessor.IsTagPresent(tagName, value);
            })
            .WithMessage("'{PropertyName}' is missing a '{TagName}' tag.");
        }

        public static IRuleBuilderOptions<T, string> IsWellFormedXml<T>(this IRuleBuilder<T, string> ruleBuilder, IXmlProcessor xmlProcessor)
        {
            return ruleBuilder.Must((rootObject, value, context) =>
            {
                return xmlProcessor.AreAllOpeningTagsHavingCorrespondingClosingTags(value);
            })
            .WithMessage("'{PropertyName}' is not well formed XML.");
        }

        public static IRuleBuilderOptions<T, string> IsValidNumber<T>(this IRuleBuilder<T, string> ruleBuilder, IXmlProcessor xmlProcessor, string tagName)
        {
            return ruleBuilder.Must((rootObject, value, context) =>
            {
                context.MessageFormatter.AppendArgument("TagName", tagName);
                var tagContent = xmlProcessor.GetTagContent(tagName, value);
                if (string.IsNullOrEmpty(tagContent))
                {
                    return true;
                }
                return double.TryParse(tagContent, out _);
            })
            .WithMessage("'{PropertyName}' has '{TagName}' content which is an invalid number.");
        }

        public static IRuleBuilderOptions<T, string> IsValidDateFormat<T>(this IRuleBuilder<T, string> ruleBuilder, IXmlProcessor xmlProcessor, string tagName)
        {
            return ruleBuilder.Must((rootObject, value, context) =>
            {
                context.MessageFormatter.AppendArgument("TagName", tagName);
                var tagContent = xmlProcessor.GetTagContent(tagName, value);
                if (string.IsNullOrEmpty(tagContent))
                {
                    return true;
                }
                return DateTime.TryParse(tagContent, out _);
            })
            .WithMessage("'{PropertyName}' has '{TagName}' content which is an invalid date format.");
        }

    }
}
