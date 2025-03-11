using BigEndianReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RTPFrameReaderLib
{
    public class RTPReader:IRTPReader
    {
        public RTP Read(byte[] Data)
        {
            if (Data == null) throw new ArgumentNullException(nameof(Data));
            if (Data.Length < 12) throw new ArgumentOutOfRangeException(nameof(Data));
            return Read(new BigEndianReader(Data));
        }

        public RTP Read(IBigEndianReader Reader)
        {
            RTP rtp;
            byte val;

            if (Reader == null) throw new ArgumentNullException(nameof(Reader));

            rtp = new RTP();

            val=Reader.ReadByte();
            rtp.Version =(byte)( (val & 192) >> 6);
            rtp.Padding = (val & 32) != 0;
            rtp.Extension = (val & 16) != 0;
            rtp.CSRCCount = (ushort)((val & 15));

            val = Reader.ReadByte();
            rtp.Marker = (val & 128) != 0;
            rtp.PayloadType = (byte)((val & 127));

            rtp.SequenceNumber = Reader.ReadUInt16();
            rtp.Timestamp = Reader.ReadUInt32();
            rtp.SSRC = Reader.ReadUInt32();

            rtp.CSRC=new uint[rtp.CSRCCount];
            for(int i = 0;i<rtp.CSRCCount;i++) rtp.CSRC[i] = Reader.ReadUInt32();

            if (rtp.Extension)
            {
                rtp.ExtensionHeaderID= Reader.ReadUInt32();
                rtp.ExtensionHeaderLength = Reader.ReadUInt32();
                rtp.ExtensionHeaderPayload= Reader.ReadBytes((int)((rtp.ExtensionHeaderLength-16)/8));
            }

            rtp.Payload= Reader.ReadBytes(Reader.Length-Reader.Position);

            return rtp;
           
        }


    }
}
