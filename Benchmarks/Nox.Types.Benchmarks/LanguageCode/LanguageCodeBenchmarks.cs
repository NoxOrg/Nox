using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Nox.Types.Benchmarks;

[MemoryDiagnoser]
public class LanguageCodeBenchmarks
{

    private static readonly Regex _languageCodeRegex = new(@"^([a][f]|sq|am|[a]r|[h]y|as|eu|[b]e|[b]n|[b]s|[b]r|[b]g|[m]y|[k]m|[c]a|[c]h|[c]e|[n]y|[z]h|[c]o|[h]r|[c]s|[d]a|[n]l|[d]z|[e]n|[e]t|[t]l|[f]i|[f]r|[f]y|[g]l|[k]a|[d]e|[e]l|[g]u|[h]t|[h]a|[h]e|[h]i|[h]u|[i]s|[i]o|[g]a|[i]t|[j]a|[j]v|[k]n|[k]k|[r]w|[k]y|[k]o|[k]u|[l]o|[l]v|[l]t|[l]b|[m]k|[m]g|[m]s|[m]l|[m]t|[m]i|[m]r|[m]n|[n]e|[n]o|[o]r|[p]s|[f]a|[p]l|[p]t|[p]a|[r]o|[r]u|[g]d|[s]r|[g]d|[s]i|[s]k|[s]l|[s]o|[s]o|[e]s|[s]w|[s]v|[t]a|[t]e|[t]h|[t]r|[u]k|[u]r|[v]i|[c]y|[x]h|yi|zu)$", RegexOptions.Compiled);

    private static readonly HashSet<string> _languageCodes = new()
    {
        "aa","ab","af","ak","am","an","ar","as","av","ay","az","ba","be","bg","bh","bi","bm","bn","bo","br","bs","ca","ce","ch","co","cr","cs","cv","cy",
        "da","de","dv","dz","ee","el","en","es","et","eu","fa","ff","fi","fj","fo","fr","fy","ga","gd","gl","gn","gu","gv","ha","he","hi","ho","hr","ht",
        "hu","hy","hz","id","ig","ii","ik","io","is","it","iu","ja","jv","ka","kg","ki","kj","kk","kl","km","kn","ko","kr","ks","ku","kv","kw","ky","lb",
        "lg","li","ln","lo","lt","lu","lv","mg","mh","mi","mk","ml","mn","mr","ms","mt","my","na","nb","nd","ne","ng","nl","nn","no","nr","nv","ny","oc",
        "oj","om","or","os","pa","pl","ps","pt","qu","rm","rn","ro","ru","rw","sa","sc","sd","se","sg","si","sk","sl","sm","sn","so","sq","sr","ss","st",
        "su","sv","sw","ta","te","tg","th","ti","tk","tl","tn","to","tr","ts","tt","tw","ty","ug","uk","ur","uz","ve","vi","wa","wo","xh","yi","yo","za",
        "zh","zu",
    };


    [Benchmark]
    [Arguments("aa")]  // first in set
    [Arguments("ki")]  // middle of set
    [Arguments("zu")]  // last in set
    [Arguments("zz")]  // not in set
    public bool ValidateLanguageCode_WithRegex(string code) => _languageCodeRegex.IsMatch(code);

    [Benchmark]
    [Arguments("aa")]  // first in set
    [Arguments("af")]  // middle of set
    [Arguments("en")]  // last in set
    [Arguments("ki")]  // not in set
    [Arguments("zu")]
    [Arguments("zz")] // Not in set
    public bool ValidateLanguageCode_WithHasgSet(string code) => _languageCodes.Contains(code);
}




