using Nox.Yaml.Attributes;

namespace Nox.Types;

public enum Culture
{
    /// <summary>
    /// Afrikaans
    /// </summary>
    [DisplayName("af")]
    af,
    /// <summary>
    /// Afrikaans (Namibia)
    /// </summary>
    [DisplayName("af-NA")]
    af_NA,
    /// <summary>
    /// Afrikaans (South Africa)
    /// </summary>
    [DisplayName("af-ZA")]
    af_ZA,
    /// <summary>
    /// Aghem
    /// </summary>
    [DisplayName("agq")]
    agq,
    /// <summary>
    /// Aghem (Cameroon)
    /// </summary>
    [DisplayName("agq-CM")]
    agq_CM,
    /// <summary>
    /// Akan
    /// </summary>
    [DisplayName("ak")]
    ak,
    /// <summary>
    /// Akan (Ghana)
    /// </summary>
    [DisplayName("ak-GH")]
    ak_GH,
    /// <summary>
    /// Amharic
    /// </summary>
    [DisplayName("am")]
    am,
    /// <summary>
    /// Amharic (Ethiopia)
    /// </summary>
    [DisplayName("am-ET")]
    am_ET,
    /// <summary>
    /// Arabic
    /// </summary>
    [DisplayName("ar")]
    ar,
    /// <summary>
    /// Arabic (World)
    /// </summary>
    [DisplayName("ar-001")]
    ar_001,
    /// <summary>
    /// Arabic (United Arab Emirates)
    /// </summary>
    [DisplayName("ar-AE")]
    ar_AE,
    /// <summary>
    /// Arabic (Bahrain)
    /// </summary>
    [DisplayName("ar-BH")]
    ar_BH,
    /// <summary>
    /// Arabic (Djibouti)
    /// </summary>
    [DisplayName("ar-DJ")]
    ar_DJ,
    /// <summary>
    /// Arabic (Algeria)
    /// </summary>
    [DisplayName("ar-DZ")]
    ar_DZ,
    /// <summary>
    /// Arabic (Egypt)
    /// </summary>
    [DisplayName("ar-EG")]
    ar_EG,
    /// <summary>
    /// Arabic (Western Sahara)
    /// </summary>
    [DisplayName("ar-EH")]
    ar_EH,
    /// <summary>
    /// Arabic (Eritrea)
    /// </summary>
    [DisplayName("ar-ER")]
    ar_ER,
    /// <summary>
    /// Arabic (Israel)
    /// </summary>
    [DisplayName("ar-IL")]
    ar_IL,
    /// <summary>
    /// Arabic (Iraq)
    /// </summary>
    [DisplayName("ar-IQ")]
    ar_IQ,
    /// <summary>
    /// Arabic (Jordan)
    /// </summary>
    [DisplayName("ar-JO")]
    ar_JO,
    /// <summary>
    /// Arabic (Comoros)
    /// </summary>
    [DisplayName("ar-KM")]
    ar_KM,
    /// <summary>
    /// Arabic (Kuwait)
    /// </summary>
    [DisplayName("ar-KW")]
    ar_KW,
    /// <summary>
    /// Arabic (Lebanon)
    /// </summary>
    [DisplayName("ar-LB")]
    ar_LB,
    /// <summary>
    /// Arabic (Libya)
    /// </summary>
    [DisplayName("ar-LY")]
    ar_LY,
    /// <summary>
    /// Arabic (Morocco)
    /// </summary>
    [DisplayName("ar-MA")]
    ar_MA,
    /// <summary>
    /// Arabic (Mauritania)
    /// </summary>
    [DisplayName("ar-MR")]
    ar_MR,
    /// <summary>
    /// Arabic (Oman)
    /// </summary>
    [DisplayName("ar-OM")]
    ar_OM,
    /// <summary>
    /// Arabic (Palestinian Territories)
    /// </summary>
    [DisplayName("ar-PS")]
    ar_PS,
    /// <summary>
    /// Arabic (Qatar)
    /// </summary>
    [DisplayName("ar-QA")]
    ar_QA,
    /// <summary>
    /// Arabic (Saudi Arabia)
    /// </summary>
    [DisplayName("ar-SA")]
    ar_SA,
    /// <summary>
    /// Arabic (Sudan)
    /// </summary>
    [DisplayName("ar-SD")]
    ar_SD,
    /// <summary>
    /// Arabic (Somalia)
    /// </summary>
    [DisplayName("ar-SO")]
    ar_SO,
    /// <summary>
    /// Arabic (South Sudan)
    /// </summary>
    [DisplayName("ar-SS")]
    ar_SS,
    /// <summary>
    /// Arabic (Syria)
    /// </summary>
    [DisplayName("ar-SY")]
    ar_SY,
    /// <summary>
    /// Arabic (Chad)
    /// </summary>
    [DisplayName("ar-TD")]
    ar_TD,
    /// <summary>
    /// Arabic (Tunisia)
    /// </summary>
    [DisplayName("ar-TN")]
    ar_TN,
    /// <summary>
    /// Arabic (Yemen)
    /// </summary>
    [DisplayName("ar-YE")]
    ar_YE,
    /// <summary>
    /// Assamese
    /// </summary>
    [DisplayName("as")]
    as_,
    /// <summary>
    /// Assamese (India)
    /// </summary>
    [DisplayName("as-IN")]
    as_IN,
    /// <summary>
    /// Asu
    /// </summary>
    [DisplayName("asa")]
    asa,
    /// <summary>
    /// Asu (Tanzania)
    /// </summary>
    [DisplayName("asa-TZ")]
    asa_TZ,
    /// <summary>
    /// Asturian
    /// </summary>
    [DisplayName("ast")]
    ast,
    /// <summary>
    /// Asturian (Spain)
    /// </summary>
    [DisplayName("ast-ES")]
    ast_ES,
    /// <summary>
    /// Azerbaijani
    /// </summary>
    [DisplayName("az")]
    az,
    /// <summary>
    /// Azerbaijani (Cyrillic)
    /// </summary>
    [DisplayName("az-Cyrl")]
    az_Cyrl,
    /// <summary>
    /// Azerbaijani (Cyrillic, Azerbaijan)
    /// </summary>
    [DisplayName("az-Cyrl-AZ")]
    az_Cyrl_AZ,
    /// <summary>
    /// Azerbaijani (Latin)
    /// </summary>
    [DisplayName("az-Latn")]
    az_Latn,
    /// <summary>
    /// Azerbaijani (Latin, Azerbaijan)
    /// </summary>
    [DisplayName("az-Latn-AZ")]
    az_Latn_AZ,
    /// <summary>
    /// Basaa
    /// </summary>
    [DisplayName("bas")]
    bas,
    /// <summary>
    /// Basaa (Cameroon)
    /// </summary>
    [DisplayName("bas-CM")]
    bas_CM,
    /// <summary>
    /// Belarusian
    /// </summary>
    [DisplayName("be")]
    be,
    /// <summary>
    /// Belarusian (Belarus)
    /// </summary>
    [DisplayName("be-BY")]
    be_BY,
    /// <summary>
    /// Bemba
    /// </summary>
    [DisplayName("bem")]
    bem,
    /// <summary>
    /// Bemba (Zambia)
    /// </summary>
    [DisplayName("bem-ZM")]
    bem_ZM,
    /// <summary>
    /// Bena
    /// </summary>
    [DisplayName("bez")]
    bez,
    /// <summary>
    /// Bena (Tanzania)
    /// </summary>
    [DisplayName("bez-TZ")]
    bez_TZ,
    /// <summary>
    /// Bulgarian
    /// </summary>
    [DisplayName("bg")]
    bg,
    /// <summary>
    /// Bulgarian (Bulgaria)
    /// </summary>
    [DisplayName("bg-BG")]
    bg_BG,
    /// <summary>
    /// Bambara
    /// </summary>
    [DisplayName("bm")]
    bm,
    /// <summary>
    /// Bambara (Mali)
    /// </summary>
    [DisplayName("bm-ML")]
    bm_ML,
    /// <summary>
    /// Bangla
    /// </summary>
    [DisplayName("bn")]
    bn,
    /// <summary>
    /// Bangla (Bangladesh)
    /// </summary>
    [DisplayName("bn-BD")]
    bn_BD,
    /// <summary>
    /// Bangla (India)
    /// </summary>
    [DisplayName("bn-IN")]
    bn_IN,
    /// <summary>
    /// Tibetan
    /// </summary>
    [DisplayName("bo")]
    bo,
    /// <summary>
    /// Tibetan (China)
    /// </summary>
    [DisplayName("bo-CN")]
    bo_CN,
    /// <summary>
    /// Tibetan (India)
    /// </summary>
    [DisplayName("bo-IN")]
    bo_IN,
    /// <summary>
    /// Breton
    /// </summary>
    [DisplayName("br")]
    br,
    /// <summary>
    /// Breton (France)
    /// </summary>
    [DisplayName("br-FR")]
    br_FR,
    /// <summary>
    /// Bodo
    /// </summary>
    [DisplayName("brx")]
    brx,
    /// <summary>
    /// Bodo (India)
    /// </summary>
    [DisplayName("brx-IN")]
    brx_IN,
    /// <summary>
    /// Bosnian
    /// </summary>
    [DisplayName("bs")]
    bs,
    /// <summary>
    /// Bosnian (Cyrillic)
    /// </summary>
    [DisplayName("bs-Cyrl")]
    bs_Cyrl,
    /// <summary>
    /// Bosnian (Cyrillic, Bosnia &amp; Herzegovina)
    /// </summary>
    [DisplayName("bs-Cyrl-BA")]
    bs_Cyrl_BA,
    /// <summary>
    /// Bosnian (Latin)
    /// </summary>
    [DisplayName("bs-Latn")]
    bs_Latn,
    /// <summary>
    /// Bosnian (Latin, Bosnia &amp; Herzegovina)
    /// </summary>
    [DisplayName("bs-Latn-BA")]
    bs_Latn_BA,
    /// <summary>
    /// Catalan
    /// </summary>
    [DisplayName("ca")]
    ca,
    /// <summary>
    /// Catalan (Andorra)
    /// </summary>
    [DisplayName("ca-AD")]
    ca_AD,
    /// <summary>
    /// Catalan (Spain)
    /// </summary>
    [DisplayName("ca-ES")]
    ca_ES,
    /// <summary>
    /// Catalan (France)
    /// </summary>
    [DisplayName("ca-FR")]
    ca_FR,
    /// <summary>
    /// Catalan (Italy)
    /// </summary>
    [DisplayName("ca-IT")]
    ca_IT,
    /// <summary>
    /// Chakma
    /// </summary>
    [DisplayName("ccp")]
    ccp,
    /// <summary>
    /// Chakma (Bangladesh)
    /// </summary>
    [DisplayName("ccp-BD")]
    ccp_BD,
    /// <summary>
    /// Chakma (India)
    /// </summary>
    [DisplayName("ccp-IN")]
    ccp_IN,
    /// <summary>
    /// Chechen
    /// </summary>
    [DisplayName("ce")]
    ce,
    /// <summary>
    /// Chechen (Russia)
    /// </summary>
    [DisplayName("ce-RU")]
    ce_RU,
    /// <summary>
    /// Chiga
    /// </summary>
    [DisplayName("cgg")]
    cgg,
    /// <summary>
    /// Chiga (Uganda)
    /// </summary>
    [DisplayName("cgg-UG")]
    cgg_UG,
    /// <summary>
    /// Cherokee
    /// </summary>
    [DisplayName("chr")]
    chr,
    /// <summary>
    /// Cherokee (United States)
    /// </summary>
    [DisplayName("chr-US")]
    chr_US,
    /// <summary>
    /// Central Kurdish
    /// </summary>
    [DisplayName("ckb")]
    ckb,
    /// <summary>
    /// Central Kurdish (Iraq)
    /// </summary>
    [DisplayName("ckb-IQ")]
    ckb_IQ,
    /// <summary>
    /// Central Kurdish (Iran)
    /// </summary>
    [DisplayName("ckb-IR")]
    ckb_IR,
    /// <summary>
    /// Czech
    /// </summary>
    [DisplayName("cs")]
    cs,
    /// <summary>
    /// Czech (Czechia)
    /// </summary>
    [DisplayName("cs-CZ")]
    cs_CZ,
    /// <summary>
    /// Welsh
    /// </summary>
    [DisplayName("cy")]
    cy,
    /// <summary>
    /// Welsh (United Kingdom)
    /// </summary>
    [DisplayName("cy-GB")]
    cy_GB,
    /// <summary>
    /// Danish
    /// </summary>
    [DisplayName("da")]
    da,
    /// <summary>
    /// Danish (Denmark)
    /// </summary>
    [DisplayName("da-DK")]
    da_DK,
    /// <summary>
    /// Danish (Greenland)
    /// </summary>
    [DisplayName("da-GL")]
    da_GL,
    /// <summary>
    /// Taita
    /// </summary>
    [DisplayName("dav")]
    dav,
    /// <summary>
    /// Taita (Kenya)
    /// </summary>
    [DisplayName("dav-KE")]
    dav_KE,
    /// <summary>
    /// German
    /// </summary>
    [DisplayName("de")]
    de,
    /// <summary>
    /// German (Austria)
    /// </summary>
    [DisplayName("de-AT")]
    de_AT,
    /// <summary>
    /// German (Belgium)
    /// </summary>
    [DisplayName("de-BE")]
    de_BE,
    /// <summary>
    /// German (Switzerland)
    /// </summary>
    [DisplayName("de-CH")]
    de_CH,
    /// <summary>
    /// German (Germany)
    /// </summary>
    [DisplayName("de-DE")]
    de_DE,
    /// <summary>
    /// German (Italy)
    /// </summary>
    [DisplayName("de-IT")]
    de_IT,
    /// <summary>
    /// German (Liechtenstein)
    /// </summary>
    [DisplayName("de-LI")]
    de_LI,
    /// <summary>
    /// German (Luxembourg)
    /// </summary>
    [DisplayName("de-LU")]
    de_LU,
    /// <summary>
    /// Zarma
    /// </summary>
    [DisplayName("dje")]
    dje,
    /// <summary>
    /// Zarma (Niger)
    /// </summary>
    [DisplayName("dje-NE")]
    dje_NE,
    /// <summary>
    /// Lower Sorbian
    /// </summary>
    [DisplayName("dsb")]
    dsb,
    /// <summary>
    /// Lower Sorbian (Germany)
    /// </summary>
    [DisplayName("dsb-DE")]
    dsb_DE,
    /// <summary>
    /// Duala
    /// </summary>
    [DisplayName("dua")]
    dua,
    /// <summary>
    /// Duala (Cameroon)
    /// </summary>
    [DisplayName("dua-CM")]
    dua_CM,
    /// <summary>
    /// Jola-Fonyi
    /// </summary>
    [DisplayName("dyo")]
    dyo,
    /// <summary>
    /// Jola-Fonyi (Senegal)
    /// </summary>
    [DisplayName("dyo-SN")]
    dyo_SN,
    /// <summary>
    /// Dzongkha
    /// </summary>
    [DisplayName("dz")]
    dz,
    /// <summary>
    /// Dzongkha (Bhutan)
    /// </summary>
    [DisplayName("dz-BT")]
    dz_BT,
    /// <summary>
    /// Embu
    /// </summary>
    [DisplayName("ebu")]
    ebu,
    /// <summary>
    /// Embu (Kenya)
    /// </summary>
    [DisplayName("ebu-KE")]
    ebu_KE,
    /// <summary>
    /// Ewe
    /// </summary>
    [DisplayName("ee")]
    ee,
    /// <summary>
    /// Ewe (Ghana)
    /// </summary>
    [DisplayName("ee-GH")]
    ee_GH,
    /// <summary>
    /// Ewe (Togo)
    /// </summary>
    [DisplayName("ee-TG")]
    ee_TG,
    /// <summary>
    /// Greek
    /// </summary>
    [DisplayName("el")]
    el,
    /// <summary>
    /// Greek (Cyprus)
    /// </summary>
    [DisplayName("el-CY")]
    el_CY,
    /// <summary>
    /// Greek (Greece)
    /// </summary>
    [DisplayName("el-GR")]
    el_GR,
    /// <summary>
    /// English
    /// </summary>
    [DisplayName("en")]
    en,
    /// <summary>
    /// English (World)
    /// </summary>
    [DisplayName("en-001")]
    en_001,
    /// <summary>
    /// English (Europe)
    /// </summary>
    [DisplayName("en-150")]
    en_150,
    /// <summary>
    /// English (Antigua &amp; Barbuda)
    /// </summary>
    [DisplayName("en-AG")]
    en_AG,
    /// <summary>
    /// English (Anguilla)
    /// </summary>
    [DisplayName("en-AI")]
    en_AI,
    /// <summary>
    /// English (American Samoa)
    /// </summary>
    [DisplayName("en-AS")]
    en_AS,
    /// <summary>
    /// English (Austria)
    /// </summary>
    [DisplayName("en-AT")]
    en_AT,
    /// <summary>
    /// English (Australia)
    /// </summary>
    [DisplayName("en-AU")]
    en_AU,
    /// <summary>
    /// English (Barbados)
    /// </summary>
    [DisplayName("en-BB")]
    en_BB,
    /// <summary>
    /// English (Belgium)
    /// </summary>
    [DisplayName("en-BE")]
    en_BE,
    /// <summary>
    /// English (Burundi)
    /// </summary>
    [DisplayName("en-BI")]
    en_BI,
    /// <summary>
    /// English (Bermuda)
    /// </summary>
    [DisplayName("en-BM")]
    en_BM,
    /// <summary>
    /// English (Bahamas)
    /// </summary>
    [DisplayName("en-BS")]
    en_BS,
    /// <summary>
    /// English (Botswana)
    /// </summary>
    [DisplayName("en-BW")]
    en_BW,
    /// <summary>
    /// English (Belize)
    /// </summary>
    [DisplayName("en-BZ")]
    en_BZ,
    /// <summary>
    /// English (Canada)
    /// </summary>
    [DisplayName("en-CA")]
    en_CA,
    /// <summary>
    /// English (Cocos [Keeling] Islands)
    /// </summary>
    [DisplayName("en-CC")]
    en_CC,
    /// <summary>
    /// English (Switzerland)
    /// </summary>
    [DisplayName("en-CH")]
    en_CH,
    /// <summary>
    /// English (Cook Islands)
    /// </summary>
    [DisplayName("en-CK")]
    en_CK,
    /// <summary>
    /// English (Cameroon)
    /// </summary>
    [DisplayName("en-CM")]
    en_CM,
    /// <summary>
    /// English (Christmas Island)
    /// </summary>
    [DisplayName("en-CX")]
    en_CX,
    /// <summary>
    /// English (Cyprus)
    /// </summary>
    [DisplayName("en-CY")]
    en_CY,
    /// <summary>
    /// English (Germany)
    /// </summary>
    [DisplayName("en-DE")]
    en_DE,
    /// <summary>
    /// English (Diego Garcia)
    /// </summary>
    [DisplayName("en-DG")]
    en_DG,
    /// <summary>
    /// English (Denmark)
    /// </summary>
    [DisplayName("en-DK")]
    en_DK,
    /// <summary>
    /// English (Dominica)
    /// </summary>
    [DisplayName("en-DM")]
    en_DM,
    /// <summary>
    /// English (Eritrea)
    /// </summary>
    [DisplayName("en-ER")]
    en_ER,
    /// <summary>
    /// English (Finland)
    /// </summary>
    [DisplayName("en-FI")]
    en_FI,
    /// <summary>
    /// English (Fiji)
    /// </summary>
    [DisplayName("en-FJ")]
    en_FJ,
    /// <summary>
    /// English (Falkland Islands)
    /// </summary>
    [DisplayName("en-FK")]
    en_FK,
    /// <summary>
    /// English (Micronesia)
    /// </summary>
    [DisplayName("en-FM")]
    en_FM,
    /// <summary>
    /// English (United Kingdom)
    /// </summary>
    [DisplayName("en-GB")]
    en_GB,
    /// <summary>
    /// English (Grenada)
    /// </summary>
    [DisplayName("en-GD")]
    en_GD,
    /// <summary>
    /// English (Guernsey)
    /// </summary>
    [DisplayName("en-GG")]
    en_GG,
    /// <summary>
    /// English (Ghana)
    /// </summary>
    [DisplayName("en-GH")]
    en_GH,
    /// <summary>
    /// English (Gibraltar)
    /// </summary>
    [DisplayName("en-GI")]
    en_GI,
    /// <summary>
    /// English (Gambia)
    /// </summary>
    [DisplayName("en-GM")]
    en_GM,
    /// <summary>
    /// English (Guam)
    /// </summary>
    [DisplayName("en-GU")]
    en_GU,
    /// <summary>
    /// English (Guyana)
    /// </summary>
    [DisplayName("en-GY")]
    en_GY,
    /// <summary>
    /// English (Hong Kong SAR China)
    /// </summary>
    [DisplayName("en-HK")]
    en_HK,
    /// <summary>
    /// English (Ireland)
    /// </summary>
    [DisplayName("en-IE")]
    en_IE,
    /// <summary>
    /// English (Israel)
    /// </summary>
    [DisplayName("en-IL")]
    en_IL,
    /// <summary>
    /// English (Isle of Man)
    /// </summary>
    [DisplayName("en-IM")]
    en_IM,
    /// <summary>
    /// English (India)
    /// </summary>
    [DisplayName("en-IN")]
    en_IN,
    /// <summary>
    /// English (British Indian Ocean Territory)
    /// </summary>
    [DisplayName("en-IO")]
    en_IO,
    /// <summary>
    /// English (Jersey)
    /// </summary>
    [DisplayName("en-JE")]
    en_JE,
    /// <summary>
    /// English (Jamaica)
    /// </summary>
    [DisplayName("en-JM")]
    en_JM,
    /// <summary>
    /// English (Kenya)
    /// </summary>
    [DisplayName("en-KE")]
    en_KE,
    /// <summary>
    /// English (Kiribati)
    /// </summary>
    [DisplayName("en-KI")]
    en_KI,
    /// <summary>
    /// English (St. Kitts &amp; Nevis)
    /// </summary>
    [DisplayName("en-KN")]
    en_KN,
    /// <summary>
    /// English (Cayman Islands)
    /// </summary>
    [DisplayName("en-KY")]
    en_KY,
    /// <summary>
    /// English (St. Lucia)
    /// </summary>
    [DisplayName("en-LC")]
    en_LC,
    /// <summary>
    /// English (Liberia)
    /// </summary>
    [DisplayName("en-LR")]
    en_LR,
    /// <summary>
    /// English (Lesotho)
    /// </summary>
    [DisplayName("en-LS")]
    en_LS,
    /// <summary>
    /// English (Madagascar)
    /// </summary>
    [DisplayName("en-MG")]
    en_MG,
    /// <summary>
    /// English (Marshall Islands)
    /// </summary>
    [DisplayName("en-MH")]
    en_MH,
    /// <summary>
    /// English (Macau SAR China)
    /// </summary>
    [DisplayName("en-MO")]
    en_MO,
    /// <summary>
    /// English (Northern Mariana Islands)
    /// </summary>
    [DisplayName("en-MP")]
    en_MP,
    /// <summary>
    /// English (Montserrat)
    /// </summary>
    [DisplayName("en-MS")]
    en_MS,
    /// <summary>
    /// English (Malta)
    /// </summary>
    [DisplayName("en-MT")]
    en_MT,
    /// <summary>
    /// English (Mauritius)
    /// </summary>
    [DisplayName("en-MU")]
    en_MU,
    /// <summary>
    /// English (Malawi)
    /// </summary>
    [DisplayName("en-MW")]
    en_MW,
    /// <summary>
    /// English (Malaysia)
    /// </summary>
    [DisplayName("en-MY")]
    en_MY,
    /// <summary>
    /// English (Namibia)
    /// </summary>
    [DisplayName("en-NA")]
    en_NA,
    /// <summary>
    /// English (Norfolk Island)
    /// </summary>
    [DisplayName("en-NF")]
    en_NF,
    /// <summary>
    /// English (Nigeria)
    /// </summary>
    [DisplayName("en-NG")]
    en_NG,
    /// <summary>
    /// English (Netherlands)
    /// </summary>
    [DisplayName("en-NL")]
    en_NL,
    /// <summary>
    /// English (Nauru)
    /// </summary>
    [DisplayName("en-NR")]
    en_NR,
    /// <summary>
    /// English (Niue)
    /// </summary>
    [DisplayName("en-NU")]
    en_NU,
    /// <summary>
    /// English (New Zealand)
    /// </summary>
    [DisplayName("en-NZ")]
    en_NZ,
    /// <summary>
    /// English (Papua New Guinea)
    /// </summary>
    [DisplayName("en-PG")]
    en_PG,
    /// <summary>
    /// English (Philippines)
    /// </summary>
    [DisplayName("en-PH")]
    en_PH,
    /// <summary>
    /// English (Pakistan)
    /// </summary>
    [DisplayName("en-PK")]
    en_PK,
    /// <summary>
    /// English (Pitcairn Islands)
    /// </summary>
    [DisplayName("en-PN")]
    en_PN,
    /// <summary>
    /// English (Puerto Rico)
    /// </summary>
    [DisplayName("en-PR")]
    en_PR,
    /// <summary>
    /// English (Palau)
    /// </summary>
    [DisplayName("en-PW")]
    en_PW,
    /// <summary>
    /// English (Rwanda)
    /// </summary>
    [DisplayName("en-RW")]
    en_RW,
    /// <summary>
    /// English (Solomon Islands)
    /// </summary>
    [DisplayName("en-SB")]
    en_SB,
    /// <summary>
    /// English (Seychelles)
    /// </summary>
    [DisplayName("en-SC")]
    en_SC,
    /// <summary>
    /// English (Sudan)
    /// </summary>
    [DisplayName("en-SD")]
    en_SD,
    /// <summary>
    /// English (Sweden)
    /// </summary>
    [DisplayName("en-SE")]
    en_SE,
    /// <summary>
    /// English (Singapore)
    /// </summary>
    [DisplayName("en-SG")]
    en_SG,
    /// <summary>
    /// English (St. Helena)
    /// </summary>
    [DisplayName("en-SH")]
    en_SH,
    /// <summary>
    /// English (Slovenia)
    /// </summary>
    [DisplayName("en-SI")]
    en_SI,
    /// <summary>
    /// English (Sierra Leone)
    /// </summary>
    [DisplayName("en-SL")]
    en_SL,
    /// <summary>
    /// English (South Sudan)
    /// </summary>
    [DisplayName("en-SS")]
    en_SS,
    /// <summary>
    /// English (Sint Maarten)
    /// </summary>
    [DisplayName("en-SX")]
    en_SX,
    /// <summary>
    /// English (Swaziland)
    /// </summary>
    [DisplayName("en-SZ")]
    en_SZ,
    /// <summary>
    /// English (Turks &amp; Caicos Islands)
    /// </summary>
    [DisplayName("en-TC")]
    en_TC,
    /// <summary>
    /// English (Tokelau)
    /// </summary>
    [DisplayName("en-TK")]
    en_TK,
    /// <summary>
    /// English (Tonga)
    /// </summary>
    [DisplayName("en-TO")]
    en_TO,
    /// <summary>
    /// English (Trinidad &amp; Tobago)
    /// </summary>
    [DisplayName("en-TT")]
    en_TT,
    /// <summary>
    /// English (Tuvalu)
    /// </summary>
    [DisplayName("en-TV")]
    en_TV,
    /// <summary>
    /// English (Tanzania)
    /// </summary>
    [DisplayName("en-TZ")]
    en_TZ,
    /// <summary>
    /// English (Uganda)
    /// </summary>
    [DisplayName("en-UG")]
    en_UG,
    /// <summary>
    /// English (U.S. Outlying Islands)
    /// </summary>
    [DisplayName("en-UM")]
    en_UM,
    /// <summary>
    /// English (United States)
    /// </summary>
    [DisplayName("en-US")]
    en_US,
    /// <summary>
    /// English (United States, Computer)
    /// </summary>
    [DisplayName("en-US-POSIX")]
    en_US_POSIX,
    /// <summary>
    /// English (St. Vincent &amp; Grenadines)
    /// </summary>
    [DisplayName("en-VC")]
    en_VC,
    /// <summary>
    /// English (British Virgin Islands)
    /// </summary>
    [DisplayName("en-VG")]
    en_VG,
    /// <summary>
    /// English (U.S. Virgin Islands)
    /// </summary>
    [DisplayName("en-VI")]
    en_VI,
    /// <summary>
    /// English (Vanuatu)
    /// </summary>
    [DisplayName("en-VU")]
    en_VU,
    /// <summary>
    /// English (Samoa)
    /// </summary>
    [DisplayName("en-WS")]
    en_WS,
    /// <summary>
    /// English (South Africa)
    /// </summary>
    [DisplayName("en-ZA")]
    en_ZA,
    /// <summary>
    /// English (Zambia)
    /// </summary>
    [DisplayName("en-ZM")]
    en_ZM,
    /// <summary>
    /// English (Zimbabwe)
    /// </summary>
    [DisplayName("en-ZW")]
    en_ZW,
    /// <summary>
    /// Esperanto
    /// </summary>
    [DisplayName("eo")]
    eo,
    /// <summary>
    /// Spanish
    /// </summary>
    [DisplayName("es")]
    es,
    /// <summary>
    /// Spanish (Latin America)
    /// </summary>
    [DisplayName("es-419")]
    es_419,
    /// <summary>
    /// Spanish (Argentina)
    /// </summary>
    [DisplayName("es-AR")]
    es_AR,
    /// <summary>
    /// Spanish (Bolivia)
    /// </summary>
    [DisplayName("es-BO")]
    es_BO,
    /// <summary>
    /// Spanish (Brazil)
    /// </summary>
    [DisplayName("es-BR")]
    es_BR,
    /// <summary>
    /// Spanish (Belize)
    /// </summary>
    [DisplayName("es-BZ")]
    es_BZ,
    /// <summary>
    /// Spanish (Chile)
    /// </summary>
    [DisplayName("es-CL")]
    es_CL,
    /// <summary>
    /// Spanish (Colombia)
    /// </summary>
    [DisplayName("es-CO")]
    es_CO,
    /// <summary>
    /// Spanish (Costa Rica)
    /// </summary>
    [DisplayName("es-CR")]
    es_CR,
    /// <summary>
    /// Spanish (Cuba)
    /// </summary>
    [DisplayName("es-CU")]
    es_CU,
    /// <summary>
    /// Spanish (Dominican Republic)
    /// </summary>
    [DisplayName("es-DO")]
    es_DO,
    /// <summary>
    /// Spanish (Ceuta &amp; Melilla)
    /// </summary>
    [DisplayName("es-EA")]
    es_EA,
    /// <summary>
    /// Spanish (Ecuador)
    /// </summary>
    [DisplayName("es-EC")]
    es_EC,
    /// <summary>
    /// Spanish (Spain)
    /// </summary>
    [DisplayName("es-ES")]
    es_ES,
    /// <summary>
    /// Spanish (Equatorial Guinea)
    /// </summary>
    [DisplayName("es-GQ")]
    es_GQ,
    /// <summary>
    /// Spanish (Guatemala)
    /// </summary>
    [DisplayName("es-GT")]
    es_GT,
    /// <summary>
    /// Spanish (Honduras)
    /// </summary>
    [DisplayName("es-HN")]
    es_HN,
    /// <summary>
    /// Spanish (Canary Islands)
    /// </summary>
    [DisplayName("es-IC")]
    es_IC,
    /// <summary>
    /// Spanish (Mexico)
    /// </summary>
    [DisplayName("es-MX")]
    es_MX,
    /// <summary>
    /// Spanish (Nicaragua)
    /// </summary>
    [DisplayName("es-NI")]
    es_NI,
    /// <summary>
    /// Spanish (Panama)
    /// </summary>
    [DisplayName("es-PA")]
    es_PA,
    /// <summary>
    /// Spanish (Peru)
    /// </summary>
    [DisplayName("es-PE")]
    es_PE,
    /// <summary>
    /// Spanish (Philippines)
    /// </summary>
    [DisplayName("es-PH")]
    es_PH,
    /// <summary>
    /// Spanish (Puerto Rico)
    /// </summary>
    [DisplayName("es-PR")]
    es_PR,
    /// <summary>
    /// Spanish (Paraguay)
    /// </summary>
    [DisplayName("es-PY")]
    es_PY,
    /// <summary>
    /// Spanish (El Salvador)
    /// </summary>
    [DisplayName("es-SV")]
    es_SV,
    /// <summary>
    /// Spanish (United States)
    /// </summary>
    [DisplayName("es-US")]
    es_US,
    /// <summary>
    /// Spanish (Uruguay)
    /// </summary>
    [DisplayName("es-UY")]
    es_UY,
    /// <summary>
    /// Spanish (Venezuela)
    /// </summary>
    [DisplayName("es-VE")]
    es_VE,
    /// <summary>
    /// Estonian
    /// </summary>
    [DisplayName("et")]
    et,
    /// <summary>
    /// Estonian (Estonia)
    /// </summary>
    [DisplayName("et-EE")]
    et_EE,
    /// <summary>
    /// Basque
    /// </summary>
    [DisplayName("eu")]
    eu,
    /// <summary>
    /// Basque (Spain)
    /// </summary>
    [DisplayName("eu-ES")]
    eu_ES,
    /// <summary>
    /// Ewondo
    /// </summary>
    [DisplayName("ewo")]
    ewo,
    /// <summary>
    /// Ewondo (Cameroon)
    /// </summary>
    [DisplayName("ewo-CM")]
    ewo_CM,
    /// <summary>
    /// Persian
    /// </summary>
    [DisplayName("fa")]
    fa,
    /// <summary>
    /// Persian (Afghanistan)
    /// </summary>
    [DisplayName("fa-AF")]
    fa_AF,
    /// <summary>
    /// Persian (Iran)
    /// </summary>
    [DisplayName("fa-IR")]
    fa_IR,
    /// <summary>
    /// Fulah
    /// </summary>
    [DisplayName("ff")]
    ff,
    /// <summary>
    /// Fulah (Cameroon)
    /// </summary>
    [DisplayName("ff-CM")]
    ff_CM,
    /// <summary>
    /// Fulah (Guinea)
    /// </summary>
    [DisplayName("ff-GN")]
    ff_GN,
    /// <summary>
    /// Fulah (Mauritania)
    /// </summary>
    [DisplayName("ff-MR")]
    ff_MR,
    /// <summary>
    /// Fulah (Senegal)
    /// </summary>
    [DisplayName("ff-SN")]
    ff_SN,
    /// <summary>
    /// Finnish
    /// </summary>
    [DisplayName("fi")]
    fi,
    /// <summary>
    /// Finnish (Finland)
    /// </summary>
    [DisplayName("fi-FI")]
    fi_FI,
    /// <summary>
    /// Filipino
    /// </summary>
    [DisplayName("fil")]
    fil,
    /// <summary>
    /// Filipino (Philippines)
    /// </summary>
    [DisplayName("fil-PH")]
    fil_PH,
    /// <summary>
    /// Faroese
    /// </summary>
    [DisplayName("fo")]
    fo,
    /// <summary>
    /// Faroese (Denmark)
    /// </summary>
    [DisplayName("fo-DK")]
    fo_DK,
    /// <summary>
    /// Faroese (Faroe Islands)
    /// </summary>
    [DisplayName("fo-FO")]
    fo_FO,
    /// <summary>
    /// French
    /// </summary>
    [DisplayName("fr")]
    fr,
    /// <summary>
    /// French (Belgium)
    /// </summary>
    [DisplayName("fr-BE")]
    fr_BE,
    /// <summary>
    /// French (Burkina Faso)
    /// </summary>
    [DisplayName("fr-BF")]
    fr_BF,
    /// <summary>
    /// French (Burundi)
    /// </summary>
    [DisplayName("fr-BI")]
    fr_BI,
    /// <summary>
    /// French (Benin)
    /// </summary>
    [DisplayName("fr-BJ")]
    fr_BJ,
    /// <summary>
    /// French (St. Barth&#xe9;lemy)
    /// </summary>
    [DisplayName("fr-BL")]
    fr_BL,
    /// <summary>
    /// French (Canada)
    /// </summary>
    [DisplayName("fr-CA")]
    fr_CA,
    /// <summary>
    /// French (Congo - Kinshasa)
    /// </summary>
    [DisplayName("fr-CD")]
    fr_CD,
    /// <summary>
    /// French (Central African Republic)
    /// </summary>
    [DisplayName("fr-CF")]
    fr_CF,
    /// <summary>
    /// French (Congo - Brazzaville)
    /// </summary>
    [DisplayName("fr-CG")]
    fr_CG,
    /// <summary>
    /// French (Switzerland)
    /// </summary>
    [DisplayName("fr-CH")]
    fr_CH,
    /// <summary>
    /// French (C&#xf4;te d&#x2019;Ivoire)
    /// </summary>
    [DisplayName("fr-CI")]
    fr_CI,
    /// <summary>
    /// French (Cameroon)
    /// </summary>
    [DisplayName("fr-CM")]
    fr_CM,
    /// <summary>
    /// French (Djibouti)
    /// </summary>
    [DisplayName("fr-DJ")]
    fr_DJ,
    /// <summary>
    /// French (Algeria)
    /// </summary>
    [DisplayName("fr-DZ")]
    fr_DZ,
    /// <summary>
    /// French (France)
    /// </summary>
    [DisplayName("fr-FR")]
    fr_FR,
    /// <summary>
    /// French (Gabon)
    /// </summary>
    [DisplayName("fr-GA")]
    fr_GA,
    /// <summary>
    /// French (French Guiana)
    /// </summary>
    [DisplayName("fr-GF")]
    fr_GF,
    /// <summary>
    /// French (Guinea)
    /// </summary>
    [DisplayName("fr-GN")]
    fr_GN,
    /// <summary>
    /// French (Guadeloupe)
    /// </summary>
    [DisplayName("fr-GP")]
    fr_GP,
    /// <summary>
    /// French (Equatorial Guinea)
    /// </summary>
    [DisplayName("fr-GQ")]
    fr_GQ,
    /// <summary>
    /// French (Haiti)
    /// </summary>
    [DisplayName("fr-HT")]
    fr_HT,
    /// <summary>
    /// French (Comoros)
    /// </summary>
    [DisplayName("fr-KM")]
    fr_KM,
    /// <summary>
    /// French (Luxembourg)
    /// </summary>
    [DisplayName("fr-LU")]
    fr_LU,
    /// <summary>
    /// French (Morocco)
    /// </summary>
    [DisplayName("fr-MA")]
    fr_MA,
    /// <summary>
    /// French (Monaco)
    /// </summary>
    [DisplayName("fr-MC")]
    fr_MC,
    /// <summary>
    /// French (St. Martin)
    /// </summary>
    [DisplayName("fr-MF")]
    fr_MF,
    /// <summary>
    /// French (Madagascar)
    /// </summary>
    [DisplayName("fr-MG")]
    fr_MG,
    /// <summary>
    /// French (Mali)
    /// </summary>
    [DisplayName("fr-ML")]
    fr_ML,
    /// <summary>
    /// French (Martinique)
    /// </summary>
    [DisplayName("fr-MQ")]
    fr_MQ,
    /// <summary>
    /// French (Mauritania)
    /// </summary>
    [DisplayName("fr-MR")]
    fr_MR,
    /// <summary>
    /// French (Mauritius)
    /// </summary>
    [DisplayName("fr-MU")]
    fr_MU,
    /// <summary>
    /// French (New Caledonia)
    /// </summary>
    [DisplayName("fr-NC")]
    fr_NC,
    /// <summary>
    /// French (Niger)
    /// </summary>
    [DisplayName("fr-NE")]
    fr_NE,
    /// <summary>
    /// French (French Polynesia)
    /// </summary>
    [DisplayName("fr-PF")]
    fr_PF,
    /// <summary>
    /// French (St. Pierre &amp; Miquelon)
    /// </summary>
    [DisplayName("fr-PM")]
    fr_PM,
    /// <summary>
    /// French (R&#xe9;union)
    /// </summary>
    [DisplayName("fr-RE")]
    fr_RE,
    /// <summary>
    /// French (Rwanda)
    /// </summary>
    [DisplayName("fr-RW")]
    fr_RW,
    /// <summary>
    /// French (Seychelles)
    /// </summary>
    [DisplayName("fr-SC")]
    fr_SC,
    /// <summary>
    /// French (Senegal)
    /// </summary>
    [DisplayName("fr-SN")]
    fr_SN,
    /// <summary>
    /// French (Syria)
    /// </summary>
    [DisplayName("fr-SY")]
    fr_SY,
    /// <summary>
    /// French (Chad)
    /// </summary>
    [DisplayName("fr-TD")]
    fr_TD,
    /// <summary>
    /// French (Togo)
    /// </summary>
    [DisplayName("fr-TG")]
    fr_TG,
    /// <summary>
    /// French (Tunisia)
    /// </summary>
    [DisplayName("fr-TN")]
    fr_TN,
    /// <summary>
    /// French (Vanuatu)
    /// </summary>
    [DisplayName("fr-VU")]
    fr_VU,
    /// <summary>
    /// French (Wallis &amp; Futuna)
    /// </summary>
    [DisplayName("fr-WF")]
    fr_WF,
    /// <summary>
    /// French (Mayotte)
    /// </summary>
    [DisplayName("fr-YT")]
    fr_YT,
    /// <summary>
    /// Friulian
    /// </summary>
    [DisplayName("fur")]
    fur,
    /// <summary>
    /// Friulian (Italy)
    /// </summary>
    [DisplayName("fur-IT")]
    fur_IT,
    /// <summary>
    /// Western Frisian
    /// </summary>
    [DisplayName("fy")]
    fy,
    /// <summary>
    /// Western Frisian (Netherlands)
    /// </summary>
    [DisplayName("fy-NL")]
    fy_NL,
    /// <summary>
    /// Irish
    /// </summary>
    [DisplayName("ga")]
    ga,
    /// <summary>
    /// Irish (Ireland)
    /// </summary>
    [DisplayName("ga-IE")]
    ga_IE,
    /// <summary>
    /// Scottish Gaelic
    /// </summary>
    [DisplayName("gd")]
    gd,
    /// <summary>
    /// Scottish Gaelic (United Kingdom)
    /// </summary>
    [DisplayName("gd-GB")]
    gd_GB,
    /// <summary>
    /// Galician
    /// </summary>
    [DisplayName("gl")]
    gl,
    /// <summary>
    /// Galician (Spain)
    /// </summary>
    [DisplayName("gl-ES")]
    gl_ES,
    /// <summary>
    /// Swiss German
    /// </summary>
    [DisplayName("gsw")]
    gsw,
    /// <summary>
    /// Swiss German (Switzerland)
    /// </summary>
    [DisplayName("gsw-CH")]
    gsw_CH,
    /// <summary>
    /// Swiss German (France)
    /// </summary>
    [DisplayName("gsw-FR")]
    gsw_FR,
    /// <summary>
    /// Swiss German (Liechtenstein)
    /// </summary>
    [DisplayName("gsw-LI")]
    gsw_LI,
    /// <summary>
    /// Gujarati
    /// </summary>
    [DisplayName("gu")]
    gu,
    /// <summary>
    /// Gujarati (India)
    /// </summary>
    [DisplayName("gu-IN")]
    gu_IN,
    /// <summary>
    /// Gusii
    /// </summary>
    [DisplayName("guz")]
    guz,
    /// <summary>
    /// Gusii (Kenya)
    /// </summary>
    [DisplayName("guz-KE")]
    guz_KE,
    /// <summary>
    /// Manx
    /// </summary>
    [DisplayName("gv")]
    gv,
    /// <summary>
    /// Manx (Isle of Man)
    /// </summary>
    [DisplayName("gv-IM")]
    gv_IM,
    /// <summary>
    /// Hausa
    /// </summary>
    [DisplayName("ha")]
    ha,
    /// <summary>
    /// Hausa (Ghana)
    /// </summary>
    [DisplayName("ha-GH")]
    ha_GH,
    /// <summary>
    /// Hausa (Niger)
    /// </summary>
    [DisplayName("ha-NE")]
    ha_NE,
    /// <summary>
    /// Hausa (Nigeria)
    /// </summary>
    [DisplayName("ha-NG")]
    ha_NG,
    /// <summary>
    /// Hawaiian
    /// </summary>
    [DisplayName("haw")]
    haw,
    /// <summary>
    /// Hawaiian (United States)
    /// </summary>
    [DisplayName("haw-US")]
    haw_US,
    /// <summary>
    /// Hebrew
    /// </summary>
    [DisplayName("he")]
    he,
    /// <summary>
    /// Hebrew (Israel)
    /// </summary>
    [DisplayName("he-IL")]
    he_IL,
    /// <summary>
    /// Hindi
    /// </summary>
    [DisplayName("hi")]
    hi,
    /// <summary>
    /// Hindi (India)
    /// </summary>
    [DisplayName("hi-IN")]
    hi_IN,
    /// <summary>
    /// Croatian
    /// </summary>
    [DisplayName("hr")]
    hr,
    /// <summary>
    /// Croatian (Bosnia &amp; Herzegovina)
    /// </summary>
    [DisplayName("hr-BA")]
    hr_BA,
    /// <summary>
    /// Croatian (Croatia)
    /// </summary>
    [DisplayName("hr-HR")]
    hr_HR,
    /// <summary>
    /// Upper Sorbian
    /// </summary>
    [DisplayName("hsb")]
    hsb,
    /// <summary>
    /// Upper Sorbian (Germany)
    /// </summary>
    [DisplayName("hsb-DE")]
    hsb_DE,
    /// <summary>
    /// Hungarian
    /// </summary>
    [DisplayName("hu")]
    hu,
    /// <summary>
    /// Hungarian (Hungary)
    /// </summary>
    [DisplayName("hu-HU")]
    hu_HU,
    /// <summary>
    /// Armenian
    /// </summary>
    [DisplayName("hy")]
    hy,
    /// <summary>
    /// Armenian (Armenia)
    /// </summary>
    [DisplayName("hy-AM")]
    hy_AM,
    /// <summary>
    /// Indonesian
    /// </summary>
    [DisplayName("id")]
    id,
    /// <summary>
    /// Indonesian (Indonesia)
    /// </summary>
    [DisplayName("id-ID")]
    id_ID,
    /// <summary>
    /// Igbo
    /// </summary>
    [DisplayName("ig")]
    ig,
    /// <summary>
    /// Igbo (Nigeria)
    /// </summary>
    [DisplayName("ig-NG")]
    ig_NG,
    /// <summary>
    /// Sichuan Yi
    /// </summary>
    [DisplayName("ii")]
    ii,
    /// <summary>
    /// Sichuan Yi (China)
    /// </summary>
    [DisplayName("ii-CN")]
    ii_CN,
    /// <summary>
    /// Icelandic
    /// </summary>
    [DisplayName("is")]
    is_,
    /// <summary>
    /// Icelandic (Iceland)
    /// </summary>
    [DisplayName("is-IS")]
    is_IS,
    /// <summary>
    /// Italian
    /// </summary>
    [DisplayName("it")]
    it,
    /// <summary>
    /// Italian (Switzerland)
    /// </summary>
    [DisplayName("it-CH")]
    it_CH,
    /// <summary>
    /// Italian (Italy)
    /// </summary>
    [DisplayName("it-IT")]
    it_IT,
    /// <summary>
    /// Italian (San Marino)
    /// </summary>
    [DisplayName("it-SM")]
    it_SM,
    /// <summary>
    /// Italian (Vatican City)
    /// </summary>
    [DisplayName("it-VA")]
    it_VA,
    /// <summary>
    /// Japanese
    /// </summary>
    [DisplayName("ja")]
    ja,
    /// <summary>
    /// Japanese (Japan)
    /// </summary>
    [DisplayName("ja-JP")]
    ja_JP,
    /// <summary>
    /// Ngomba
    /// </summary>
    [DisplayName("jgo")]
    jgo,
    /// <summary>
    /// Ngomba (Cameroon)
    /// </summary>
    [DisplayName("jgo-CM")]
    jgo_CM,
    /// <summary>
    /// Machame
    /// </summary>
    [DisplayName("jmc")]
    jmc,
    /// <summary>
    /// Machame (Tanzania)
    /// </summary>
    [DisplayName("jmc-TZ")]
    jmc_TZ,
    /// <summary>
    /// Georgian
    /// </summary>
    [DisplayName("ka")]
    ka,
    /// <summary>
    /// Georgian (Georgia)
    /// </summary>
    [DisplayName("ka-GE")]
    ka_GE,
    /// <summary>
    /// Kabyle
    /// </summary>
    [DisplayName("kab")]
    kab,
    /// <summary>
    /// Kabyle (Algeria)
    /// </summary>
    [DisplayName("kab-DZ")]
    kab_DZ,
    /// <summary>
    /// Kamba
    /// </summary>
    [DisplayName("kam")]
    kam,
    /// <summary>
    /// Kamba (Kenya)
    /// </summary>
    [DisplayName("kam-KE")]
    kam_KE,
    /// <summary>
    /// Makonde
    /// </summary>
    [DisplayName("kde")]
    kde,
    /// <summary>
    /// Makonde (Tanzania)
    /// </summary>
    [DisplayName("kde-TZ")]
    kde_TZ,
    /// <summary>
    /// Kabuverdianu
    /// </summary>
    [DisplayName("kea")]
    kea,
    /// <summary>
    /// Kabuverdianu (Cape Verde)
    /// </summary>
    [DisplayName("kea-CV")]
    kea_CV,
    /// <summary>
    /// Koyra Chiini
    /// </summary>
    [DisplayName("khq")]
    khq,
    /// <summary>
    /// Koyra Chiini (Mali)
    /// </summary>
    [DisplayName("khq-ML")]
    khq_ML,
    /// <summary>
    /// Kikuyu
    /// </summary>
    [DisplayName("ki")]
    ki,
    /// <summary>
    /// Kikuyu (Kenya)
    /// </summary>
    [DisplayName("ki-KE")]
    ki_KE,
    /// <summary>
    /// Kazakh
    /// </summary>
    [DisplayName("kk")]
    kk,
    /// <summary>
    /// Kazakh (Kazakhstan)
    /// </summary>
    [DisplayName("kk-KZ")]
    kk_KZ,
    /// <summary>
    /// Kako
    /// </summary>
    [DisplayName("kkj")]
    kkj,
    /// <summary>
    /// Kako (Cameroon)
    /// </summary>
    [DisplayName("kkj-CM")]
    kkj_CM,
    /// <summary>
    /// Kalaallisut
    /// </summary>
    [DisplayName("kl")]
    kl,
    /// <summary>
    /// Kalaallisut (Greenland)
    /// </summary>
    [DisplayName("kl-GL")]
    kl_GL,
    /// <summary>
    /// Kalenjin
    /// </summary>
    [DisplayName("kln")]
    kln,
    /// <summary>
    /// Kalenjin (Kenya)
    /// </summary>
    [DisplayName("kln-KE")]
    kln_KE,
    /// <summary>
    /// Khmer
    /// </summary>
    [DisplayName("km")]
    km,
    /// <summary>
    /// Khmer (Cambodia)
    /// </summary>
    [DisplayName("km-KH")]
    km_KH,
    /// <summary>
    /// Kannada
    /// </summary>
    [DisplayName("kn")]
    kn,
    /// <summary>
    /// Kannada (India)
    /// </summary>
    [DisplayName("kn-IN")]
    kn_IN,
    /// <summary>
    /// Korean
    /// </summary>
    [DisplayName("ko")]
    ko,
    /// <summary>
    /// Korean (North Korea)
    /// </summary>
    [DisplayName("ko-KP")]
    ko_KP,
    /// <summary>
    /// Korean (South Korea)
    /// </summary>
    [DisplayName("ko-KR")]
    ko_KR,
    /// <summary>
    /// Konkani
    /// </summary>
    [DisplayName("kok")]
    kok,
    /// <summary>
    /// Konkani (India)
    /// </summary>
    [DisplayName("kok-IN")]
    kok_IN,
    /// <summary>
    /// Kashmiri
    /// </summary>
    [DisplayName("ks")]
    ks,
    /// <summary>
    /// Kashmiri (India)
    /// </summary>
    [DisplayName("ks-IN")]
    ks_IN,
    /// <summary>
    /// Shambala
    /// </summary>
    [DisplayName("ksb")]
    ksb,
    /// <summary>
    /// Shambala (Tanzania)
    /// </summary>
    [DisplayName("ksb-TZ")]
    ksb_TZ,
    /// <summary>
    /// Bafia
    /// </summary>
    [DisplayName("ksf")]
    ksf,
    /// <summary>
    /// Bafia (Cameroon)
    /// </summary>
    [DisplayName("ksf-CM")]
    ksf_CM,
    /// <summary>
    /// Colognian
    /// </summary>
    [DisplayName("ksh")]
    ksh,
    /// <summary>
    /// Colognian (Germany)
    /// </summary>
    [DisplayName("ksh-DE")]
    ksh_DE,
    /// <summary>
    /// Cornish
    /// </summary>
    [DisplayName("kw")]
    kw,
    /// <summary>
    /// Cornish (United Kingdom)
    /// </summary>
    [DisplayName("kw-GB")]
    kw_GB,
    /// <summary>
    /// Kyrgyz
    /// </summary>
    [DisplayName("ky")]
    ky,
    /// <summary>
    /// Kyrgyz (Kyrgyzstan)
    /// </summary>
    [DisplayName("ky-KG")]
    ky_KG,
    /// <summary>
    /// Langi
    /// </summary>
    [DisplayName("lag")]
    lag,
    /// <summary>
    /// Langi (Tanzania)
    /// </summary>
    [DisplayName("lag-TZ")]
    lag_TZ,
    /// <summary>
    /// Luxembourgish
    /// </summary>
    [DisplayName("lb")]
    lb,
    /// <summary>
    /// Luxembourgish (Luxembourg)
    /// </summary>
    [DisplayName("lb-LU")]
    lb_LU,
    /// <summary>
    /// Ganda
    /// </summary>
    [DisplayName("lg")]
    lg,
    /// <summary>
    /// Ganda (Uganda)
    /// </summary>
    [DisplayName("lg-UG")]
    lg_UG,
    /// <summary>
    /// Lakota
    /// </summary>
    [DisplayName("lkt")]
    lkt,
    /// <summary>
    /// Lakota (United States)
    /// </summary>
    [DisplayName("lkt-US")]
    lkt_US,
    /// <summary>
    /// Lingala
    /// </summary>
    [DisplayName("ln")]
    ln,
    /// <summary>
    /// Lingala (Angola)
    /// </summary>
    [DisplayName("ln-AO")]
    ln_AO,
    /// <summary>
    /// Lingala (Congo - Kinshasa)
    /// </summary>
    [DisplayName("ln-CD")]
    ln_CD,
    /// <summary>
    /// Lingala (Central African Republic)
    /// </summary>
    [DisplayName("ln-CF")]
    ln_CF,
    /// <summary>
    /// Lingala (Congo - Brazzaville)
    /// </summary>
    [DisplayName("ln-CG")]
    ln_CG,
    /// <summary>
    /// Lao
    /// </summary>
    [DisplayName("lo")]
    lo,
    /// <summary>
    /// Lao (Laos)
    /// </summary>
    [DisplayName("lo-LA")]
    lo_LA,
    /// <summary>
    /// Northern Luri
    /// </summary>
    [DisplayName("lrc")]
    lrc,
    /// <summary>
    /// Northern Luri (Iraq)
    /// </summary>
    [DisplayName("lrc-IQ")]
    lrc_IQ,
    /// <summary>
    /// Northern Luri (Iran)
    /// </summary>
    [DisplayName("lrc-IR")]
    lrc_IR,
    /// <summary>
    /// Lithuanian
    /// </summary>
    [DisplayName("lt")]
    lt,
    /// <summary>
    /// Lithuanian (Lithuania)
    /// </summary>
    [DisplayName("lt-LT")]
    lt_LT,
    /// <summary>
    /// Luba-Katanga
    /// </summary>
    [DisplayName("lu")]
    lu,
    /// <summary>
    /// Luba-Katanga (Congo - Kinshasa)
    /// </summary>
    [DisplayName("lu-CD")]
    lu_CD,
    /// <summary>
    /// Luo
    /// </summary>
    [DisplayName("luo")]
    luo,
    /// <summary>
    /// Luo (Kenya)
    /// </summary>
    [DisplayName("luo-KE")]
    luo_KE,
    /// <summary>
    /// Luyia
    /// </summary>
    [DisplayName("luy")]
    luy,
    /// <summary>
    /// Luyia (Kenya)
    /// </summary>
    [DisplayName("luy-KE")]
    luy_KE,
    /// <summary>
    /// Latvian
    /// </summary>
    [DisplayName("lv")]
    lv,
    /// <summary>
    /// Latvian (Latvia)
    /// </summary>
    [DisplayName("lv-LV")]
    lv_LV,
    /// <summary>
    /// Masai
    /// </summary>
    [DisplayName("mas")]
    mas,
    /// <summary>
    /// Masai (Kenya)
    /// </summary>
    [DisplayName("mas-KE")]
    mas_KE,
    /// <summary>
    /// Masai (Tanzania)
    /// </summary>
    [DisplayName("mas-TZ")]
    mas_TZ,
    /// <summary>
    /// Meru
    /// </summary>
    [DisplayName("mer")]
    mer,
    /// <summary>
    /// Meru (Kenya)
    /// </summary>
    [DisplayName("mer-KE")]
    mer_KE,
    /// <summary>
    /// Morisyen
    /// </summary>
    [DisplayName("mfe")]
    mfe,
    /// <summary>
    /// Morisyen (Mauritius)
    /// </summary>
    [DisplayName("mfe-MU")]
    mfe_MU,
    /// <summary>
    /// Malagasy
    /// </summary>
    [DisplayName("mg")]
    mg,
    /// <summary>
    /// Malagasy (Madagascar)
    /// </summary>
    [DisplayName("mg-MG")]
    mg_MG,
    /// <summary>
    /// Makhuwa-Meetto
    /// </summary>
    [DisplayName("mgh")]
    mgh,
    /// <summary>
    /// Makhuwa-Meetto (Mozambique)
    /// </summary>
    [DisplayName("mgh-MZ")]
    mgh_MZ,
    /// <summary>
    /// Meta&#x2bc;
    /// </summary>
    [DisplayName("mgo")]
    mgo,
    /// <summary>
    /// Meta&#x2bc; (Cameroon)
    /// </summary>
    [DisplayName("mgo-CM")]
    mgo_CM,
    /// <summary>
    /// Macedonian
    /// </summary>
    [DisplayName("mk")]
    mk,
    /// <summary>
    /// Macedonian (Macedonia)
    /// </summary>
    [DisplayName("mk-MK")]
    mk_MK,
    /// <summary>
    /// Malayalam
    /// </summary>
    [DisplayName("ml")]
    ml,
    /// <summary>
    /// Malayalam (India)
    /// </summary>
    [DisplayName("ml-IN")]
    ml_IN,
    /// <summary>
    /// Mongolian
    /// </summary>
    [DisplayName("mn")]
    mn,
    /// <summary>
    /// Mongolian (Mongolia)
    /// </summary>
    [DisplayName("mn-MN")]
    mn_MN,
    /// <summary>
    /// Marathi
    /// </summary>
    [DisplayName("mr")]
    mr,
    /// <summary>
    /// Marathi (India)
    /// </summary>
    [DisplayName("mr-IN")]
    mr_IN,
    /// <summary>
    /// Malay
    /// </summary>
    [DisplayName("ms")]
    ms,
    /// <summary>
    /// Malay (Brunei)
    /// </summary>
    [DisplayName("ms-BN")]
    ms_BN,
    /// <summary>
    /// Malay (Malaysia)
    /// </summary>
    [DisplayName("ms-MY")]
    ms_MY,
    /// <summary>
    /// Malay (Singapore)
    /// </summary>
    [DisplayName("ms-SG")]
    ms_SG,
    /// <summary>
    /// Maltese
    /// </summary>
    [DisplayName("mt")]
    mt,
    /// <summary>
    /// Maltese (Malta)
    /// </summary>
    [DisplayName("mt-MT")]
    mt_MT,
    /// <summary>
    /// Mundang
    /// </summary>
    [DisplayName("mua")]
    mua,
    /// <summary>
    /// Mundang (Cameroon)
    /// </summary>
    [DisplayName("mua-CM")]
    mua_CM,
    /// <summary>
    /// Burmese
    /// </summary>
    [DisplayName("my")]
    my,
    /// <summary>
    /// Burmese (Myanmar [Burma])
    /// </summary>
    [DisplayName("my-MM")]
    my_MM,
    /// <summary>
    /// Mazanderani
    /// </summary>
    [DisplayName("mzn")]
    mzn,
    /// <summary>
    /// Mazanderani (Iran)
    /// </summary>
    [DisplayName("mzn-IR")]
    mzn_IR,
    /// <summary>
    /// Nama
    /// </summary>
    [DisplayName("naq")]
    naq,
    /// <summary>
    /// Nama (Namibia)
    /// </summary>
    [DisplayName("naq-NA")]
    naq_NA,
    /// <summary>
    /// Norwegian Bokm&#xe5;l
    /// </summary>
    [DisplayName("nb")]
    nb,
    /// <summary>
    /// Norwegian Bokm&#xe5;l (Norway)
    /// </summary>
    [DisplayName("nb-NO")]
    nb_NO,
    /// <summary>
    /// Norwegian Bokm&#xe5;l (Svalbard &amp; Jan Mayen)
    /// </summary>
    [DisplayName("nb-SJ")]
    nb_SJ,
    /// <summary>
    /// North Ndebele
    /// </summary>
    [DisplayName("nd")]
    nd,
    /// <summary>
    /// North Ndebele (Zimbabwe)
    /// </summary>
    [DisplayName("nd-ZW")]
    nd_ZW,
    /// <summary>
    /// Low German
    /// </summary>
    [DisplayName("nds")]
    nds,
    /// <summary>
    /// Low German (Germany)
    /// </summary>
    [DisplayName("nds-DE")]
    nds_DE,
    /// <summary>
    /// Low German (Netherlands)
    /// </summary>
    [DisplayName("nds-NL")]
    nds_NL,
    /// <summary>
    /// Nepali
    /// </summary>
    [DisplayName("ne")]
    ne,
    /// <summary>
    /// Nepali (India)
    /// </summary>
    [DisplayName("ne-IN")]
    ne_IN,
    /// <summary>
    /// Nepali (Nepal)
    /// </summary>
    [DisplayName("ne-NP")]
    ne_NP,
    /// <summary>
    /// Dutch
    /// </summary>
    [DisplayName("nl")]
    nl,
    /// <summary>
    /// Dutch (Aruba)
    /// </summary>
    [DisplayName("nl-AW")]
    nl_AW,
    /// <summary>
    /// Dutch (Belgium)
    /// </summary>
    [DisplayName("nl-BE")]
    nl_BE,
    /// <summary>
    /// Dutch (Caribbean Netherlands)
    /// </summary>
    [DisplayName("nl-BQ")]
    nl_BQ,
    /// <summary>
    /// Dutch (Cura&#xe7;ao)
    /// </summary>
    [DisplayName("nl-CW")]
    nl_CW,
    /// <summary>
    /// Dutch (Netherlands)
    /// </summary>
    [DisplayName("nl-NL")]
    nl_NL,
    /// <summary>
    /// Dutch (Suriname)
    /// </summary>
    [DisplayName("nl-SR")]
    nl_SR,
    /// <summary>
    /// Dutch (Sint Maarten)
    /// </summary>
    [DisplayName("nl-SX")]
    nl_SX,
    /// <summary>
    /// Kwasio
    /// </summary>
    [DisplayName("nmg")]
    nmg,
    /// <summary>
    /// Kwasio (Cameroon)
    /// </summary>
    [DisplayName("nmg-CM")]
    nmg_CM,
    /// <summary>
    /// Norwegian Nynorsk
    /// </summary>
    [DisplayName("nn")]
    nn,
    /// <summary>
    /// Norwegian Nynorsk (Norway)
    /// </summary>
    [DisplayName("nn-NO")]
    nn_NO,
    /// <summary>
    /// Ngiemboon
    /// </summary>
    [DisplayName("nnh")]
    nnh,
    /// <summary>
    /// Ngiemboon (Cameroon)
    /// </summary>
    [DisplayName("nnh-CM")]
    nnh_CM,
    /// <summary>
    /// Nuer
    /// </summary>
    [DisplayName("nus")]
    nus,
    /// <summary>
    /// Nuer (South Sudan)
    /// </summary>
    [DisplayName("nus-SS")]
    nus_SS,
    /// <summary>
    /// Nyankole
    /// </summary>
    [DisplayName("nyn")]
    nyn,
    /// <summary>
    /// Nyankole (Uganda)
    /// </summary>
    [DisplayName("nyn-UG")]
    nyn_UG,
    /// <summary>
    /// Oromo
    /// </summary>
    [DisplayName("om")]
    om,
    /// <summary>
    /// Oromo (Ethiopia)
    /// </summary>
    [DisplayName("om-ET")]
    om_ET,
    /// <summary>
    /// Oromo (Kenya)
    /// </summary>
    [DisplayName("om-KE")]
    om_KE,
    /// <summary>
    /// Odia
    /// </summary>
    [DisplayName("or")]
    or,
    /// <summary>
    /// Odia (India)
    /// </summary>
    [DisplayName("or-IN")]
    or_IN,
    /// <summary>
    /// Ossetic
    /// </summary>
    [DisplayName("os")]
    os,
    /// <summary>
    /// Ossetic (Georgia)
    /// </summary>
    [DisplayName("os-GE")]
    os_GE,
    /// <summary>
    /// Ossetic (Russia)
    /// </summary>
    [DisplayName("os-RU")]
    os_RU,
    /// <summary>
    /// Punjabi
    /// </summary>
    [DisplayName("pa")]
    pa,
    /// <summary>
    /// Punjabi (Arabic)
    /// </summary>
    [DisplayName("pa-Arab")]
    pa_Arab,
    /// <summary>
    /// Punjabi (Arabic, Pakistan)
    /// </summary>
    [DisplayName("pa-Arab-PK")]
    pa_Arab_PK,
    /// <summary>
    /// Punjabi (Gurmukhi)
    /// </summary>
    [DisplayName("pa-Guru")]
    pa_Guru,
    /// <summary>
    /// Punjabi (Gurmukhi, India)
    /// </summary>
    [DisplayName("pa-Guru-IN")]
    pa_Guru_IN,
    /// <summary>
    /// Polish
    /// </summary>
    [DisplayName("pl")]
    pl,
    /// <summary>
    /// Polish (Poland)
    /// </summary>
    [DisplayName("pl-PL")]
    pl_PL,
    /// <summary>
    /// Pashto
    /// </summary>
    [DisplayName("ps")]
    ps,
    /// <summary>
    /// Pashto (Afghanistan)
    /// </summary>
    [DisplayName("ps-AF")]
    ps_AF,
    /// <summary>
    /// Portuguese
    /// </summary>
    [DisplayName("pt")]
    pt,
    /// <summary>
    /// Portuguese (Angola)
    /// </summary>
    [DisplayName("pt-AO")]
    pt_AO,
    /// <summary>
    /// Portuguese (Brazil)
    /// </summary>
    [DisplayName("pt-BR")]
    pt_BR,
    /// <summary>
    /// Portuguese (Switzerland)
    /// </summary>
    [DisplayName("pt-CH")]
    pt_CH,
    /// <summary>
    /// Portuguese (Cape Verde)
    /// </summary>
    [DisplayName("pt-CV")]
    pt_CV,
    /// <summary>
    /// Portuguese (Equatorial Guinea)
    /// </summary>
    [DisplayName("pt-GQ")]
    pt_GQ,
    /// <summary>
    /// Portuguese (Guinea-Bissau)
    /// </summary>
    [DisplayName("pt-GW")]
    pt_GW,
    /// <summary>
    /// Portuguese (Luxembourg)
    /// </summary>
    [DisplayName("pt-LU")]
    pt_LU,
    /// <summary>
    /// Portuguese (Macau SAR China)
    /// </summary>
    [DisplayName("pt-MO")]
    pt_MO,
    /// <summary>
    /// Portuguese (Mozambique)
    /// </summary>
    [DisplayName("pt-MZ")]
    pt_MZ,
    /// <summary>
    /// Portuguese (Portugal)
    /// </summary>
    [DisplayName("pt-PT")]
    pt_PT,
    /// <summary>
    /// Portuguese (S&#xe3;o Tom&#xe9; &amp; Pr&#xed;ncipe)
    /// </summary>
    [DisplayName("pt-ST")]
    pt_ST,
    /// <summary>
    /// Portuguese (Timor-Leste)
    /// </summary>
    [DisplayName("pt-TL")]
    pt_TL,
    /// <summary>
    /// Quechua
    /// </summary>
    [DisplayName("qu")]
    qu,
    /// <summary>
    /// Quechua (Bolivia)
    /// </summary>
    [DisplayName("qu-BO")]
    qu_BO,
    /// <summary>
    /// Quechua (Ecuador)
    /// </summary>
    [DisplayName("qu-EC")]
    qu_EC,
    /// <summary>
    /// Quechua (Peru)
    /// </summary>
    [DisplayName("qu-PE")]
    qu_PE,
    /// <summary>
    /// Romansh
    /// </summary>
    [DisplayName("rm")]
    rm,
    /// <summary>
    /// Romansh (Switzerland)
    /// </summary>
    [DisplayName("rm-CH")]
    rm_CH,
    /// <summary>
    /// Rundi
    /// </summary>
    [DisplayName("rn")]
    rn,
    /// <summary>
    /// Rundi (Burundi)
    /// </summary>
    [DisplayName("rn-BI")]
    rn_BI,
    /// <summary>
    /// Romanian
    /// </summary>
    [DisplayName("ro")]
    ro,
    /// <summary>
    /// Romanian (Moldova)
    /// </summary>
    [DisplayName("ro-MD")]
    ro_MD,
    /// <summary>
    /// Romanian (Romania)
    /// </summary>
    [DisplayName("ro-RO")]
    ro_RO,
    /// <summary>
    /// Rombo
    /// </summary>
    [DisplayName("rof")]
    rof,
    /// <summary>
    /// Rombo (Tanzania)
    /// </summary>
    [DisplayName("rof-TZ")]
    rof_TZ,
    /// <summary>
    /// Russian
    /// </summary>
    [DisplayName("ru")]
    ru,
    /// <summary>
    /// Russian (Belarus)
    /// </summary>
    [DisplayName("ru-BY")]
    ru_BY,
    /// <summary>
    /// Russian (Kyrgyzstan)
    /// </summary>
    [DisplayName("ru-KG")]
    ru_KG,
    /// <summary>
    /// Russian (Kazakhstan)
    /// </summary>
    [DisplayName("ru-KZ")]
    ru_KZ,
    /// <summary>
    /// Russian (Moldova)
    /// </summary>
    [DisplayName("ru-MD")]
    ru_MD,
    /// <summary>
    /// Russian (Russia)
    /// </summary>
    [DisplayName("ru-RU")]
    ru_RU,
    /// <summary>
    /// Russian (Ukraine)
    /// </summary>
    [DisplayName("ru-UA")]
    ru_UA,
    /// <summary>
    /// Kinyarwanda
    /// </summary>
    [DisplayName("rw")]
    rw,
    /// <summary>
    /// Kinyarwanda (Rwanda)
    /// </summary>
    [DisplayName("rw-RW")]
    rw_RW,
    /// <summary>
    /// Rwa
    /// </summary>
    [DisplayName("rwk")]
    rwk,
    /// <summary>
    /// Rwa (Tanzania)
    /// </summary>
    [DisplayName("rwk-TZ")]
    rwk_TZ,
    /// <summary>
    /// Sakha
    /// </summary>
    [DisplayName("sah")]
    sah,
    /// <summary>
    /// Sakha (Russia)
    /// </summary>
    [DisplayName("sah-RU")]
    sah_RU,
    /// <summary>
    /// Samburu
    /// </summary>
    [DisplayName("saq")]
    saq,
    /// <summary>
    /// Samburu (Kenya)
    /// </summary>
    [DisplayName("saq-KE")]
    saq_KE,
    /// <summary>
    /// Sangu
    /// </summary>
    [DisplayName("sbp")]
    sbp,
    /// <summary>
    /// Sangu (Tanzania)
    /// </summary>
    [DisplayName("sbp-TZ")]
    sbp_TZ,
    /// <summary>
    /// Northern Sami
    /// </summary>
    [DisplayName("se")]
    se,
    /// <summary>
    /// Northern Sami (Finland)
    /// </summary>
    [DisplayName("se-FI")]
    se_FI,
    /// <summary>
    /// Northern Sami (Norway)
    /// </summary>
    [DisplayName("se-NO")]
    se_NO,
    /// <summary>
    /// Northern Sami (Sweden)
    /// </summary>
    [DisplayName("se-SE")]
    se_SE,
    /// <summary>
    /// Sena
    /// </summary>
    [DisplayName("seh")]
    seh,
    /// <summary>
    /// Sena (Mozambique)
    /// </summary>
    [DisplayName("seh-MZ")]
    seh_MZ,
    /// <summary>
    /// Koyraboro Senni
    /// </summary>
    [DisplayName("ses")]
    ses,
    /// <summary>
    /// Koyraboro Senni (Mali)
    /// </summary>
    [DisplayName("ses-ML")]
    ses_ML,
    /// <summary>
    /// Sango
    /// </summary>
    [DisplayName("sg")]
    sg,
    /// <summary>
    /// Sango (Central African Republic)
    /// </summary>
    [DisplayName("sg-CF")]
    sg_CF,
    /// <summary>
    /// Tachelhit
    /// </summary>
    [DisplayName("shi")]
    shi,
    /// <summary>
    /// Tachelhit (Latin)
    /// </summary>
    [DisplayName("shi-Latn")]
    shi_Latn,
    /// <summary>
    /// Tachelhit (Latin, Morocco)
    /// </summary>
    [DisplayName("shi-Latn-MA")]
    shi_Latn_MA,
    /// <summary>
    /// Tachelhit (Tifinagh)
    /// </summary>
    [DisplayName("shi-Tfng")]
    shi_Tfng,
    /// <summary>
    /// Tachelhit (Tifinagh, Morocco)
    /// </summary>
    [DisplayName("shi-Tfng-MA")]
    shi_Tfng_MA,
    /// <summary>
    /// Sinhala
    /// </summary>
    [DisplayName("si")]
    si,
    /// <summary>
    /// Sinhala (Sri Lanka)
    /// </summary>
    [DisplayName("si-LK")]
    si_LK,
    /// <summary>
    /// Slovak
    /// </summary>
    [DisplayName("sk")]
    sk,
    /// <summary>
    /// Slovak (Slovakia)
    /// </summary>
    [DisplayName("sk-SK")]
    sk_SK,
    /// <summary>
    /// Slovenian
    /// </summary>
    [DisplayName("sl")]
    sl,
    /// <summary>
    /// Slovenian (Slovenia)
    /// </summary>
    [DisplayName("sl-SI")]
    sl_SI,
    /// <summary>
    /// Inari Sami
    /// </summary>
    [DisplayName("smn")]
    smn,
    /// <summary>
    /// Inari Sami (Finland)
    /// </summary>
    [DisplayName("smn-FI")]
    smn_FI,
    /// <summary>
    /// Shona
    /// </summary>
    [DisplayName("sn")]
    sn,
    /// <summary>
    /// Shona (Zimbabwe)
    /// </summary>
    [DisplayName("sn-ZW")]
    sn_ZW,
    /// <summary>
    /// Somali
    /// </summary>
    [DisplayName("so")]
    so,
    /// <summary>
    /// Somali (Djibouti)
    /// </summary>
    [DisplayName("so-DJ")]
    so_DJ,
    /// <summary>
    /// Somali (Ethiopia)
    /// </summary>
    [DisplayName("so-ET")]
    so_ET,
    /// <summary>
    /// Somali (Kenya)
    /// </summary>
    [DisplayName("so-KE")]
    so_KE,
    /// <summary>
    /// Somali (Somalia)
    /// </summary>
    [DisplayName("so-SO")]
    so_SO,
    /// <summary>
    /// Albanian
    /// </summary>
    [DisplayName("sq")]
    sq,
    /// <summary>
    /// Albanian (Albania)
    /// </summary>
    [DisplayName("sq-AL")]
    sq_AL,
    /// <summary>
    /// Albanian (Macedonia)
    /// </summary>
    [DisplayName("sq-MK")]
    sq_MK,
    /// <summary>
    /// Albanian (Kosovo)
    /// </summary>
    [DisplayName("sq-XK")]
    sq_XK,
    /// <summary>
    /// Serbian
    /// </summary>
    [DisplayName("sr")]
    sr,
    /// <summary>
    /// Serbian (Cyrillic)
    /// </summary>
    [DisplayName("sr-Cyrl")]
    sr_Cyrl,
    /// <summary>
    /// Serbian (Cyrillic, Bosnia &amp; Herzegovina)
    /// </summary>
    [DisplayName("sr-Cyrl-BA")]
    sr_Cyrl_BA,
    /// <summary>
    /// Serbian (Cyrillic, Montenegro)
    /// </summary>
    [DisplayName("sr-Cyrl-ME")]
    sr_Cyrl_ME,
    /// <summary>
    /// Serbian (Cyrillic, Serbia)
    /// </summary>
    [DisplayName("sr-Cyrl-RS")]
    sr_Cyrl_RS,
    /// <summary>
    /// Serbian (Cyrillic, Kosovo)
    /// </summary>
    [DisplayName("sr-Cyrl-XK")]
    sr_Cyrl_XK,
    /// <summary>
    /// Serbian (Latin)
    /// </summary>
    [DisplayName("sr-Latn")]
    sr_Latn,
    /// <summary>
    /// Serbian (Latin, Bosnia &amp; Herzegovina)
    /// </summary>
    [DisplayName("sr-Latn-BA")]
    sr_Latn_BA,
    /// <summary>
    /// Serbian (Latin, Montenegro)
    /// </summary>
    [DisplayName("sr-Latn-ME")]
    sr_Latn_ME,
    /// <summary>
    /// Serbian (Latin, Serbia)
    /// </summary>
    [DisplayName("sr-Latn-RS")]
    sr_Latn_RS,
    /// <summary>
    /// Serbian (Latin, Kosovo)
    /// </summary>
    [DisplayName("sr-Latn-XK")]
    sr_Latn_XK,
    /// <summary>
    /// Swedish
    /// </summary>
    [DisplayName("sv")]
    sv,
    /// <summary>
    /// Swedish (&#xc5;land Islands)
    /// </summary>
    [DisplayName("sv-AX")]
    sv_AX,
    /// <summary>
    /// Swedish (Finland)
    /// </summary>
    [DisplayName("sv-FI")]
    sv_FI,
    /// <summary>
    /// Swedish (Sweden)
    /// </summary>
    [DisplayName("sv-SE")]
    sv_SE,
    /// <summary>
    /// Swahili
    /// </summary>
    [DisplayName("sw")]
    sw,
    /// <summary>
    /// Swahili (Congo - Kinshasa)
    /// </summary>
    [DisplayName("sw-CD")]
    sw_CD,
    /// <summary>
    /// Swahili (Kenya)
    /// </summary>
    [DisplayName("sw-KE")]
    sw_KE,
    /// <summary>
    /// Swahili (Tanzania)
    /// </summary>
    [DisplayName("sw-TZ")]
    sw_TZ,
    /// <summary>
    /// Swahili (Uganda)
    /// </summary>
    [DisplayName("sw-UG")]
    sw_UG,
    /// <summary>
    /// Tamil
    /// </summary>
    [DisplayName("ta")]
    ta,
    /// <summary>
    /// Tamil (India)
    /// </summary>
    [DisplayName("ta-IN")]
    ta_IN,
    /// <summary>
    /// Tamil (Sri Lanka)
    /// </summary>
    [DisplayName("ta-LK")]
    ta_LK,
    /// <summary>
    /// Tamil (Malaysia)
    /// </summary>
    [DisplayName("ta-MY")]
    ta_MY,
    /// <summary>
    /// Tamil (Singapore)
    /// </summary>
    [DisplayName("ta-SG")]
    ta_SG,
    /// <summary>
    /// Telugu
    /// </summary>
    [DisplayName("te")]
    te,
    /// <summary>
    /// Telugu (India)
    /// </summary>
    [DisplayName("te-IN")]
    te_IN,
    /// <summary>
    /// Teso
    /// </summary>
    [DisplayName("teo")]
    teo,
    /// <summary>
    /// Teso (Kenya)
    /// </summary>
    [DisplayName("teo-KE")]
    teo_KE,
    /// <summary>
    /// Teso (Uganda)
    /// </summary>
    [DisplayName("teo-UG")]
    teo_UG,
    /// <summary>
    /// Tajik
    /// </summary>
    [DisplayName("tg")]
    tg,
    /// <summary>
    /// Tajik (Tajikistan)
    /// </summary>
    [DisplayName("tg-TJ")]
    tg_TJ,
    /// <summary>
    /// Thai
    /// </summary>
    [DisplayName("th")]
    th,
    /// <summary>
    /// Thai (Thailand)
    /// </summary>
    [DisplayName("th-TH")]
    th_TH,
    /// <summary>
    /// Tigrinya
    /// </summary>
    [DisplayName("ti")]
    ti,
    /// <summary>
    /// Tigrinya (Eritrea)
    /// </summary>
    [DisplayName("ti-ER")]
    ti_ER,
    /// <summary>
    /// Tigrinya (Ethiopia)
    /// </summary>
    [DisplayName("ti-ET")]
    ti_ET,
    /// <summary>
    /// Tongan
    /// </summary>
    [DisplayName("to")]
    to,
    /// <summary>
    /// Tongan (Tonga)
    /// </summary>
    [DisplayName("to-TO")]
    to_TO,
    /// <summary>
    /// Turkish
    /// </summary>
    [DisplayName("tr")]
    tr,
    /// <summary>
    /// Turkish (Cyprus)
    /// </summary>
    [DisplayName("tr-CY")]
    tr_CY,
    /// <summary>
    /// Turkish (Turkey)
    /// </summary>
    [DisplayName("tr-TR")]
    tr_TR,
    /// <summary>
    /// Tatar
    /// </summary>
    [DisplayName("tt")]
    tt,
    /// <summary>
    /// Tatar (Russia)
    /// </summary>
    [DisplayName("tt-RU")]
    tt_RU,
    /// <summary>
    /// Tasawaq
    /// </summary>
    [DisplayName("twq")]
    twq,
    /// <summary>
    /// Tasawaq (Niger)
    /// </summary>
    [DisplayName("twq-NE")]
    twq_NE,
    /// <summary>
    /// Central Atlas Tamazight
    /// </summary>
    [DisplayName("tzm")]
    tzm,
    /// <summary>
    /// Central Atlas Tamazight (Morocco)
    /// </summary>
    [DisplayName("tzm-MA")]
    tzm_MA,
    /// <summary>
    /// Uyghur
    /// </summary>
    [DisplayName("ug")]
    ug,
    /// <summary>
    /// Uyghur (China)
    /// </summary>
    [DisplayName("ug-CN")]
    ug_CN,
    /// <summary>
    /// Ukrainian
    /// </summary>
    [DisplayName("uk")]
    uk,
    /// <summary>
    /// Ukrainian (Ukraine)
    /// </summary>
    [DisplayName("uk-UA")]
    uk_UA,
    /// <summary>
    /// Urdu
    /// </summary>
    [DisplayName("ur")]
    ur,
    /// <summary>
    /// Urdu (India)
    /// </summary>
    [DisplayName("ur-IN")]
    ur_IN,
    /// <summary>
    /// Urdu (Pakistan)
    /// </summary>
    [DisplayName("ur-PK")]
    ur_PK,
    /// <summary>
    /// Uzbek
    /// </summary>
    [DisplayName("uz")]
    uz,
    /// <summary>
    /// Uzbek (Arabic)
    /// </summary>
    [DisplayName("uz-Arab")]
    uz_Arab,
    /// <summary>
    /// Uzbek (Arabic, Afghanistan)
    /// </summary>
    [DisplayName("uz-Arab-AF")]
    uz_Arab_AF,
    /// <summary>
    /// Uzbek (Cyrillic)
    /// </summary>
    [DisplayName("uz-Cyrl")]
    uz_Cyrl,
    /// <summary>
    /// Uzbek (Cyrillic, Uzbekistan)
    /// </summary>
    [DisplayName("uz-Cyrl-UZ")]
    uz_Cyrl_UZ,
    /// <summary>
    /// Uzbek (Latin)
    /// </summary>
    [DisplayName("uz-Latn")]
    uz_Latn,
    /// <summary>
    /// Uzbek (Latin, Uzbekistan)
    /// </summary>
    [DisplayName("uz-Latn-UZ")]
    uz_Latn_UZ,
    /// <summary>
    /// Vai
    /// </summary>
    [DisplayName("vai")]
    vai,
    /// <summary>
    /// Vai (Latin)
    /// </summary>
    [DisplayName("vai-Latn")]
    vai_Latn,
    /// <summary>
    /// Vai (Latin, Liberia)
    /// </summary>
    [DisplayName("vai-Latn-LR")]
    vai_Latn_LR,
    /// <summary>
    /// Vai (Vai)
    /// </summary>
    [DisplayName("vai-Vaii")]
    vai_Vaii,
    /// <summary>
    /// Vai (Vai, Liberia)
    /// </summary>
    [DisplayName("vai-Vaii-LR")]
    vai_Vaii_LR,
    /// <summary>
    /// Vietnamese
    /// </summary>
    [DisplayName("vi")]
    vi,
    /// <summary>
    /// Vietnamese (Vietnam)
    /// </summary>
    [DisplayName("vi-VN")]
    vi_VN,
    /// <summary>
    /// Vunjo
    /// </summary>
    [DisplayName("vun")]
    vun,
    /// <summary>
    /// Vunjo (Tanzania)
    /// </summary>
    [DisplayName("vun-TZ")]
    vun_TZ,
    /// <summary>
    /// Walser
    /// </summary>
    [DisplayName("wae")]
    wae,
    /// <summary>
    /// Walser (Switzerland)
    /// </summary>
    [DisplayName("wae-CH")]
    wae_CH,
    /// <summary>
    /// Wolof
    /// </summary>
    [DisplayName("wo")]
    wo,
    /// <summary>
    /// Wolof (Senegal)
    /// </summary>
    [DisplayName("wo-SN")]
    wo_SN,
    /// <summary>
    /// Soga
    /// </summary>
    [DisplayName("xog")]
    xog,
    /// <summary>
    /// Soga (Uganda)
    /// </summary>
    [DisplayName("xog-UG")]
    xog_UG,
    /// <summary>
    /// Yangben
    /// </summary>
    [DisplayName("yav")]
    yav,
    /// <summary>
    /// Yangben (Cameroon)
    /// </summary>
    [DisplayName("yav-CM")]
    yav_CM,
    /// <summary>
    /// Yiddish
    /// </summary>
    [DisplayName("yi")]
    yi,
    /// <summary>
    /// Yiddish (World)
    /// </summary>
    [DisplayName("yi-001")]
    yi_001,
    /// <summary>
    /// Yoruba
    /// </summary>
    [DisplayName("yo")]
    yo,
    /// <summary>
    /// Yoruba (Benin)
    /// </summary>
    [DisplayName("yo-BJ")]
    yo_BJ,
    /// <summary>
    /// Yoruba (Nigeria)
    /// </summary>
    [DisplayName("yo-NG")]
    yo_NG,
    /// <summary>
    /// Cantonese
    /// </summary>
    [DisplayName("yue")]
    yue,
    /// <summary>
    /// Cantonese (Simplified)
    /// </summary>
    [DisplayName("yue-Hans")]
    yue_Hans,
    /// <summary>
    /// Cantonese (Simplified, China)
    /// </summary>
    [DisplayName("yue-Hans-CN")]
    yue_Hans_CN,
    /// <summary>
    /// Cantonese (Traditional)
    /// </summary>
    [DisplayName("yue-Hant")]
    yue_Hant,
    /// <summary>
    /// Cantonese (Traditional, Hong Kong SAR China)
    /// </summary>
    [DisplayName("yue-Hant-HK")]
    yue_Hant_HK,
    /// <summary>
    /// Standard Moroccan Tamazight
    /// </summary>
    [DisplayName("zgh")]
    zgh,
    /// <summary>
    /// Standard Moroccan Tamazight (Morocco)
    /// </summary>
    [DisplayName("zgh-MA")]
    zgh_MA,
    /// <summary>
    /// Chinese
    /// </summary>
    [DisplayName("zh")]
    zh,
    /// <summary>
    /// Chinese (Simplified)
    /// </summary>
    [DisplayName("zh-Hans")]
    zh_Hans,
    /// <summary>
    /// Chinese (Simplified, China)
    /// </summary>
    [DisplayName("zh-Hans-CN")]
    zh_Hans_CN,
    /// <summary>
    /// Chinese (Simplified, Hong Kong SAR China)
    /// </summary>
    [DisplayName("zh-Hans-HK")]
    zh_Hans_HK,
    /// <summary>
    /// Chinese (Simplified, Macau SAR China)
    /// </summary>
    [DisplayName("zh-Hans-MO")]
    zh_Hans_MO,
    /// <summary>
    /// Chinese (Simplified, Singapore)
    /// </summary>
    [DisplayName("zh-Hans-SG")]
    zh_Hans_SG,
    /// <summary>
    /// Chinese (Traditional)
    /// </summary>
    [DisplayName("zh-Hant")]
    zh_Hant,
    /// <summary>
    /// Chinese (Traditional, Hong Kong SAR China)
    /// </summary>
    [DisplayName("zh-Hant-HK")]
    zh_Hant_HK,
    /// <summary>
    /// Chinese (Traditional, Macau SAR China)
    /// </summary>
    [DisplayName("zh-Hant-MO")]
    zh_Hant_MO,
    /// <summary>
    /// Chinese (Traditional, Taiwan)
    /// </summary>
    [DisplayName("zh-Hant-TW")]
    zh_Hant_TW,
    /// <summary>
    /// Zulu
    /// </summary>
    [DisplayName("zu")]
    zu,
    /// <summary>
    /// Zulu (South Africa)
    /// </summary>
    [DisplayName("zu-ZA")]
    zu_ZA,
}
