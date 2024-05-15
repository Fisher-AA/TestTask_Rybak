using TestProject.DataForTest;
using TestTask_Rybak;
using TestTask_Rybak.Interfases;

namespace TestProject
{
    [TestClass]
    public class FileReaderTest
    {
        [TestMethod]
        public void TestReader()
        {
            ICondition condition = new ConditionData();
            var fr = new FileReader("TestFiles/Normal.txt", condition);
            fr.Read();
            Assert.IsNotNull(fr,"Ожидается не Null");
            Dictionary<string, int> res = condition.GetResult();
            Assert.IsTrue(res.Count() == 5, "Количество элементов не соответствует ожиданию");
            Assert.IsTrue(res.ContainsKey("192.168.1.1\t01.04.2024 6:33:36"), "Строка не найдена");
        }
    }
}