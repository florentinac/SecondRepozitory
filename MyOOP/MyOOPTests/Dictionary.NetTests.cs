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
    }
}
