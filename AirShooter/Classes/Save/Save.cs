using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace AirShooter.Classes.Save
{

    public class Save
    {
        private Container container;    

        public Save(Container container)
        {
            this.container = container;
        }

        public void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Container));
            FileStream stream = new FileStream("save.xml", FileMode.Create);
            serializer.Serialize(stream, container);
            stream.Close();
        }

        public Container Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Container));
            FileStream stream = new FileStream("save.xml", FileMode.Open);

            container = (Container)serializer.Deserialize(stream);

            stream.Close();

            return container;
        }
    }
}
