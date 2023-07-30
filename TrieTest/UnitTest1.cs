namespace TrieTest;

using TrieExample;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Add_EmptyString_ThrowsArgumentException()
    {
        var trie = new Trie();

        void addEmptyString() => trie.Add(string.Empty);

        Assert.ThrowsException<ArgumentException>(addEmptyString);
    }

    [TestMethod]
    public void Add_Null_ThrowsArgumentNullException()
    {
        var trie = new Trie();

        void addNull() => trie.Add(null);

        Assert.ThrowsException<ArgumentNullException>(addNull);
    }

    [TestMethod]
    public void Add_Number_ThrowsArgumentException()
    {
        var trie = new Trie();
        string number = "0";

        void addNumber() => trie.Add(number);

        Assert.ThrowsException<ArgumentException>(addNumber);
    }

    [TestMethod]
    public void Add_Space_ThrowsArgumentException()
    {
        var trie = new Trie();

        void addSpace() => trie.Add(" ");

        Assert.ThrowsException<ArgumentException>(addSpace);
    }

    [TestMethod]
    public void Contains_KnownWord_ReturnsTrue()
    {
        var trie = new Trie();
        trie.Add("and");
        trie.Add("but");
        trie.Add("or");

        bool actual = trie.Contains("and");

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void Contains_NewTrie_ReturnsFalse()
    {
        var trie = new Trie();

        bool actual = trie.Contains("and");

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Contains_UnknownWord_ReturnsFalse()
    {
        var trie = new Trie();
        trie.Add("and");
        trie.Add("but");
        trie.Add("or");

        bool actual = trie.Contains("nor");

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void Count_AddSameWord_ReturnsOne()
    {
        var trie = new Trie();
        for (int i = 0; i < 10; i++)
        {
            trie.Add("and");
        }

        int actual = trie.Count;

        Assert.AreEqual((int)1, actual);
    }

    [TestMethod]
    public void Count_AfterAdd_ReturnsOne()
    {
        var trie = new Trie();
        trie.Add("and");

        int actual = trie.Count;

        Assert.AreEqual((int)1, actual);
    }

    [TestMethod]
    public void Count_NewTrie_ReturnsZero()
    {
        var trie = new Trie();

        int actual = trie.Count;

        Assert.AreEqual((int)0, actual);
    }

    [TestMethod]
    public void ToString_ThreeWords_FourNodes()
    {
        var trie = new Trie();
        trie.Add("a");
        trie.Add("an");
        trie.Add("and");

        string actual = trie.ToString();

        Assert.AreEqual("3 words in 4 nodes", actual);
    }
}