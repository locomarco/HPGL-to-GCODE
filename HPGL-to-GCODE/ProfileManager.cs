using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HPGL_to_GCODE
{
    public class ProfileManager
    {
        private List<Profile> _profiles = new List<Profile>();
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
}