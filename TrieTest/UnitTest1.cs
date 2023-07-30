namespace TrieTest;

using TrieExample;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestAddIdempotent()
    {
        var trie = new Trie();

        for (int i = 0; i < 10; i++)
        {
            trie.Add("and");
        }

        Assert.AreEqual(1, trie.Count);
    }

    [TestMethod]
    public void TestContainsFalse()
    {
        var trie = new Trie();

        Assert.IsFalse(trie.Contains("and"));
        Assert.IsFalse(trie.Contains("but"));
        Assert.IsFalse(trie.Contains("or"));

        trie.Add("and");
        trie.Add("but");
        trie.Add("or");

        Assert.IsFalse(trie.Contains("nor"));
    }

    [TestMethod]
    public void TestContainsTrue()
    {
        var trie = new Trie();

        trie.Add("and");
        trie.Add("but");
        trie.Add("or");

        Assert.IsTrue(trie.Contains("and"));
        Assert.IsTrue(trie.Contains("but"));
        Assert.IsTrue(trie.Contains("or"));
    }

    [TestMethod]
    public void TestCount()
    {
        var trie = new Trie();

        Assert.AreEqual((int)0, trie.Count);

        trie.Add("and");

        Assert.AreEqual((int)1, trie.Count);
    }
}