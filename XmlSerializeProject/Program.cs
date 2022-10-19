using System.Xml.Serialization;

namespace XmlSerializeProject
{
    [Serializable]
    public class Employe
    {
        public string? Name { set; get; }
        public int Age { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employe employe = new Employe() { Name = "Bob", Age = 34 };
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employe));
            
            using(FileStream file = new FileStream("employes.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, employe);
            }

        }
    }
}