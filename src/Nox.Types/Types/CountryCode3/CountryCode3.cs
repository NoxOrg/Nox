using System;
using System.Text.RegularExpressions;

namespace Nox.Types;
/// <summary>
///   Class for two-letter country codes (ISO alpha-3).
/// </summary>
public sealed class CountryCode3 : ValueObject<string, CountryCode3>
{
    private static readonly Regex _countryCode3Regex = new(@"^A(BW|FG|GO|IA|L[AB]|N[DT]|R[EGM]|SM|T[AFG]|U[ST]|ZE)|B(DI|E[LNS]|FA|G[DR]|H[RS]|IH|L[MRZ]|MU|OL|R[ABN]|TN|VT|WA)|C(A[FN]|CK|H[ELN]|IV|MR|O[DGKLM]|PV|RI|U[BW]|XR|Y[MP]|ZE)|D(EU|JI|MA|NK|OM|ZA)|E(CU|GY|RI|S[HPT]|TH)|F(IN|JI|LK|R[AO]|SM)|G(AB|BR|EO|GY|HA|I[BN]|LP|MB|N[BQ]|R[CDL]|TM|U[FMY])|H(KG|MD|ND|RV|TI|UN)|I(DN|MN|ND|OT|R[LNQ]|S[LR]|TA)|J(AM|EY|OR|PN)|K(AZ|EN|GZ|HM|IR|NA|OR|WT)|L(AO|B[NRY]|CA|IE|KA|SO|TU|UX|VA)|M(A[CFR]|CO|D[AGV]|EX|HL|KD|L[IT]|MR|N[EGP]|OZ|RT|SR|TQ|US|WI|Y[ST])|N(AM|CL|ER|FK|GA|I[CU]|LD|OR|PL|RU|ZL)|OMN|P(A[KN]|CN|ER|HL|LW|NG|OL|R[IKTY]|SE|YF)|QAT|R(EU|OU|US|WA)|S(AU|DN|EN|G[PS]|HN|JM|L[BEV]|MR|OM|PM|RB|SD|TP|UR|V[KN]|W[EZ]|XM|Y[CR])|T(C[AD]|GO|HA|JK|K[LM]|LS|ON|TO|U[NRV]|WN|ZA)|U(GA|KR|MI|RY|SA|ZB)|V(AT|CT|EN|GB|IR|NM|UT)|W(LF|SM)|YEM|Z(AF|MB|WE)$", RegexOptions.Compiled, new TimeSpan(0, 0, 1));

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if(!_countryCode3Regex.IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox CountryCode3 type with unsupported value '{Value}'."));
        }

        return result;
    }
}
