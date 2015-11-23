using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;
using Should;

namespace MyOOPTests
{
    public class FixHasher<T> : IHash<T>
    {
        public int GetHashCode(T obj)
        {
            return 20;
        }
    }

    [TestClass]
    public class Dictionary
    {
        public struct NewEntry
        {
            private string Word;
            private string Description;

            public NewEntry(string word, string description)
            {
                this.Word = word;
                this.Description = description;
            }
        };

        [TestMethod]
        public void AddNewEnrtyInDictionary()
        {
            var dictionary = new DictionaryNet<string, string>();
            dictionary.Add("appel", "appel");

            Assert.AreEqual(1, dictionary.GetCount);
        }

        [TestMethod]
        public void AddNewEnrtyWithNextInDictionary()
        {
            var dictionary = new DictionaryNet<string, string>();
            dictionary.Add("appel", "appel");
            dictionary.Add("appel2", "appel2");

            Assert.AreEqual(2, dictionary.GetCount);
        }

        [TestMethod]
        public void VerifyIfDictionaryDoesentContainsKey()
        {
            var dictionary = new DictionaryNet<string, NewEntry>();
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");
            var expectedResult = new NewEntry();
            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);

            Assert.AreEqual(expectedResult, dictionary.ContainsKey("tomatos"));
        }
        [TestMethod]
        public void VerifyIfDictionaryContainsKey()
        {
            var dictionary = new DictionaryNet<string, NewEntry>();
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");
            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);

            Assert.AreEqual(secondEntry, dictionary.ContainsKey("pear"));
        }

        [TestMethod]
        public void AddInDictionaryTwoEntryWithSameHashCode()
        {
            var hasher = new FixHasher<string>();
            var dictionary = new DictionaryNet<string, NewEntry>(hasher);
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");
            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);

            Assert.AreEqual(2, dictionary.GetCount);
            Assert.AreEqual(secondEntry, dictionary.ContainsKey("pear"));
        }

        [TestMethod]
        public void AddInDictionaryThreeEntryWithSameHashCode()
        {
            var hasher = new FixHasher<string>();
            var dictionary = new DictionaryNet<string, NewEntry>(hasher);
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");
            var thirdEntry = new NewEntry("tomato", "It is a vegetable");
            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);
            dictionary.Add("tomato", thirdEntry);

            Assert.AreEqual(3, dictionary.GetCount);
            Assert.AreEqual(firstEntry, dictionary.ContainsKey("appel"));
        }

        [TestMethod]
        public void VerifyIfDictionaryDoesntContaindValueWithSameHashCode()
        {
            var hasher = new FixHasher<string>();
            var dictionary = new DictionaryNet<string, NewEntry>(hasher);
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");           
            var expectedResult = new NewEntry();
            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);        
        
            Assert.AreEqual(expectedResult, dictionary.ContainsKey("kiwi"));
        }
               
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifyDeleteANonExistentKey()
        {
            var dictionary = new DictionaryNet<string, NewEntry>();
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");
            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);
            dictionary.Remove("kiwi");     
        }

        [TestMethod]       
        public void VerifyDeleteAnEntry()
        {
            var dictionary = new DictionaryNet<string, NewEntry>();
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");
            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);
            Assert.AreEqual(2, dictionary.GetCount);
            dictionary.Remove("appel");

            Assert.AreEqual(1, dictionary.GetCount);
        }

        [TestMethod]
        public void VerifyDeleteEntryWithSameHashCode()
        {
            var hasher = new FixHasher<string>();
            var dictionary = new DictionaryNet<string, NewEntry>(hasher);
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");

            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);
            dictionary.Remove("appel");

            Assert.AreEqual(1, dictionary.GetCount);   
        }

        [TestMethod]
        public void VerifyDeleteEntryWithSameHashCodeForThreeEntry()
        {
            var hasher = new FixHasher<string>();
            var dictionary = new DictionaryNet<string, NewEntry>(hasher);
            var firstEntry = new NewEntry("appel", "It is a fruit");
            var secondEntry = new NewEntry("pear", "It is a pear");
            var thirdEntry = new NewEntry("tomato", "It is a vegetable");

            dictionary.Add("appel", firstEntry);
            dictionary.Add("pear", secondEntry);
            dictionary.Add("tomato", thirdEntry);
            dictionary.Remove("appel");

            Assert.AreEqual(2, dictionary.GetCount);
        }


    }
}