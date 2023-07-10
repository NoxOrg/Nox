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


                    ((uint)noxType).Should().Be(ToUInt32(id));
                    //Console.WriteLine($"{noxType.ToString()} = {ToUInt32(id)},");
                }
            }
        }
        private static uint ToUInt32(int nuid)
        {
            return (uint)(nuid + int.MaxValue + 1);
        }
    }
}