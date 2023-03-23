using Microsoft.AspNetCore.Mvc;
using P2PdemoApi.Model;
using P2PdemoApi.Repositories;
using System.Collections.Generic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2PdemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileRepository _fileRepository;
        public FilesController(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        // GET: api/<FilesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _fileRepository.GetFileNames();
        }

        // GET api/<FilesController>/5
        [HttpGet("{fileName}")]
     
        public List<FileEndPoint> Get(string fileName)
        {
            return _fileRepository.GetAll(fileName);
        }

        // POST api/<FilesController>
        [HttpPost("{fileName}")]
        public FileEndPoint Post(string fileName, [FromBody] FileEndPoint newFile)
        {
            return _fileRepository.Add(fileName, newFile);
        }

        // DELETE api/<FilesController>/5
        
        [HttpDelete("{fileName}")]
        public ActionResult<FileEndPoint> Delete(string fileName, FileEndPoint fileToBeDeleted)
        {
            return _fileRepository.Delete(fileName, fileToBeDeleted);
        }
    }
}
