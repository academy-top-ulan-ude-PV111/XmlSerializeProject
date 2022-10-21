using System.Net.Sockets;
using System.Xml.Serialization;

namespace XmlSerializeProject
{
    [Serializable]
    public class Employe
    {
        public string? Name { set; get; }
        public int Age { set; get; }
        public Company? Company { set; get; }
        
    }

    public class Company
    {
        public string? Title { set; get; }
        public Address? Address { set; get; }
    }

    public class Address
    {
        public string? City { set; get; }
        public string? Street { set; get; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ////Serialize

            //Employe employe = new Employe() { Name = "Bob", Age = 34 };
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employe));
            //using(FileStream file = new FileStream("employes.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(file, employe);
            //}


            // Desrialize
            //Employe? employe;
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employe));
            //using (FileStream file = new FileStream("employes.xml", FileMode.Open))
            //{
            //    employe = xmlSerializer.Deserialize(file) as Employe;
            //}

            //Console.WriteLine($"Employe: name -> {employe?.Name}, age -> {employe?.Age}");

            // Collection Serialize
            //List<Employe> employes = new()
            //{
            //    new(){ Name = "Joe", Age = 43 },
            //    new(){ Name = "Mike", Age = 22 },
            //    new(){ Name = "Whiliam", Age = 37 }
            //};

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employe>));
            //using (FileStream file = new FileStream("employes.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(file, employes);
            //}

            // Collection Desrialize
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employe>));
            //using (FileStream file = new FileStream("employes.xml", FileMode.Open))
            //{
            //    var employes = xmlSerializer.Deserialize(file) as List<Employe>;
            //    foreach (var item in employes!)
            //        Console.WriteLine($"Employe: name -> {item?.Name}, age -> {item?.Age}");
            //}


            // Multi Collection  Serialize
            //List<Company> companies = new()
            //{
            //    new(){ Title = "Yandex", Address = new(){ City = "Moscow", Street = "Tverskaya st." } },
            //    new(){ Title = "BaltFlot", Address = new(){ City = "St-Peterbug", Street = "Dostoevsky st." } },

            //    //new(){ Title = "Yandex" },
            //    //new(){ Title = "BaltFlot" }
            //};

            //List<Employe> employes = new()
            //{
            //    new(){ Name = "Joe", Age = 43, Company = companies[0] },
            //    new(){ Name = "Mike", Age = 22, Company = companies[1] },
            //    new(){ Name = "Whiliam", Age = 37, Company = companies[0] }
            //};

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employe>));
            //using (FileStream file = new FileStream("employes.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(file, employes);
            //}

            // Multi Collection Desrialize
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employe>));
            using (FileStream file = new FileStream("employes.xml", FileMode.Open))
            {
                var employes = xmlSerializer.Deserialize(file) as List<Employe>;
                foreach (var item in employes!)
                {
                    Console.WriteLine($"Employe: name -> {item?.Name}, " +
                                      $" age -> {item?.Age} company -> {item?.Company?.Title}");
                    Console.WriteLine($"\tcompany city -> {item.Company.Address.City}" +
                                      $" street -> {item.Company.Address.Street}");
                }
                    
            }

        }
    }
}