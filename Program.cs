using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input file path:");
            var inputPath = Console.ReadLine();

            Console.WriteLine("Output file path:");
            var outputPath = Console.ReadLine();

            var xmlDoc = Input(inputPath);
            Output(outputPath, Convert(xmlDoc));
            Console.ReadLine();
        }

        static String Input(String path) //Считывает данные с файла по указанному пути 
        {
            var result = "";
            try
            {
                var reader = new StreamReader(path);
                result = reader.ReadToEnd();

            }
            catch (Exception ex) { Console.WriteLine("Error:" + ex.Message); }
            return result;

        }

        

        static void Output(String path, String jsonString) //Записывает данные jsonString в файл в директории path
        {
            try
            {
                using (var StreamWriter = new StreamWriter(path))
                {
                    StreamWriter.Write(jsonString);
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            
        }
        static String Convert(String xmlDoc) //Конвертирует xml документ в json строку
        {
            var json = "";
            var xml = new XmlDocument();
            

            try
            {
                xml.LoadXml(xmlDoc);
                json = JsonConvert.SerializeXmlNode(xml,Newtonsoft.Json.Formatting.Indented);



            } catch (Exception ex) { Console.WriteLine("Error:" + ex.Message); }

            return json;
        }
    }
}
