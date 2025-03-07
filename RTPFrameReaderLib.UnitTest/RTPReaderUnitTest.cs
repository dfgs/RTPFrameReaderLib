using RTPFrameReaderLib;

namespace RTPFrameReaderLib.UnitTest
{
    [TestClass]
    public class RTPReaderUnitTest
    {
        [TestMethod]
        public void ShouldReadValidRTP()
        {
            RTPReader reader;
            RTP RTP;

            reader = new RTPReader();

            RTP = reader.Read(Consts.ValidRTP) ;

            Assert.IsNotNull(RTP);

            // header
            Assert.AreEqual((byte)2, RTP.Version);
            Assert.IsFalse(RTP.Padding);
            Assert.IsFalse(RTP.Extension);
            Assert.AreEqual((ushort)0, RTP.CSRCCount);
            Assert.IsTrue(RTP.Marker);
            Assert.AreEqual((ushort)0,RTP.PayloadType);


        }
    }
}