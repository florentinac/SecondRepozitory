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
            var newEntry = new NewEntry("apple", "It is a fruit");
            var newEntry2 = new NewEntry("pear", "It is a fruit");
            var newEntry3 = new NewEntry("tomato", "It is a vegetable");
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry2);
            dictionary.Add(newEntry3.Name, newEntry3);
            dictionary.Count.ShouldEqual(3);
        }

        [TestMethod]
        public void VerifyAddANewValueInDictionary()
        {
            var newEntry = new NewEntry("apple", "It is a fruit");
            var newEntry2 = new NewEntry("pear", "It is a fruit");
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry2);
        }

        [TestMethod]
        public void FindAWordInEmptyDictionary()
        {
            var newEntry = new NewEntry("apple", "It is a fruit");           
            var dictionary = new DictionaryClass<string, NewEntry>();
            dictionary.Find(newEntry.Name).ShouldBeFalse();
        }
        [TestMethod]
        public void FindAWordInDictionaryWithOneWord()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.Add("apple", "apple");
            dictionary.Find("apple").ShouldBeTrue();
        }

        [TestMethod]
        public void FindAWordInDictionaryWithTwoWordsWithSameHash()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.Add("apple", "apple");
            dictionary.Add("apple", "pear");
            dictionary.Find("apple").ShouldBeTrue();
        }

        [TestMethod]
        public void FindASpecificWordInDictionaryWithTwoWordsWithSameHash()
        {
            var dictionary = new DictionaryClass<string, string>();
            dictionary.Add("apple", "apple");
            dictionary.Add("apple", "pear");
            var word = dictionary.FindWord("apple");
            word.ShouldEqual("apple");
        }

        [TestMethod]
        public void VerifyFindAStructureWithSameHashCodeDictionary()
        {
            var dictionary = new DictionaryClass<string, NewEntry>();
            var newEntry = new NewEntry("apple", "It is a fruit");
            var newEntry2 = new NewEntry("tomato", "It is a vegetable");
            dictionary.Add(newEntry.Name, newEntry);
            dictionary.Add(newEntry2.Name, newEntry);
            var word = dictionary.FindWord(newEntry.Name);
            word.ShouldEqual(newEntry);
        }
    }
}