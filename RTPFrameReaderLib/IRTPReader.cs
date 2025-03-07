using BigEndianReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPFrameReaderLib
{
    public interface IRTPReader
    {
        RTP Read(byte[] Data);
        RTP Read(IBigEndianReader Reader);
    }
}
