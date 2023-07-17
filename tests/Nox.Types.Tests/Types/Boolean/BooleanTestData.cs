using System.Collections;

namespace Nox.Types.Tests.Types;

public class BooleanTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { true, true };
        yield return new object[] { false, false };
        yield return new object[] { (byte)1, true };
        yield return new object[] { (byte)0, false };
        yield return new object[] { (short)1, true };
        yield return new object[] { (short)0, false };
        yield return new object[] { 1, true };
        yield return new object[] { 0, false };
        yield return new object[] { 1L, true };
        yield return new object[] { 0L, false };
        yield return new object[] { 1f, true };
        yield return new object[] { 0f, false };
        yield return new object[] { 1d, true };
        yield return new object[] { 0d, false };
        yield return new object[] { 1m, true };
        yield return new object[] { 0m, false };
        yield return new object[] { "true", true };
        yield return new object[] { "false", false };
        yield return new object[] { "True", true };
        yield return new object[] { "False", false };
        yield return new object[] { "TRUE", true };
        yield return new object[] { "FALSE", false };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}