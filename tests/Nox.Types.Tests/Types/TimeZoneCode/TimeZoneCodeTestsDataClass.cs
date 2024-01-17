using System.Collections;

namespace Nox.Types.Tests.Types;

public class TimeZoneCodeTestsDataClass : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "AFRICA/ABIDJAN" };
        yield return new object[] { "AFRICA/ACCRA" };
        yield return new object[] { "AFRICA/ADDIS_ABABA" };
        yield return new object[] { "AFRICA/ALGIERS" };
        yield return new object[] { "AFRICA/ASMARA" };
        yield return new object[] { "AMERICA/ANGUILLA" };
        yield return new object[] { "AMERICA/ANTIGUA" };
        yield return new object[] { "AMERICA/ARAGUAINA" };
        yield return new object[] { "ASIA/ADEN" };
        yield return new object[] { "ASIA/ALMATY" };
        yield return new object[] { "ASIA/AMMAN" };
        yield return new object[] { "ASIA/ANADYR" };
        yield return new object[] { "ASIA/AQTAU" };
        yield return new object[] { "ASIA/AQTOBE" };
        yield return new object[] { "ASIA/ASHGABAT" };
        yield return new object[] { "ASIA/BAGHDAD" };
        yield return new object[] { "ASIA/BAHRAIN" };
        yield return new object[] { "ASIA/BAKU" };
        yield return new object[] { "ASIA/BANGKOK" };
        yield return new object[] { "ASIA/BARNAUL" };
        yield return new object[] { "ASIA/BEIRUT" };
        yield return new object[] { "ASIA/BISHKEK" };
        yield return new object[] { "ASIA/BRUNEI" };
        yield return new object[] { "ASIA/CHITA" };
        yield return new object[] { "ASIA/CHOIBALSAN" };
        yield return new object[] { "PACIFIC/YAP" };
        yield return new object[] { "POLAND" };
        yield return new object[] { "PORTUGAL" };
        yield return new object[] { "PRC" };
        yield return new object[] { "PST8PDT" };
        yield return new object[] { "ROC" };
        yield return new object[] { "ROK" };
        yield return new object[] { "SINGAPORE" };
        yield return new object[] { "TURKEY" };
        yield return new object[] { "UCT" };
        yield return new object[] { "GMT" };
        yield return new object[] { "UNIVERSAL" };
        yield return new object[] { "US/ALASKA" };
        yield return new object[] { "US/ALEUTIAN" };
        yield return new object[] { "US/ARIZONA" };
        yield return new object[] { "US/CENTRAL" };
        yield return new object[] { "US/EAST-INDIANA" };
        yield return new object[] { "US/EASTERN" };
        yield return new object[] { "US/HAWAII" };
        yield return new object[] { "US/INDIANA-STARKE" };
        yield return new object[] { "US/MICHIGAN" };
        yield return new object[] { "US/MOUNTAIN" };
        yield return new object[] { "US/PACIFIC" };
        yield return new object[] { "US/SAMOA" };
        yield return new object[] { "UTC" };
        yield return new object[] { "W-SU" };
        yield return new object[] { "WET" };
        yield return new object[] { "ZULU" };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

