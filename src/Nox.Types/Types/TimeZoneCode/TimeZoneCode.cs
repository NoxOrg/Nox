using System.Collections.Generic;

namespace Nox.Types;

    /// <summary>
    /// Represents a Nox <see cref="TimeZoneCode"/> type and value object.
    /// </summary>
public sealed class TimeZoneCode : ValueObject<string, TimeZoneCode>
{
    private static readonly HashSet<string> _timeZoneCodes = new() { 
        "ACDT","ACST","ACT","ADT","AEDT","AEST","AET","AFT","AKDT","AKST","ALMT",
        "AMST","AMT","ANAT","AQTT","ART","AST","AWST","AZOST","AZOT","AZT","BNT",
        "BIOT","BIT","BOT","BRST","BRT","BST","BTT","CAT","CCT","CDT","CEST","CET",
        "CHADT","CHAST","CHOT","CHOST","CHST","CHUT","CIST","CKT","CLST","CLT","COST",
        "COT","CST","CT","CVT","CWST","CXT","DAVT","DDUT","DFT","EASST","EAST","EAT",
        "ECT","EDT","EEST","EET","EGST","EGT","EST","ET","FET","FJT","FKST","FKT",
        "FNT","GALT","GAMT","GET","GFT","GILT","GIT","GMT","GST","GYT","HDT","HAEC",
        "HST","HKT","HMT","HOVST","HOVT","ICT","IDLW","IDT","IOT","IRDT","IRKT","IRST",
        "IST","JST","KALT","KGT","KOST","KRAT","KST","LHST","LINT","MAGT","MART","MAWT",
        "MDT","MET","MEST","MHT","MIST","MIT","MMT","MSK","MST","MUT","MVT","MYT",
        "NCT","NDT","NFT","NOVT","NPT","NST","NT","NUT","NZDT","NZST","OMST",
        "ORAT","PDT","PET","PETT","PGT","PHOT","PHT","PHST","PKT","PMDT","PMST",
        "PONT","PST","PWT","PYST","PYT","RET","ROTT","SAKT","SAMT","SAST","SBT","SCT",
        "SDT","SGT","SLST","SRET","SRT","SST","SYOT","TAHT","THA","TFT","TJT","TKT",
        "TLT","TMT","TRT","TOT","TVT","ULAST","ULAT","UTC","UYST","UYT","UZT","VET",
        "VLAT","VOLT","VOST","VUT","WAKT","WAST","WAT","WEST","WET","WIB","WIT","WITA",
        "WGST","WGT","WST","YAKT","YEKT"
     };
    /// <summary>
    /// Sets the value to upper case with invariant culture.
    /// </summary>
    public override string Value { protected set => base.Value = value.ToUpperInvariant(); }


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_timeZoneCodes.Contains(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox TimeZoneCode type with unsupported value '{Value}'."));
        }

        return result;
    }
}
