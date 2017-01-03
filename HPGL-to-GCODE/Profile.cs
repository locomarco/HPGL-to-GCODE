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
        public float MaterialThickness { get; set; }
        public float PaperThickness { get; set; }
        public int PaperPenetraion { get; set; }
        public float SafeDistance { get; set; }
        public float Feedrate { get; set; }
        public string StartCode { get; set; }
        public string EndCode { get; set; }

        public Profile()
        {
            Profilename = "New Profile";
            EndstopOffset = MaterialThickness = PaperThickness = SafeDistance = 0;
            PaperPenetraion = 50;
            StartCode = EndCode = string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
