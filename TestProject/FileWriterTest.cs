using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
using TestTask_Rybak;

namespace TestProject
{
    [TestClass]
    public class FileWriterTest
    {
        [TestMethod]
        public void TestFileWrite()
        {
               var fInfo = new FileInfo(DataForTest.TestData.FileResultPath); 
                if(fInfo.Exists)
                    fInfo.Delete();
                string delimetr = ";";
                var fw = new FileWriter(DataForTest.TestData.FileResultPath, DataForTest.TestData.dictInput, delimetr);
                fw.Write();

                Assert.IsFalse(fw.IsError());
                fInfo = new FileInfo(DataForTest.TestData.FileResultPath);
                Assert.IsTrue(fInfo.Exists);
                string content = File.ReadAllText(fInfo.FullName);
                Assert.AreEqual(content, string.Format(DataForTest.TestData.fileResult, delimetr),"Контент файла результата не соответствует ожиданию");
                fInfo.Delete();
        }
    }
}