namespace RTPFrameReaderLib
{
    public record RTP
    {
        public byte Version
        {
            get;
            set;
        }

        public bool Padding
        {
            get;
            set;
        }
        public bool Extension
        {
            get;
            set;
        }
        public ushort CSRCCount
        {
            get;
            set;
        }

        public bool Marker
        {
            get;
            set;
        }

        public byte PayloadType
        {
            get;
            set;
        }

        public ushort SequenceNumber
        {
            get;
            set;
        }

        public uint Timestamp
        {
            get;
            set;
        }
        public uint SSRC
        {
            get;
            set;
        }

        public uint[] CSRC
        {
            get;
            set;
        }
        public uint ExtensionHeaderID
        {
            get;
            set;
        }

        public uint ExtensionHeaderLength
        {
            get;
            set;
        }

        public byte[] ExtensionHeaderPayload
        {
            get;
            set;
        }

        public byte[] Payload
        {
            get;
            set;
        }

        public RTP()
        {
            CSRC= Array.Empty<uint>();
            ExtensionHeaderPayload = Array.Empty<byte>();
            Payload = Array.Empty<byte>();
        }
    }

}
