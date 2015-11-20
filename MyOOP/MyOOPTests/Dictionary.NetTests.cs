using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;
using Should;

namespace MyOOPTests
{
    [TestClass]
    public class Dictionary
    {
        [TestMethod]
        public void VerfiyAnEmptyDictionary()
        {
            var dictionary = new DictionaryNet<string,string>();
            dictionary.ShouldBeEmpty();
        }

        [TestMethod]
        public void AddNewEnrtyInDictionary()
        {
            var dictionary = new DictionaryNet<string, string>();
            dictionary.Add("appel", "appel");
            //dictionary.ShouldContain("appel");
        }

        [TestMethod]
        public void AddNewEnrtyWithNextInDictionary()
        {
            var dictionary = new DictionaryNet<string, string>();
            dictionary.Add("appel", "appel");
            dictionary.Add("appel", "appel2");
            //dictionary.ShouldContain("appel");
        }
    }
}
