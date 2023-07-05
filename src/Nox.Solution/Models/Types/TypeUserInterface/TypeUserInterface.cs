using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The user interface display options for this attribute.")]
    [Description("Specify how this attribute is rendered on the user interface. Configuration options include label, icon, input/output masks, help hints among other.")]
    [AdditionalProperties(false)]
    public class TypeUserInterface : DefinitionBase
    {
        [Title("A descriptive label for this attribute on the user interface.")]
        [Description("The text label rendered on the user interface alongside the NoxTextInput component.")]
        public string? Label { get; internal set; }

        [Title("The multi-language translation identifier.")]
        [Description("A unique string/key to reference the translations for this attribute for multi-language translations.")]
        public string? TranslationId { get; internal set; }

        [Title("Widget used to render this attribute on the user interface.")]
        [Description("The user interface control type that is best suited to render the attribute on the screen.")]
        public Widget? Widget { get; internal set; }

        [Title("The icon representing the attribute on the user interface.")]
        [Description("A reference URI to the attribute icon file. Could be a CSS or Mudblazor reference, e.g. '@Icons.Material.Filled.Globe'.")]
        public string? Icon { get; internal set; }

        [Title("The position of the attribute icon on the user interface.")]
        [Description("The postition of the attribute icon relative to the text input area on the user interface, e.g. begin or end.")]
        public IconPosition? IconPosition { get; internal set; } = global::Nox.IconPosition.Begin;

        [Title("A mask expression used to validate and control text input.")]
        [Description("A string of characters that indicates the format of valid input values. For example '(000) 000-0000' could be used for a seven digit phone number with mandatory area code.")]
        public string? InputMask { get; internal set; }

        [Title("A mask expression used to validate and control a value's output.")]
        [Description("A string of characters that indicates the format of valid output. Used to handle validation triggers for onSubmit and onChange events of the control.")]
        public string? OutputMask { get; internal set; }

        [Title("The regular expression against which input is validated.")]
        [Description("A regex string that indicates the format of valid input. For example '/^(\\([0-9]{3}\\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$/gm' could be used for a seven digit phone number with mandatory area code.")]
        public string? Regex { get; internal set; }

        [Title("The user interface PageGroup identifier.")]
        [Description("Used to associate component with a PageGroup identifier on the user interface.")]
        public string? PageGroup { get; internal set; }

        [Title("The user interface FieldGroup identifier.")]
        [Description("Used to associate component with a FieldGroup identifier on the user interface.")]
        public string? FieldGroup { get; internal set; }

        [Title("Display/edit focus order within a FieldGroup on a user interface.")]
        [Description("The order within a group of user interface components (FieldGroup) in which this attribute will receive focus for display or edit purpose.")]
        public int InputOrder { get; internal set; }

        [Title("Helper text for this component.")]
        [Description("The component default helper text used to aid the understanding of the component function to the user.")]
        public string HelpHint { get; internal set; } = ""; //Default to attribute description

        [Title("Validation error message.")]
        [Description("The default error message displayed when text input validation fails.")]
        public string ErrorMessage { get; internal set; } = "";
    }
}