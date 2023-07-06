using System.Collections.Generic;

namespace Nox.Types;
public static class ValidLanguage
{
    private static readonly HashSet<string> ValidLanguages = new()
    {
        "Abkhazian", "Afar", "Afrikaans", "Akan", "Albanian", "Amharic", "Arabic", "Aragonese", "Armenian", "Assamese", "Avaric",
        "Avestan", "Aymara", "Azerbaijani", "Bambara", "Bashkir", "Basque", "Belarusian", "Bengali", "Bihari", "Bislama",
        "Bosnian", "Breton", "Bulgarian", "Burmese", "Catalan", "Chamorro", "Chechen", "Chichewa", "Chinese", "Chuvash", "Cornish",
        "Corsican", "Cree", "Croatian", "Czech", "Danish", "Divehi", "Dutch", "Dzongkha", "English", "Esperanto", "Estonian",
        "Ewe", "Faroese", "Fijian", "Finnish", "French", "Fulah", "Galician", "Georgian", "German", "Greek", "Guarani",
        "Gujarati", "Haitian", "Hausa", "Hebrew", "Herero", "Hindi", "Hiri Motu", "Hungarian", "Interlingua", "Indonesian",
        "Interlingue", "Irish", "Igbo", "Inupiaq", "Ido", "Icelandic", "Italian", "Inuktitut", "Japanese", "Javanese", "Kalaallisut",
        "Kannada", "Kanuri", "Kashmiri", "Kazakh", "Khmer", "Kikuyu", "Kinyarwanda", "Kirghiz", "Komi", "Kongo", "Korean",
        "Kurdish", "Kwanyama", "Latin", "Luxembourgish", "Ganda", "Limburgish", "Lingala", "Lao", "Lithuanian", "Luba-Katanga",
        "Latvian", "Manx", "Macedonian", "Malagasy", "Malay", "Malayalam", "Maltese", "Maori", "Marathi", "Marshallese", "Mongolian",
        "Nauru", "Navajo", "North Ndebele", "Nepali", "Ndonga", "Norwegian Bokmål", "Norwegian Nynorsk", "Norwegian", "Nuosu",
        "South Ndebele", "Occitan", "Ojibwa", "Old Church Slavonic", "Oromo", "Oriya", "Ossetian", "Panjabi", "Pali", "Persian",
        "Polish", "Pashto", "Portuguese", "Quechua", "Romansh", "Kirundi", "Romanian",  "Russian", "Sanskrit", "Sardinian", "Sindhi", 
        "Northern Sami", "Samoan", "Sango", "Serbian", "Gaelic", "Shona", "Sinhala", "Slovak", "Slovenian", "Somali", "Southern Sotho", 
        "Spanish", "Sundanese", "Swahili", "Swati", "Swedish", "Tamil", "Telugu", "Tajik", "Thai", "Tigrinya", "Tibetan", "Turkmen", 
        "Tagalog", "Tswana", "Tonga", "Turkish", "Tsonga", "Tatar", "Twi", "Tahitian", "Uighur", "Ukrainian", "Urdu", "Uzbek", "Venda", 
        "Vietnamese", "Volapük", "Walloon", "Welsh", "Wolof", "Western Frisian", "Xhosa", "Yiddish", "Yoruba", "Zhuang", "Zulu"
    };

    public static bool ValidateLanguage(string language) => ValidLanguages.Contains(language);
}
