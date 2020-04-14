using System;
using System.IO;

namespace CopyFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class CopyDirectory
    {
        // function to copy a folder to another location
        public static void DirectoryCopy(string sourceDirName, string destDirName,
                                      bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            
            if (!dir.Exists)
            {
                
                /*throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);*/
            }
           
        
            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        // function for single file copy
        public static void SingleFileCopy(string sourceFileName, string destDirName,string fileName)
        {
             string destinationFullPath = System.IO.Path.Combine(destDirName,fileName);
             
           
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);

            }

            // if the source file and destination are not the same copy the file
            if (sourceFileName != destinationFullPath)
            {
                File.Copy(sourceFileName, destinationFullPath, true);
            }
        }
    }
}
