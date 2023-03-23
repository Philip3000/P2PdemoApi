using P2PdemoApi.Model;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;

namespace P2PdemoApi.Repositories
{
    public class FileRepository
    {
        private Dictionary<string, List<FileEndPoint>> Data;

        public FileRepository()
        {
            Data = new Dictionary<string, List<FileEndPoint>>();
        }
        public List<string> GetFileNames()
        {
            return Data.Keys.ToList();
        }
        public List<FileEndPoint>? GetAll(string fileName)
        {
            if (Data.ContainsKey(fileName))
            {
                return Data[fileName];
            }
            return null;
        }


        public FileEndPoint Add(string fileName, FileEndPoint newFile)
        {
            if (!Data.ContainsKey(fileName))
            {
                Data.Add(fileName, new List<FileEndPoint>());
            }
            Data[fileName].Add(newFile);
            return newFile;
        }

        public FileEndPoint? Delete(string fileName, FileEndPoint fileToBeDeleted)
        {
            if (Data.ContainsKey(fileName))
            {
                List<FileEndPoint> list = Data[fileName];
                foreach (var item in list)
                {
                    if (item.ipAddress == fileToBeDeleted.ipAddress && item.Port == fileToBeDeleted.Port)
                    {
                        list.Remove(item);
                    }
                }
            }
            return null;
            
        }
    }
}
