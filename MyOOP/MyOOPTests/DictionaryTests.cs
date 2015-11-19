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

        [TestMethod]
        public void VerifyEmptyDictionary()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.ShouldBeEmpty();
        }

        [TestMethod]
        public void VerifyAddANewValueInEmptyDictionary()
        {
            var newEntry = new NewEntry("mar","este un fruct");
            var newEntry2 = new NewEntry("par", "este un fruct");
            var newEntry3 = new NewEntry("rosie", "este o leguma");
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry2);
            dictionary.Add(newEntry3.Name, newEntry3);
            dictionary.Count.ShouldEqual(3);
        }

        [TestMethod]
        public void VerifyAddANewValueInDictionary()
        {
            var newEntry = new NewEntry("mar", "este un fruct");
            var newEntry2 = new NewEntry("par", "este un fruct");
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry2);
        }

        [TestMethod]
        public void FindAWordInEmptyDictionary()
        {
            var newEntry = new NewEntry("mar", "este un fruct");           
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

        [TestMethod]
        public void FindASpecificWordInDictionaryWithTwoWordsWithSameHash()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.Add("mar", "mar");
            dictionary.Add("mar", "para");
            var word = dictionary.FindWord("mar");
            word.ShouldEqual("mar");
        }

        [TestMethod]
        public void VerifyFindAStructureWithSameHashCodeDictionary()
        {
            var dictionary = new DictionaryClass<string, NewEntry>();
            var newEntry = new NewEntry("mar", "este un fruct");
            var newEntry2 = new NewEntry("rosie", "este o leguma");
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry);
            var word = dictionary.FindWord(newEntry.Name);
            word.ShouldEqual(newEntry);
        }
    }
}