using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HelperLibrary;

namespace ExtractSqlRequest.Tests
{
  [TestClass]
  public class UnitTestMethods
  {
    [TestMethod]
    public void TestMethod_Plural_singular()
    {
      var source = 1;
      var expected = "";
      var result = Tools.Plural(source);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod_Plural_Plural()
    {
      var source = 2;
      var expected = "s";
      var result = Tools.Plural(source);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod_ListOfLinesHasMatch_no_match()
    {
      var source = new List<string>();
      source.Add("a");
      source.Add("b");
      var source2 = "select,update,delete";
      var expected = false;
      var result = Tools.ListOfLinesHasMatch(source, source2);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod_ListOfLinesHasMatch_match()
    {
      var source = new List<string>();
      source.Add("a");
      source.Add("delete");
      var source2 = "select,update,delete";
      var expected = true;
      var result = Tools.ListOfLinesHasMatch(source, source2);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod_GetMatchedItems_liste_vide()
    {
      var source = new List<string>();
      source.Add("a");
      source.Add("b");
      var source2 = "select,update,delete";
      var expected = new List<string>();
      var result = Tools.GetMatchedItems(source, source2);
      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMethod_GetMatchedItems_liste_non_vide_minuscule()
    {
      var source = new List<string>();
      source.Add("var source = new List<string>();");
      source.Add("delete from table where condition = 1;");
      var source2 = "select,update,delete";
      var expected = new List<string>();
      expected.Add("delete from table where condition = 1;");
      var result = Tools.GetMatchedItems(source, source2);
      CollectionAssert.AreEqual(expected, result);
    }


    [TestMethod]
    public void TestMethod_GetMatchedItems_liste_non_vide_majuscule()
    {
      var source = new List<string>();
      source.Add("var source = new List<string>();");
      source.Add("DELETE FROM table where condition = 1;");
      var source2 = "select,update,delete";
      var expected = new List<string>();
      expected.Add("DELETE FROM table where condition = 1;");
      var result = Tools.GetMatchedItems(source, source2);
      CollectionAssert.AreEqual(expected, result);
    }
  }
}
