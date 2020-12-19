using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace CW19._12._2020
{
    class Program
    {
        static void OutputNode(XmlNode node)
        {
            Console.WriteLine($"Type: {node.NodeType}\tName: {node.Name}\tValue:" +
                $"{node.Value}");
            if (node.HasChildNodes)
                foreach (XmlNode child in node.ChildNodes)
                    OutputNode(child);
        }

        static string getHtml(string html_adress)
        {
            string HTML;
            var webClient = new System.Net.WebClient();
            webClient.Credentials = new System.Net.NetworkCredential("login", "password");
            return HTML = webClient.DownloadString(html_adress);
        }

        Dictionary<int, string> cities = new Dictionary<int, string>()
        {
            {36870, "Москва"},
            {35188, "Минск"},
            {38880, "Тбилиси"}
        };

        readonly void PrintWeatherData(int input)
        {
            XmlDocument doc = new XmlDocument();
            var filename = input + "xml";
            doc.Load(filename);
            XmlNode root = doc.DocumentElement;
            XmlNode channel = root.FirstChild;
            foreach (XmlNode child in channel)
            {
                if (child.Name != "item" && child.Name != "title")
                    continue;
                var title = child.SelectSingleNode("title")?.FirstChild.Value ?? "";
                var data = child.SelectSingleNode("description")?.FirstChild.Value ?? "";

                var dataComponents = data.Split(', ');
                
                Console.WriteLine($"{title}:");
                foreach (var comp in dataComponents)
                {
                    Console.WriteLine(comp.Trim());
                }
            }

        }

    static void Main(string[] args)
    {

        string HTML = getHtml("https://www.gismeteo.ru/"); ;
        //Console.WriteLine($"{ HTML }");

        while (true)
        {
            Console.WriteLine("Выберите город и введите его код");
            foreach(var item in cities)
            {
                Console.WriteLine($"{item.key}{item.value}");
            }
            var input = Convert.ToInt32(Console.ReadLine());
            if(!cities.ContainsKey(input))
            {
                Console.WriteLine("ошибка");
                continue;
            }
            PrintWeatherData(input);
        }

            /*

            var d = new Distance();
            var kmtom = Distance.KilometersToMiles(1);
            var mtokm = Distance.MilesToKilometers(1);
            */

            /*
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Cars.xml");

                XmlNode root = doc.DocumentElement;
                root.RemoveChild(root.FirstChild);

                XmlNode bike = doc.CreateElement("Bike");
                XmlNode model = doc.CreateElement("Model");
                XmlNode modelValue = doc.CreateTextNode("Yamaha");
                XmlNode year = doc.CreateElement("Year");
                XmlNode yearValue = doc.CreateTextNode("2020");
                XmlNode color = doc.CreateElement("Color");
                XmlNode colorValue = doc.CreateTextNode("Red");

                color.AppendChild(colorValue);
                year.AppendChild(yearValue);
                model.AppendChild(modelValue);

                bike.AppendChild(model);
                bike.AppendChild(year);
                bike.AppendChild(color);

                root.AppendChild(bike);

                doc.Save("Bikes.xml");

                //OutputNode(doc.DocumentElement);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */

            /*
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter("Cars.xml", Encoding.Unicode);
                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");
                writer.WriteStartElement("Car");
                writer.WriteAttributeString("Image", "Car.jpg");
                writer.WriteElementString("Model", "EIA Rio");
                writer.WriteElementString("Year", 2019.ToString());
                writer.WriteElementString("Color", "White");
                writer.WriteEndElement();

                writer.WriteStartElement("Car");
                writer.WriteAttributeString("Image", "Car.jpg");
                writer.WriteElementString("Model", "EIA Rio");
                writer.WriteElementString("Year", 2019.ToString());
                writer.WriteElementString("Color", "Black");
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            */
        }
    }
}
