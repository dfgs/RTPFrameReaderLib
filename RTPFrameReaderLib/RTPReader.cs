using BigEndianReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPFrameReaderLib
{
    public class RTPReader:IRTPReader
    {
        public RTP Read(byte[] Data)
        {
            if (Data == null) throw new ArgumentNullException(nameof(Data));
            if (Data.Length < 4) throw new ArgumentOutOfRangeException(nameof(Data));
            return Read(new BigEndianReader(Data));
        }

        public RTP Read(IBigEndianReader Reader)
        {
            RTP rtp;
            byte val;

            rtp=new RTP();

            val=Reader.ReadByte();
            rtp.Version =(byte)( (val & 192) >> 6);
            rtp.Padding = (val & 32) != 0;
            rtp.Extension = (val & 16) != 0;
            rtp.CSRCCount = (ushort)((val & 15));

            val = Reader.ReadByte();
            rtp.Marker = (val & 128) != 0;
            rtp.PayloadType = (ushort)((val & 127));

            return rtp;
           
        }


    }
}
