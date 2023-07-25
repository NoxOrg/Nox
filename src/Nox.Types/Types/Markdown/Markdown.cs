using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Markdown"/> type and value object.
/// </summary>
public sealed class Markdown : ValueObject<string, Markdown>
{
    /// <summary>
    /// Creates a new instance of <see cref="Markdown"/>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
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

    /// <summary>
    /// Converts Markdown text to Html based on <a href="https://spec.commonmark.org/0.30/">CommonMarkdown</a> specification.
    /// </summary>
    /// <remarks>Currently only supporting Italic (as "*" or "_") and Bold (as "**" or "__").</remarks>
    /// <returns>Html string parsed from string with Markdown.</returns>
    public string ToHtml()
    {
        List<(int Position, bool IsOpenTag, (string Markdown, string Html) Tag)> tagList = new();
        (string MarkdownTag, string HtmlTag)? foundTag = null;

        // Iterate through the string looking for Markdown tags and registering them in tagList
        for (int i = 0; i < Value.Length; i++)
        {
            if (Value[i].ToString() == Tag.ItalicA.Markdown)
            {
                foundTag = Tag.ItalicA;

                if (Value.Length > i + 1 && Value.Substring(i, Tag.BoldA.Markdown.Length) == Tag.BoldA.Markdown)
                {
                    foundTag = Tag.BoldA;
                }
            }

            if (Value[i].ToString() == Tag.ItalicU.Markdown)
            {
                foundTag = Tag.ItalicU;

                if (Value.Length > i + 1 && Value.Substring(i, Tag.BoldU.Markdown.Length) == Tag.BoldU.Markdown)
                {
                    foundTag = Tag.BoldU;
                }
            }

            if (foundTag != null)
            {
                if (tagList.Any() && HasPreviouslyOpenTag(tagList, foundTag.Value.MarkdownTag))
                {
                    // Closing tag
                    tagList.Add((i, false, foundTag.Value));
                }
                else
                {
                    // Opening tag
                    tagList.Add((i, true, foundTag.Value));
                }

                // Skip next characters that belong to current tag
                i += Value.Length <= foundTag.Value.MarkdownTag.Length - 1 ? Value.Length - 1 : foundTag.Value.MarkdownTag.Length - 1;
                foundTag = null;
            }
        }

        // Replace Markdown tags for Html tags
        if (tagList.Any())
        {
            StringBuilder result = new();
            var currentPosition = tagList.First().Position;
            result.Append(Value.Remove(currentPosition)); // append string before first tag

            foreach (var currentTag in tagList)
            {
                result.Append(Value[currentPosition..currentTag.Position]);

                if (currentTag.IsOpenTag)
                    result.Append($"<{currentTag.Tag.Html}>");
                else
                    result.Append($"</{currentTag.Tag.Html}>");
                currentPosition = currentTag.Position + currentTag.Tag.Markdown.Length;

                currentPosition = currentPosition >= Value.Length ? Value.Length - 1 : currentPosition;
            }

            result.Append(Value.Substring(tagList.Last().Position + tagList.Last().Tag.Markdown.Length)); // add remaining string after last tag

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
    private bool HasPreviouslyOpenTag(IList<(int Position, bool IsOpenTag, (string Markdown, string Html) Tag)> tagList, string tag)
    {
        for (int i = tagList.Count - 1; i >= 0; i--)
        {
            if (tagList[i].Tag.Markdown == tag)
            {
                if (tagList[i].IsOpenTag)
                    return true;
                return false;
            }
        }

        return false;
    }
}