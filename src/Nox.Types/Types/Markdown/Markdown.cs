using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Markdown"/> type and value object.
/// </summary>
public sealed class Markdown : ValueObject<string, Markdown>
{
    public new static Markdown From(string value)
    {
        value = value.Trim();

        var newObject = new Markdown
        {
            Value = value,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    // TODO: user enum or array or dictionary instead of separate properties
    public static readonly string BoldMbTag = "**";
    public static readonly string ItalicMdTag = "*";
    public static readonly char LineBreak = '\x0a';

    private static readonly string BoldHtmlTag = "strong";
    private static readonly string ItalicHtmlTag = "em";

    private readonly Dictionary<string, string> HtmlTagEquivalent = new()
    {
        { "*", "em" },
        { "**", "strong" },
    };

    /// <summary>
    /// Converts Markdown text to Html based on CommonMarkdown specification.
    /// <see href="https://spec.commonmark.org/0.30/"/>
    /// </summary>
    /// <returns>Html string parsed from </returns>
    public string ToHtml()
    {
        // TODO: add <p> tag between empty lines
        // TODO: it's not open tag it next char is empty
        // TODO: it's not close tag it previous char is empty
        List<(int Position, string MdTag, bool IsOpenTag)> tagList = new(); // TODO: change for Stack?

        // Iterate through string looking for Markdown tags and registering them in tagList
        for (int i = 0; i < Value.Length; i++)
        {
            if (Value[i] == '*')
            {
                (string MdTag, string HtmlTag) currentFoundTag = (ItalicMdTag, ItalicHtmlTag);

                if (Value.Length > i + 1 && Value.Substring(i, BoldMbTag.Length) == BoldMbTag)
                {
                    currentFoundTag = (BoldMbTag, BoldHtmlTag);
                }

                if (tagList.Any() && HasPreviouslyOpenTag(tagList, currentFoundTag.MdTag))
                {
                    // Closing tag
                    tagList.Add((i, currentFoundTag.MdTag, false));
                }
                else
                {
                    // Opening tag
                    tagList.Add((i, currentFoundTag.MdTag, true));
                }

                // Skip next characters that belong to current tag
                i += Value.Length <= currentFoundTag.MdTag.Length - 1 ? Value.Length - 1 : currentFoundTag.MdTag.Length - 1;
            }
        }

        if (tagList.Any())
        {
            // Replace Markdown tags for Html tags
            StringBuilder result = new();
            var currentPosition = tagList.First().Position;
            result.Append(Value.Remove(currentPosition)); // append string before first tag
            foreach (var tag in tagList)
            {
                result.Append(Value[currentPosition..tag.Position]);
                if (tag.IsOpenTag)
                    result.Append($"<{HtmlTagEquivalent[tag.MdTag]}>"); // TODO: better logic?
                else
                    result.Append($"</{HtmlTagEquivalent[tag.MdTag]}>");
                currentPosition = tag.Position + tag.MdTag.Length;
                currentPosition = currentPosition >= Value.Length ? Value.Length - 1 : currentPosition;
            }

            result.Append(Value.Substring(tagList.Last().Position + tagList.Last().MdTag.Length)); // add remaining string after last tag

            // TODO: what to do if there is an incomplete tag ?

            return result.ToString();
        }

        return Value;
    }

    /// <summary>
    /// Iterate list in reverse looking for matching open tag
    /// </summary>
    /// <param name="tagList">List to be searched.</param>
    /// <param name="tag">Tag to search for.</param>
    /// <returns></returns>
    private bool HasPreviouslyOpenTag(IList<(int Position, string MdTag, bool IsOpenTag)> tagList, string tag)
    {
        for (int i = tagList.Count - 1; i >= 0; i--)
        {
            if (tagList[i].MdTag == tag)
            {
                if (tagList[i].IsOpenTag)
                    return true;
                return false;
            }
        }

        return false;
    }
}