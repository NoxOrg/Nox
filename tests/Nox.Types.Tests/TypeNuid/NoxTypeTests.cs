using FluentAssertions;
using FluentAssertions.Execution;
using Xunit.Abstractions;

namespace Nox.Types.Tests.NuidCheck
{
    public class NoxTypeTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public NoxTypeTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void NoxType_Value_Is_Nuid()
        {
            const string noxTypeFormatNuid = "Nox.Types.{0}";

            using (new AssertionScope())
            {
                foreach (var noxType in Enum.GetValues<NoxType>())
                {
                    var id = Utilities.Identifier.Nuid.ToInt32(string.Format(noxTypeFormatNuid, noxType.ToString()));

                    ((uint)noxType).Should().Be(ToUInt32(id));

                    _testOutputHelper.WriteLine($"{noxType} = {ToUInt32(id)},");
                }
            }
        }
        private static uint ToUInt32(int nuid)
        {
            return (uint)(nuid + int.MaxValue + 1);
        }
    }
}