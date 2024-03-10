using System.Xml.Serialization;

namespace Data.DataReaderStrategy {
    public class XMLReader : IDataReader {
        public RootDTO ReadData(string filePath) {
            XmlSerializer serializer = new XmlSerializer(typeof(RootDTO));
            using (StreamReader reader = new StreamReader(filePath)) {
                return (RootDTO)serializer.Deserialize(reader);
            }
        }
    }
}
