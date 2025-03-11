using RTPFrameReaderLib;

namespace RTPFrameReaderLib.UnitTest
{
    [TestClass]
    public class RTPReaderUnitTest
    {
        [TestMethod]
        public void ShouldReadValidRTP1()
        {
            RTPReader reader;
            RTP RTP;

            reader = new RTPReader();

            RTP = reader.Read(Consts.ValidRTP1) ;

            Assert.IsNotNull(RTP);

            // header
            Assert.AreEqual((byte)2, RTP.Version);
            Assert.IsFalse(RTP.Padding);
            Assert.IsFalse(RTP.Extension);
            Assert.AreEqual((ushort)0, RTP.CSRCCount);
            Assert.IsTrue(RTP.Marker);
            Assert.AreEqual((byte)0, RTP.PayloadType);

            Assert.AreEqual((ushort)54895, RTP.SequenceNumber);
            Assert.AreEqual((uint)1794114849, RTP.Timestamp);
            Assert.AreEqual((uint)0x94bced81, RTP.SSRC);

            Assert.AreEqual(0, RTP.CSRC.Length);
            Assert.AreEqual((uint)0, RTP.ExtensionHeaderID);
            Assert.AreEqual((uint)0, RTP.ExtensionHeaderLength);
            Assert.AreEqual(0, RTP.ExtensionHeaderPayload.Length);

        }

        [TestMethod]
        public void ShouldReadValidRTP2()
        {
            RTPReader reader;
            RTP RTP;

            reader = new RTPReader();

            RTP = reader.Read(Consts.ValidRTP2);

            Assert.IsNotNull(RTP);

            // header
            Assert.AreEqual((byte)2, RTP.Version);
            Assert.IsFalse(RTP.Padding);
            Assert.IsFalse(RTP.Extension);
            Assert.AreEqual((ushort)0, RTP.CSRCCount);
            Assert.IsFalse(RTP.Marker);
            Assert.AreEqual((byte)8, RTP.PayloadType);

            Assert.AreEqual((ushort)58948, RTP.SequenceNumber);
            Assert.AreEqual((uint)2189852433, RTP.Timestamp);
            Assert.AreEqual((uint)813382377, RTP.SSRC);

            Assert.AreEqual(0, RTP.CSRC.Length);
            Assert.AreEqual((uint)0, RTP.ExtensionHeaderID);
            Assert.AreEqual((uint)0, RTP.ExtensionHeaderLength);
            Assert.AreEqual(0, RTP.ExtensionHeaderPayload.Length);

        }


    }
}