using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;
using Should;

namespace MyOOPTests
{
    [TestClass]
    public class DictionaryTests
    {
        public struct NewEntry
        {
            public string Name;
            public string Description;
        }

        public NewEntry newEntry = new NewEntry() { Name = "mar", Description = "Este un fruct" };
        public NewEntry newEntry2 = new NewEntry() { Name = "par", Description = "Este un fruct" };
        public NewEntry newEntry3 = new NewEntry() { Name = "pastarnac", Description = "Este un leguma" };

        [TestMethod]
        public void VerifyEmptyDictionary()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.ShouldBeEmpty();
        }

        [TestMethod]
        public void VerifyAddANewValueInEmptyDictionary()
        {
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry2);
            dictionary.Add(newEntry3.Name, newEntry3);
            dictionary.Count.ShouldEqual(3);
        }

        [TestMethod]
        public void VerifyAddANewValueInDictionary()
        {
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry2);
        }

        [TestMethod]
        public void VerifyAddANewValueWithSameHashCodeDictionary()
        {
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry.Name, newEntry2);
        }

        [TestMethod]
        public void FindAWordInEmptyDictionary()
        {
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Find(newEntry.Name).ShouldBeFalse();
        }
        [TestMethod]
        public void FindAWordInDictionaryWithOneWord()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.Add("mar", "mar");
            dictionary.Find("mar").ShouldBeTrue();
        }

        [TestMethod]
        public void FindAWordInDictionaryWithTwoWordsWithSameHash()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.Add("mar", "mar");
            dictionary.Add("mar", "para");
            dictionary.Find("mar").ShouldBeTrue();
        }

    }
}