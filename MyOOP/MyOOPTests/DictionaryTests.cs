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
    }
}
