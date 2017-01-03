using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace HPGL_to_GCODE
{
    public class ProfileManager
    {
        List<Profile> _profiles = new List<Profile>();
        public List<Profile> Profiles { get { return _profiles; } set { _profiles = value; } }
        [XmlIgnore]
        private static string _filename = string.Empty;
        //public string Filename { get; set; }

        public void SaveToFile()
        {
            var serializer = new XmlSerializer(typeof(ProfileManager));
            using (FileStream fs = new FileStream(_filename, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, this);
            }
        }

        public static ProfileManager LoadFromFile(string pathToXML)
        {
            _filename = pathToXML;
            if (File.Exists(pathToXML))
            {
                var serializer = new XmlSerializer(typeof(ProfileManager));
                using (var fs = new FileStream(_filename, FileMode.Open, FileAccess.Read))
                {
                    return (ProfileManager)serializer.Deserialize(fs);
                }
            }
            else
            {
                ProfileManager profiles = new ProfileManager();
                profiles.Profiles.Add(new Profile());

                return profiles;
            }
        }
    }

    [Serializable]
    public class Profile : ICloneable
    {
        [XmlAttribute]
        public string Profilename { get; set; }
        public float XOffset { get; set; }
        public float YOffset { get; set; }
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
            XOffset = YOffset = EndstopOffset = 0;
            MaterialThickness = PaperThickness = SafeDistance = 0;
            PaperPenetraion = 50;
            StartCode = EndCode = string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
