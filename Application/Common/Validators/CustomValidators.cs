using Application.Common.Processors.Interfaces;
using FluentValidation;
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
    }
}
