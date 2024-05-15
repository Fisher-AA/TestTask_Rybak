using TestTask_Rybak;

namespace TestProject
{
    [TestClass]
    public class ConditionTest
    {
        [TestMethod]
        public void ConditionFull()
        {
            Condition condition = new Condition();
            condition.UseConditon("192.168.1.1\t05.04.2024 6:33:36");
            Assert.IsNotNull(condition, "�� ������ ���� Null");
            Assert.IsFalse(condition.IsError(), "��������� ���������� ������");
            Assert.IsTrue(condition.GetResult().Count == 1, "��������� ���� ������");
            Assert.IsTrue(condition.GetResult().ContainsKey("192.168.1.1"), "Ip �� ������ ����� ������");
            Assert.IsTrue(condition.GetResult().ContainsValue(1), "�������� �� �������");
        }
        [TestMethod]
        public void ConditionNotIpV4()
        {
            Condition condition = new Condition();
            condition.UseConditon("1050:0:0:0:5:600:300c:326b\t05.04.2024 6:33:36");
            Assert.IsNotNull(condition, "�� ������ ���� Null");
            Assert.IsTrue(condition.IsError(), "���������  ������");
        }
    }
}