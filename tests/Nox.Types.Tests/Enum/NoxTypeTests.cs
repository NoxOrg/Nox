using FluentAssertions;
using FluentAssertions.Execution;

namespace Nox.Types.Tests.Enum
{
    public class NoxTypeTests
    {
        [Fact]
        public void NoxType_Value_Is_Nuid()
        {
            const string noxTypeFormatNuid = "Nox.Types.{0}";

            using (new AssertionScope())
            {
                foreach (var noxType in System.Enum.GetValues<NoxType>())
                {
                    var id = Utilities.Identifier.Nuid.ToInt32(string.Format(noxTypeFormatNuid, noxType.ToString()));

                   ((int)noxType).Should().Be(System.Math.Abs(id));
                   // Console.WriteLine($"{noxType.ToString()} = {System.Math.Abs(id)},");
                }
            }
        }
    }
}