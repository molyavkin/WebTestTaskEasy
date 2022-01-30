using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAppCoreSession.Models
{
    public static class ManageUser
    {
        public static string SerializeXml(Actors info)
        {
            string serializedXML = "";

            XmlSerializer serializer = new XmlSerializer(typeof(Actors));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, info);
                serializedXML = writer.ToString();
            }
            return serializedXML;
        }
        public static Actors DeserializeXml(string XMLstring)
        {
            using (StringReader writer = new StringReader(XMLstring))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Actors));
                return (Actors)serializer.Deserialize(writer);

            }

        }

        public static Actors InitializeData()
        {
            Actors actor = new Actors();
            actor.userName = "userName";
            Predictor predictorFirst = new Predictor() { Name = "Вася" };

            Predictor predictorSecond = new Predictor() { Name = "Коля" };

            actor.AddPredictor(predictorFirst);
            actor.AddPredictor(predictorSecond);

            return actor;

        }
        

    }
}
