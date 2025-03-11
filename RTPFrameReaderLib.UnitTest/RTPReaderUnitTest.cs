using BigEndianReaderLib;
using RTPFrameReaderLib;

namespace RTPFrameReaderLib.UnitTest
{
    [TestClass]
    public class RTPReaderUnitTest
    {
        [TestMethod]
        public void ShouldNotReadRTPTooShort()
        {
            RTPReader reader;

            reader = new RTPReader();

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> reader.Read(Consts.InvalidValidRTPToShort));

        }
        [TestMethod]
        public void SShouldThrowExceptionWhenDataIsNull()
        {
            RTPReader reader;

            reader = new RTPReader();

#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
            Assert.ThrowsException<ArgumentNullException>(() => reader.Read((byte[])null));
#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.

        }
        [TestMethod]
        public void ShouldThrowExceptionWhenReaderIsNull()
        {
            RTPReader reader;

            reader = new RTPReader();

#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
            Assert.ThrowsException<ArgumentNullException>(() => reader.Read((IBigEndianReader)null));
#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.

        }

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

            Assert.AreEqual(160, RTP.Payload.Length);
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

            Assert.AreEqual(160, RTP.Payload.Length);
        }


    }
}