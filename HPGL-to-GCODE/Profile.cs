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
        public int PaperPenetraion { get; set; }
        public float SafeDistance { get; set; }
        public float Feedrate { get; set; }
        public string StartCode { get; set; }
        public string EndCode { get; set; }

        public Profile()
        {
            //default settings
            Profilename = "New Profile";
            EndstopOffset = 0;
            Feedrate = 50;
            PaperThickness = 0.1f;
            SafeDistance = 1;
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
