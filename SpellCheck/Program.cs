using TrieExample;

string words = await new HttpClient().GetStringAsync("https://www.mit.edu/~ecprice/wordlist.10000");
char[] punctuation = "\n !\"#%&'()*,-./:;?@[\\]_{}".ToCharArray();

var trie = new Trie();

words.Split(punctuation)
    .Where(x => !string.IsNullOrEmpty(x))
    .ToList()
    .ForEach(trie.Add);

Console.WriteLine(trie);

string text = "Despite the constant negative press covfefe";

List<string> unknown = text.Split(punctuation)
    .Where(x => !trie.Contains(x))
    .Distinct()
    .ToList();

Console.WriteLine($"Unknown words:\n{string.Join('\n', unknown)}");
