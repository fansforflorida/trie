// This is an example of a trie data structure.
// Copyright (C) 2023  John Hall
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; If not, see <http://www.gnu.org/licenses/>.

namespace TrieExample;

/// <summary>
/// Represents a collection of case-insensitive words stored in a trie data structure. Provides
/// methods to add and search words.
/// </summary>
public sealed class Trie
{
    private readonly Node root = new ();

    /// <summary>
    /// Gets the number of words contained in the trie.
    /// </summary>
    public int Count { get; internal set; }

    /// <summary>
    /// Adds a word to the trie.
    /// </summary>
    /// <param name="word">The word to be added to the trie.</param>
    /// <exception cref="ArgumentNullException">Argument is null.</exception>
    /// <exception cref="ArgumentException">Argument is empty or contains a non letter character.</exception>
    public void Add(string word)
    {
        char[] chars = ToUpperCharArray(word);
        Node node = this.root;

        foreach (char c in chars)
        {
            if (node[c] == null)
            {
                node[c] = new Node();
            }

            node = node[c] !;
        }

        if (!node.IsWord)
        {
            node.IsWord = true;
            this.Count++;
        }
    }

    /// <summary>
    /// Determines whether a word is in the trie.
    /// </summary>
    /// <param name="word">The word to locate in the trie.</param>
    /// <returns>true if item is found in the trie; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Argument is null.</exception>
    /// <exception cref="ArgumentException">Argument is empty or contains a non letter character.</exception>
    public bool Contains(string word)
    {
        char[] chars = ToUpperCharArray(word);
        Node node = this.root;

        foreach (char c in chars)
        {
            if (node[c] == null)
            {
                return false;
            }

            node = node[c] !;
        }

        return node.IsWord;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{this.Count} words in {Node.Count} nodes";
    }

    private static char[] ToUpperCharArray(string word)
    {
        ArgumentException.ThrowIfNullOrEmpty(word);

        char[] chars = word.ToUpper().ToCharArray();

        foreach (char c in chars)
        {
            if (c < 'A' || c > 'Z')
            {
                throw new ArgumentException("contains non-letter characters", nameof(word));
            }
        }

        return chars;
    }

    private sealed class Node
    {
        private readonly Node?[] children = new Node?[26];

        public Node()
        {
            Count++;
        }

        public static int Count { get; private set; }

        public bool IsWord { get; set; }

        public Node? this[char c]
        {
            get { return this.children[c - 'A']; }
            set { this.children[c - 'A'] = value; }
        }
    }
}