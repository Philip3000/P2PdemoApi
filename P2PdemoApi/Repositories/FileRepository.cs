using P2PdemoApi.Model;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;

namespace P2PdemoApi.Repositories
{
    public class FileRepository
    {
        private int _nextId = 1;
        private readonly List<FileEndPoint> Data;

        public FileRepository()
        {
            Data = new List<FileEndPoint>
            {
                new FileEndPoint {key = _nextId++, IpAddress = "10.200.91.42", PortNumber = 21},
                new FileEndPoint {key = _nextId++, IpAddress = "10.200.91.42", PortNumber = 21}
            };
        }

        public List<FileEndPoint> GetAll()
        {
            return new List<FileEndPoint>(Data);
            
        }

        public FileEndPoint? GetById(int id)
        {
            return Data.Find(FileEndPoint => FileEndPoint.key == id);
        }

        public FileEndPoint Add(FileEndPoint newFile)
        {
            newFile.key = _nextId++;
            Data.Add(newFile);
            return newFile;
        }

        public FileEndPoint? Delete(int id)
        {
            FileEndPoint? file = GetById(id);
            if (file == null) return null;
            Data.Remove(file);
            return file;
        }

        public FileEndPoint? Update(int id, FileEndPoint updates)
        {
            FileEndPoint? file = GetById(id);
            if (file == null) return null;
            file.key = updates.key;
            file.IpAddress = updates.IpAddress;
            file.PortNumber = updates.PortNumber;
            return file;
        }
    }
}
