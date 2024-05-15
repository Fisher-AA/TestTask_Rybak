using TestTask_Rybak;

namespace TestProject
{
    [TestClass]
    public class InputParametresTest
    {
        [TestMethod]
        public void GetDataNormal()
        {
            InputData data = new InputParametres ( DataForTest.TestData.optionsFull);
            Assert.IsNotNull(data, "¬ходные данные Null");
            Assert.IsFalse(data.IsError(), "ќжидалась отсутствие ошибок");
            Assert.AreEqual(data.PathFileOut, "ResultFiles/result.txt", "PathFileOut не совпадает");
            Assert.AreEqual(data.PathFileLog, "TestFiles/Normal.txt", "PathFileLog не совпадает");
            Assert.IsNotNull(data.AddressMask, "AddressMask is Null");
            Assert.IsNotNull(data.StartIPAddress, "StartIPAddress is Null");
            Assert.AreEqual(data.AddressMask.ToString(), "255.255.0.0", "AddressMask не совпадает");
            Assert.AreEqual(data.StartIPAddress.ToString(), "10.1.1.15", "Start IPAddress не совпадает");
        }

        [TestMethod]
        public void GetDataByPathInPathOut()
        {
            InputData data = new InputParametres(DataForTest.TestData.optionsPathInPathOut);
            Assert.IsNotNull(data, "¬ходные данные Null");
            Assert.IsFalse(data.IsError(), "ќжидалась отсутствие ошибок");
            Assert.AreEqual(data.PathFileOut, "ResultFiles/result.txt", "PathFileOut не совпадает");
            Assert.AreEqual(data.PathFileLog, "TestFiles/Normal.txt", "PathFileLog не совпадает");
            Assert.IsNull(data.AddressMask, "AddressMask не Null");
            Assert.IsNull(data.StartIPAddress, "StartIPAddress не Null");
        }

        [TestMethod]
        public void GetDataByPathInOnly()
        {
            InputData data = new InputParametres(DataForTest.TestData.optionsPathIn);
            Assert.IsNotNull(data, "¬ходные данные Null");
            Assert.IsTrue(data.IsError(), "ќжидалась ошибка");
        }

        [TestMethod]
        public void GetDataByEmpty()
        {
            InputData data = new InputParametres(DataForTest.TestData.optionsEmpty);
            Assert.IsNotNull(data, "¬ходные данные Null");
            Assert.IsTrue(data.IsError(), "ќжидалась ошибка");
        }
    }
}