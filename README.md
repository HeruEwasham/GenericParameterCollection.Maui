# GenericParameterCollection.Maui

This provides controls for using [GenericParameterCollection](https://github.com/HeruEwasham/GenericParameterCollection) in .NET MAUI.

## Status of this project

This project is in it's early stages. The controls work, but especially the popup has it's own oddities. At this stage, I recommend using the GetParameterCollectionView for minimal oddities, but be aware that at the current stage, it is multiple known oddities and other things to be fixed.

While much is documented, not everything is documented much currently, as fixing things is prioritized.

## Setup

The only extra setup you need to be aware of is that itt use MauiCommunityToolkit, so you need to add ``.UseMauiCommunityToolkit()`` in MauiProgram.cs.

## Main features/controls

### ParameterCollectionView

This is a control based on the View-class. This is the main control that handles editing a given ParameterCollection object.

#### Methods

Here is a list of some interesting methods.

##### GetParameterCollection(..)

Call this when you want to get the updated parameters back. This creates a new ParameterCollection-object with all custom converters and other information copied from the original ParameterCollection-object. The method has a validation-property that, if true, will try to validate the input and return null if not validated correctly.

### ParameterCollectionPopup

This is a dialog that implements the ParameterCollectionView and a button to submit and a button to cancel. See this example for how to use this (the variable parameterCollection contains the ParameterCollection, and the variable this references the page it is on.):

```
var popup = new ParameterCollectionPopup(parameterCollection, this);
var result = await this.ShowPopupAsync(popup);
if (result is ParameterCollection parameters)
{
    if (parameters != null)
    {
        Parameters = parameters;
        _editor.Text = Parameters.ToString();
    }
}
```

### Options

The controls let you provide a ParameterCollectionViewOptions. Here you can define some customisation of how the control looks and works. Most are both self explanatory and well documented in code. Some of theese options can also for a specific parameter if the option AdditionalInfoWillOverride is set to true (default is true). Then one or more of the given parameters below be given in a parameters additionalInfo.

#### Different options

Here is a list of parameters that can either be defined in ParameterCollectionViewOptions or as a ParameterCollection (some can only be given in one, while many can be given both ways).

If you define this in a ParameterCollection-ParameterType, the changes will affect all parameters in that ParameterCollection.

Mark that it exist multiple parameters that currently can not be defined in a ParameterCollection. This must be defined in the object directly, and can't be changed via a ParameterCollection.

| Variable name in option-class | Parameter key | Type | Description | Default value in option-class |
| ----------- | ----------- | ----------- | ----------- | ----------- |
| AdditionalInfoWillOverride |  | bool | Can parameters from a ParameterCollection, like AdditionalInfo from a parameter, override the values defined in this options-object | true |
| ShowParameterNameAsHumanReadable | humanReadable | bool | Change if the parameter-key should be tried to be written more human readable | True |
| ReadOnly | readOnly | bool | If true, the control that shows the parameters value should be read only/disabled | False |
| NormalFont |  | Font | The font to be used on text | Font.Default |
| ParameterNameFont |  | Font | The font to be used on parameter-names | Default font with bold setting |
| SubmitAddFont |  | Font | Font used on submit or add buttons text | Font.Default |
| CancelDeleteFont |  | Font | Font used on cancel or delete buttons text | Font.Default |
| NormalTextColor |  | Color | Color used on text | Colors.Black |
| ParameterNameTextColor |  | Color | Color used on parameter name text | Colors.Black |
| SubmitAddTextColor |  | Color | Color used on submit or add buttons text | Colors.Black |
| CancelDeleteTextColor |  | Color | Color used on cancel or delete buttons text | Colors.Black |
| NormalBackgroundColor |  | Color | Color used on control background | Colors.Transparent |
| ParameterNameBackgroundColor |  | Color | Color used on parameter names background | Colors.Transparent |
| SubmitAddBackgroundColor |  | Color | Color used on submit or add buttons background | Colors.LimeGreen |
| CancelDeleteBackgroundColor |  | Color | Color used on cancel or delete buttons background | Colors.Red |
| MinDate | minDate | DateTime | What should be the lowest date that can be selected | new DateTime(1900, 01, 01) |
| MaxDate | maxDate | DateTime | What should be the highest date that can be selected | new DateTime(2100, 12, 31) |
| EnumSelection | enumSelection | Enum of SelectControl | Define what control should be used for enums (valid values are "Picker", "SelectFromList") | Picker |
| SingleSelection | singleSelection | Enum of SelectControl | Define what control should be used for selecting a single value from a list (valid values are "Picker", "SelectFromList") | Picker |
| KeyboardType | keyboard | Keyboard | Define what keyboard type should be used (valid values are "default", "chat", "email", "numeric", "plain", "telephone", "text", "url") | default |
| TextValidation | validation | TextValidationOptions | Define how validation should work | Default implementation |
|  | defaultValue | TValue (Generic baseed on value (IEnumerable<TValue>)) | This is used on IEnumerable-types to define their Default-value (which is their initial state when adding new value) | If not defined, this will either be default(TValue) or String.Empty if TValue is string or DateTime.Now if TValue is DateTime |
| SupportedFileExtensions | supportedExtensions | string[] | Defines what types of file extensions is supported when selecting files for ParameterType.Bytes. All must have a leading . | Empty string[] or null means all types supported/no filter added |
|  | filename | string | This can be added to a Bytes-parameter to give information on what the filename of the file was. This is just for cosmetics and is not neccessarry (but will provide info to the user). When a Bytes-parameter is updated, this parameter in Additionalinfo will also be added/updated by the editor (so if you want to know the filename and uses this editor, this parameter will give you that info) |  |
|  | extension | string | The file extension for the filetype a Bytes-parameter has. The value should have a leading . This parameter is most likely needed if a preview of the file is wanted. This parameter in Additionalinfo will also be added/updated by the editor when the Bytes-parameter is updated |  |
| BytesPreviews |  | IBytesPreview[] | List with all supported preview-implementation for byte-arrays. If one or more parameters has ParameterType.Bytes, the editor will check this list for possible preview-functionality. If it finds a suitable fit, it will select the first it finds. | |
| SupportedWaysToGetBytes |  | IGetBytes[] | List with all supported ways to get byte-arrays. If one or more parameters has ParameterType.Bytes, the editor will check this list for what it can ask the user to get bytes from. It must be minimum one defined. If only one is defined, it does not ask, but go directly to that implementation. | GetBytesFromUrl |
| FileTypeMappings |  | FileType[] | List of different file types and mappings between extensions, UTType (UTI) and mime-types. All file extensions in SupportedFileExtensions must be defined here to be supported. | Default value is all the values that is defined in the library used. Check for yourself if you need to add your own values. |
| BorderOptions | borderOptions | BorderOptions | Define how the borders around parameters, etc. should look. | Default implementation |