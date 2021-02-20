using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CotacaoMoeda.Dominio.Enum
{
    /// <summary>
    /// Enum com os tipos de moedas
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ETipoMoeda
    {
        [EnumMember(Value = "AFN")]
        AFN,
        [EnumMember(Value = "ALL")]
        ALL,
        [EnumMember(Value = "ANG")]
        ANG,
        [EnumMember(Value = "ARS")]
        ARS,
        [EnumMember(Value = "AWG")]
        AWG,
        [EnumMember(Value = "BOB")]
        BOB,
        [EnumMember(Value = "BYN")]
        BYN,
        [EnumMember(Value = "CAD")]
        CAD,
        [EnumMember(Value = "CDF")]
        CDF,
        [EnumMember(Value = "CLP")]
        CLP,
        [EnumMember(Value = "COP")]
        COP,
        [EnumMember(Value = "CRC")]
        CRC,
        [EnumMember(Value = "CUP")]
        CUP,
        [EnumMember(Value = "CVE")]
        CVE,
        [EnumMember(Value = "CZK")]
        CZK,
        [EnumMember(Value = "DJF")]
        DJF,
        [EnumMember(Value = "DZD")]
        DZD,
        [EnumMember(Value = "EGP")]
        EGP,
        [EnumMember(Value = "EUR")]
        EUR,
        [EnumMember(Value = "FJD")]
        FJD,
        [EnumMember(Value = "GBP")]
        GBP,
        [EnumMember(Value = "GEL")]
        GEL,
        [EnumMember(Value = "GIP")]
        GIP,
        [EnumMember(Value = "HTG")]
        HTG,
        [EnumMember(Value = "ILS")]
        ILS,
        [EnumMember(Value = "IRR")]
        IRR,
        [EnumMember(Value = "ISK")]
        ISK,
        [EnumMember(Value = "JPY")]
        JPY,
        [EnumMember(Value = "KES")]
        KES,
        [EnumMember(Value = "KMF")]
        KMF,
        [EnumMember(Value = "LBP")]
        LBP,
        [EnumMember(Value = "LSL")]
        LSL,
        [EnumMember(Value = "MGA")]
        MGA,
        [EnumMember(Value = "MGB")]
        MGB,
        [EnumMember(Value = "MMK")]
        MMK,
        [EnumMember(Value = "MRO")]
        MRO,
        [EnumMember(Value = "MRU")]
        MRU,
        [EnumMember(Value = "MUR")]
        MUR,
        [EnumMember(Value = "MXN")]
        MXN,
        [EnumMember(Value = "MZN")]
        MZN,
        [EnumMember(Value = "NIO")]
        NIO,
        [EnumMember(Value = "NOK")]
        NOK,
        [EnumMember(Value = "OMR")]
        OMR,
        [EnumMember(Value = "PEN")]
        PEN,
        [EnumMember(Value = "PGK")]
        PGK,
        [EnumMember(Value = "PHP")]
        PHP,
        [EnumMember(Value = "RON")]
        RON,
        [EnumMember(Value = "SAR")]
        SAR,
        [EnumMember(Value = "SBD")]
        SBD,
        [EnumMember(Value = "SGD")]
        SGD,
        [EnumMember(Value = "SLL")]
        SLL,
        [EnumMember(Value = "SOS")]
        SOS,
        [EnumMember(Value = "SSP")]
        SSP,
        [EnumMember(Value = "SZL")]
        SZL,
        [EnumMember(Value = "THB")]
        THB,
        [EnumMember(Value = "TRY")]
        TRY,
        [EnumMember(Value = "TTD")]
        TTD,
        [EnumMember(Value = "UGX")]
        UGX,
        [EnumMember(Value = "USD")]
        USD,
        [EnumMember(Value = "UYU")]
        UYU,
        [EnumMember(Value = "VES")]
        VES,
        [EnumMember(Value = "VUV")]
        VUV,
        [EnumMember(Value = "WST")]
        WST,
        [EnumMember(Value = "XAF")]
        XAF,
        [EnumMember(Value = "XAU")]
        XAU,
        [EnumMember(Value = "XDR")]
        XDR,
        [EnumMember(Value = "XOF")]
        XOF,
        [EnumMember(Value = "XPF")]
        XPF,
        [EnumMember(Value = "ZAR")]
        ZAR,
        [EnumMember(Value = "ZWL")]
        ZWL,
    }
}
