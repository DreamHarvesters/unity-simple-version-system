using UnityEditor;
using UnityEngine;

namespace DH.Versioning
{
    public static class Utils
    {
        public static void GetFolderAndParentPath(string path, out string parentPath, out string folderName)
        {
            if (HasPathFileName(path))
                path = path.Replace("/" + GetFileNameWithExtension(path), string.Empty);
            
            path = path.Replace("\\", "/");                                                               
            path = path.Replace(Application.dataPath, string.Empty);                                      
            parentPath = path.Substring(0, path.LastIndexOf("/"));                                        
            folderName = path.Substring(path.LastIndexOf("/") + 1);                                       
        }

        public static string GetFileName(string path, string extension)
        {
            path = path.Replace("\\", "/");
            string fileName = path.Substring(path.LastIndexOf("/") + 1).Replace("." + extension, string.Empty);
            return fileName;
        }
        
        public static string GetFileNameWithExtension(string path)
        {
            path = path.Replace("\\", "/");
            string fileName = path.Substring(path.LastIndexOf("/") + 1);
            return fileName;
        }

        public static bool HasPathFileName(string path)
        {
            return path.Contains(".");
        }

//        public static bool HasFolder(string path)
//        {
//            string folder, parentPath; 
//            GetFolderAndParentPath(path, out parentPath, out folder);
//            return AssetDatabase.IsValidFolder(parentPath + "/" + folder);
//        }
//
//        public static void CreateFolder(string parentFolder, string folder)
//        {
//            AssetDatabase.CreateFolder(parentFolder, folder);
//        }
    }
}