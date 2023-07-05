using System;

#if NETSTANDARD

namespace Json.Schema.Generation;

public class RequiredAttribute : Attribute { public RequiredAttribute() { } }

public class AdditionalPropertiesAttribute : Attribute { public AdditionalPropertiesAttribute(bool boolSchema) { } }

public class DescriptionAttribute : Attribute { public DescriptionAttribute(string description) { } }

public class TitleAttribute : Attribute { public TitleAttribute(string title) { } }

public class PatternAttribute : Attribute { public PatternAttribute(string pattern) { } }

#endif