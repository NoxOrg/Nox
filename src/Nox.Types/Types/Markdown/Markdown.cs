using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    private readonly Dictionary<string, string> _htmlTag = new()
    {
        { "*", "em" },
        { "_", "em" },
        { "**", "strong" },
        { "__", "strong" },
    };

    /// <summary>
    /// Converts Markdown text to Html based on <a href="https://spec.commonmark.org/0.30/">CommonMarkdown</a> specification.
    /// </summary>
    /// <remarks>Currently only supporting Italic (as "*" or "_") and Bold (as "**" or "__").</remarks>
    /// <returns>Html string parsed from string with Markdown.</returns>
    public string ToHtml()
    {
        List<(int Position, string MdTag, bool IsOpenTag)> tagList = new();
        (string MarkdownTag, string HtmlTag)? foundTag = null;

        // Iterate through string looking for Markdown tags and registering them in tagList
        for (int i = 0; i < Value.Length; i++)
        {
            if (Value[i].ToString() == MarkdownTag.ItalicA)
            {
                foundTag = (MarkdownTag.ItalicA, _htmlTag[MarkdownTag.ItalicA]);

                if (Value.Length > i + 1 && Value.Substring(i, MarkdownTag.BoldA.Length) == MarkdownTag.BoldA)
                {
                    foundTag = (MarkdownTag.BoldA, _htmlTag[MarkdownTag.BoldA]);
                }
            }

            if (Value[i].ToString() == MarkdownTag.ItalicU)
            {
                foundTag = (MarkdownTag.ItalicU, _htmlTag[MarkdownTag.ItalicU]);

                if (Value.Length > i + 1 && Value.Substring(i, MarkdownTag.BoldU.Length) == MarkdownTag.BoldU)
                {
                    foundTag = (MarkdownTag.BoldU, _htmlTag[MarkdownTag.BoldU]);
                }
            }

            if (foundTag != null)
            {
                if (tagList.Any() && HasPreviouslyOpenTag(tagList, foundTag.Value.MarkdownTag))
                {
                    // Closing tag
                    tagList.Add((i, foundTag.Value.MarkdownTag, false));
                }
                else
                {
                    // Opening tag
                    tagList.Add((i, foundTag.Value.MarkdownTag, true));
                }

                // Skip next characters that belong to current tag
                i += Value.Length <= foundTag.Value.MarkdownTag.Length - 1 ? Value.Length - 1 : foundTag.Value.MarkdownTag.Length - 1;
                foundTag = null;
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
                    result.Append($"<{_htmlTag[tag.MdTag]}>");
                else
                    result.Append($"</{_htmlTag[tag.MdTag]}>");
                currentPosition = tag.Position + tag.MdTag.Length;

                currentPosition = currentPosition >= Value.Length ? Value.Length - 1 : currentPosition;
            }

            result.Append(Value.Substring(tagList.Last().Position + tagList.Last().MdTag.Length)); // add remaining string after last tag

            return result.ToString();
        }

        return Value;
    }

    /// <summary>
    /// Iterate list in reverse looking for matching open tag.
    /// </summary>
    /// <param name="tagList">List to be searched.</param>
    /// <param name="tag">Tag to search for.</param>
    /// <returns>False if there no matching tag in the list or has previously closing tag.</returns>
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