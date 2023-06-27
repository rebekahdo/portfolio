/*
 * Rebekah Myrick
 * rebekahgmyrick@lewisu.edu
 * 6/6/2023 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyrickContactManager
{
    // ContactWriter.cs
    internal class ContactWriter
    {
        public void WriteContactsToFile(string fileName, List<Contact> contacts)
        {
            string extension = Path.GetExtension(fileName);
            bool isBinaryFile = (extension == ".bin");

            if (isBinaryFile)
            {
                // Write contacts to a binary file
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    foreach (Contact contact in contacts)
                    {
                        writer.Write(contact.ToString());
                    }
                }
            }
            else
            {
                // Write contacts to a text file
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (Contact contact in contacts)
                    {
                        writer.WriteLine(contact.ToString());
                    }
                }
            }
        }
    }
}
