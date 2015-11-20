using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;
using Should;

namespace MyOOPTests
{
    [TestClass]
    public class Dictionary
    {
        //[TestMethod]
        //public void VerfiyAnEmptyDictionary()
        //{
        //    var dictionary = new DictionaryNet<string,string>();
        //    dictionary.ShouldBeEmpty();
        //}

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
        public void VerifyIfDictionaryContainsKey()
        {
            var dictionary = new DictionaryNet<string, string>();
            dictionary.Add("appel", "appel");
            dictionary.Add("appel2", "appel2");

            Assert.AreEqual("appel2", dictionary.ContainsKey("appel2"));
        }
    }
}
