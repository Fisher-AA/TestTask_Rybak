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
            Assert.IsNotNull(data, "������� ������ Null");
            Assert.IsFalse(data.IsError(), "��������� ���������� ������");
            Assert.AreEqual(data.PathFileOut, "ResultFiles/result.txt", "PathFileOut �� ���������");
            Assert.AreEqual(data.PathFileLog, "TestFiles/Normal.txt", "PathFileLog �� ���������");
            Assert.IsNotNull(data.AddressMask, "AddressMask is Null");
            Assert.IsNotNull(data.StartIPAddress, "StartIPAddress is Null");
            Assert.AreEqual(data.AddressMask.ToString(), "255.255.0.0", "AddressMask �� ���������");
            Assert.AreEqual(data.StartIPAddress.ToString(), "10.1.1.15", "Start IPAddress �� ���������");
        }

        [TestMethod]
        public void GetDataByPathInPathOut()
        {
            InputData data = new InputParametres(DataForTest.TestData.optionsPathInPathOut);
            Assert.IsNotNull(data, "������� ������ Null");
            Assert.IsFalse(data.IsError(), "��������� ���������� ������");
            Assert.AreEqual(data.PathFileOut, "ResultFiles/result.txt", "PathFileOut �� ���������");
            Assert.AreEqual(data.PathFileLog, "TestFiles/Normal.txt", "PathFileLog �� ���������");
            Assert.IsNull(data.AddressMask, "AddressMask �� Null");
            Assert.IsNull(data.StartIPAddress, "StartIPAddress �� Null");
        }

        [TestMethod]
        public void GetDataByPathInOnly()
        {
            InputData data = new InputParametres(DataForTest.TestData.optionsPathIn);
            Assert.IsNotNull(data, "������� ������ Null");
            Assert.IsTrue(data.IsError(), "��������� ������");
        }

        [TestMethod]
        public void GetDataByEmpty()
        {
            InputData data = new InputParametres(DataForTest.TestData.optionsEmpty);
            Assert.IsNotNull(data, "������� ������ Null");
            Assert.IsTrue(data.IsError(), "��������� ������");
        }
    }
}