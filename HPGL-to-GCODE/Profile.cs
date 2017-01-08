using System;
using System.Xml;
using System.Xml.Serialization;

namespace HPGL_to_GCODE
{
    [Serializable]
    public class Profile : ICloneable
    {
        [XmlAttribute]
        public string Profilename { get; set; }

        public float EndstopOffset { get; set; }
        public float PaperThickness { get; set; }
        public float VinylThickness { get; set; }
        public int PaperPenetraion { get; set; }
        public float RetractHeight { get; set; }
        public float CutFeedrate { get; set; }
        public float MoveFeedrate { get; set; }
        public string StartCode { get; set; }
        public string EndCode { get; set; }

        public Profile()
        {
            //default settings
            Profilename = "New Profile";
            EndstopOffset = 0;
            CutFeedrate = 50;
            MoveFeedrate = 200;
            PaperThickness = 0.10f;
            VinylThickness = 0.0f;
            RetractHeight = 1.0f;
            PaperPenetraion = 50;
            StartCode = "G92 X0\r\nG92 Y0\r\nG1 Z{height} F{feed}";
            EndCode = "G1 Z5\r\nM84";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}