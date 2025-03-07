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

        public ushort PayloadType
        {
            get;
            set;
        }

        public RTP()
        {

        }
    }

}
