using Microsoft.AspNetCore.Mvc;
using P2PdemoApi.Model;
using P2PdemoApi.Repositories;
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
        // GET: api/FilesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FileEndPoint>> Get()
        {
            List<FileEndPoint> files =  _fileRepository.GetAll();
            if (files == null) return NotFound("Nothing here");
            string jsonFiles = JsonSerializer.Serialize(files);
            return Ok(jsonFiles);
        }

        // GET api/<FilesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FileEndPoint> Get(int id)
        {
            FileEndPoint file = _fileRepository.GetById(id);
            if (file == null) return NotFound("No file with key");
            string jsonFile = JsonSerializer.Serialize(file);
            return Ok(jsonFile);

        }

        // POST api/<FilesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FileEndPoint> Post([FromBody] FileEndPoint value)
        {
            try
            {
                FileEndPoint newFile = _fileRepository.Add(value);
                return Created($"api/Files/{newFile.key}", newFile);
            }
            catch (ArgumentNullException n)
            {
                return BadRequest(n.Message);
            }
            catch (ArgumentOutOfRangeException n)
            {
                return BadRequest(n.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FilesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public ActionResult<FileEndPoint> Delete(int id)
        {
            FileEndPoint fileToDelete = _fileRepository.Delete(id);
            if (fileToDelete == null) return BadRequest("No id found");
            return Ok(fileToDelete);
        }
    }
}
