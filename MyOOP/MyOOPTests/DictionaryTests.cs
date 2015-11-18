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

        public NewEntry newEntry = new NewEntry() {Name = "mar", Description = "Este un fruct"};

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
            dictionary.Count.ShouldEqual(1);
        }
    }
}
