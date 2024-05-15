
using TestTask_Rybak;

namespace TestProject
{
    [TestClass]
    public class InputConfigurationTest
    {

        [TestMethod]
        public void GetDataByConfigurationEmpty()
        {
            InputData data = new InputConfiguration("TestFiles/configempty.json");
            Assert.IsNotNull(data, "Входные данные Null");
            Assert.IsTrue(data.IsError(), "Ожидалась ошибка так как файл пустой");
        }

        [TestMethod]
        public void GetDataByConfigurationEmptySection()
        {
            InputData data = new InputConfiguration("TestFiles/configEmptySection.json");
            Assert.IsNotNull(data, "Входные данные Null");
            Assert.IsTrue(data.IsError(), "Ожидалась ошибка так как Section пустая");
        }

        [TestMethod]
        public void GetDataByConfigurationEmptyPathIn()
        {
            InputData data = new InputConfiguration("TestFiles/configEmptyPathIn.json");
            Assert.IsNotNull(data, "Входные данные Null");
            Assert.IsTrue(data.IsError(), "Ожидалась ошибка так как не задан параметр PathIn");
        }
        [TestMethod]
        public void GetDataByConfigurationEmptyPathOut()
        {
            InputData data = new InputConfiguration("TestFiles/configEmptyPathOut.json");
            Assert.IsNotNull(data, "Входные данные Null");
            Assert.IsTrue(data.IsError(), "Ожидалась ошибка так как не задан параметр PathOut");
        }

        [TestMethod]
        public void GetDataByConfigurationNormal()
        {
            InputData data = new InputConfiguration("TestFiles/configNormal.json");
            Assert.IsNotNull(data, "Входные данные Null");
            Assert.IsFalse(data.IsError(), "Ожидалась отсутствие ошибок");
            Assert.AreEqual(data.PathFileOut, "ResultFiles/result.txt", "PathFileOut не совпадает");
            Assert.AreEqual(data.PathFileLog, "TestFiles/Normal.txt", "PathFileLog не совпадает");
            Assert.IsNotNull(data.AddressMask, "AddressMask is Null");
            Assert.IsNotNull(data.StartIPAddress, "StartIPAddress is Null");
            Assert.AreEqual(data.AddressMask.ToString(), "255.255.0.0", "AddressMask не совпадает");
            Assert.AreEqual(data.StartIPAddress.ToString(), "10.1.1.15", "Start IPAddress не совпадает");
        }
    }
}
