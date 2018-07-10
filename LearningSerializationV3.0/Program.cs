using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.IO;

namespace LearningSerializationV3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int intValue = 48769414;
            string stringValue = "Witaj!";
            byte[] byteArray = { 47, 129, 0, 116 };
            float floatValue = 491.695F;
            char charValue = 'E';

            using (FileStream output = File.Create("danebinarne.dat"))
            using (BinaryWriter writer = new BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(floatValue);
                writer.Write(charValue);
            }

            byte[] dataWritter = File.ReadAllBytes("danebinarne.dat");
            foreach (byte b in dataWritter)
                Console.Write("{0:x2} ", b);
            Console.WriteLine(" - {0} bajtów", dataWritter.Length);
            Console.ReadKey();

            using (FileStream input = File.OpenRead("danebinarne.dat"))
            using (BinaryReader reader = new BinaryReader(input))
            {
                //Few methods avaiable for BinaryReader 
                int intRead = reader.ReadInt32();
                string stringRead = reader.ReadString();
                byte[] byteArrayRead = reader.ReadBytes(4); 
                float floatRead = reader.ReadSingle(); 
                char charRead = reader.ReadChar();

                Console.Write("int : {0} string: {1} bajty: ", intRead, stringRead);
                foreach (byte b in byteArrayRead)
                    Console.Write("{0} ", b);
                Console.Write(" float: {0} char: {1}", floatRead, charRead);

                Console.ReadKey();
            }
        }

    }
}
