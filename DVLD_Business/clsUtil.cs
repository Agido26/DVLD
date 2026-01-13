using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUtil
    {

       
        public static bool Change_File_Location(string SourceFile, string Destination)
        {
            string folder=Path.GetDirectoryName(Destination);

            if (File.Exists(SourceFile))
                {
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
              
                    File.Copy(SourceFile, Destination);
                return true;
                }
                return false;
        }
        public static string GenrateGuid()
        {
            Guid GenrateGuid = Guid.NewGuid();
            return GenrateGuid.ToString();
        }
        public static string ReplaceFileNameWithGuid(string FileName)
        {
            string New_File_Name = $"{GenrateGuid()}" + Path.GetExtension(FileName);
            return New_File_Name;
        }
        public static string ChangeImageLoctationToProjectLocation(string SourceFile)
        {
            string Destination = "C:\\DVLD_People_Photos\\";
            // Used guid to get random name for the file
            string New_File_Name =ReplaceFileNameWithGuid(SourceFile);

            
            //Combine the Random name with New_File_Directory to get complete path for the file
            string New_Path=Path.Combine(Destination,New_File_Name);

            //used func to to change the loction from old path to new path with random name we made and return the result
           if( !Change_File_Location(SourceFile, New_Path))
           {
                return "";
           }
            return New_Path;
        }
        public static void Writeinthefile(string FilePath, string Text) 
        {
            File.WriteAllText(FilePath, Text);
        }

        public static string[] split(string Text,string Sepratore)
        {
            string[] Words = Text.Split();
            return Words;


        }

        public static string DateNow()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/mm/yyyy");
        }

    }
}
