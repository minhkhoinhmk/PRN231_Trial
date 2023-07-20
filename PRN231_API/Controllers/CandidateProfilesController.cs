using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository;
using System;

namespace PRN231_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateProfilesController : ControllerBase
    {
        private readonly ICandidateProfileRepository candidateProfileRepository;

        public CandidateProfilesController(ICandidateProfileRepository candidateProfileRepository)
        {
            this.candidateProfileRepository = candidateProfileRepository;
        }

        [HttpGet]
        [EnableQuery]
        [Authorize(Roles = "2")]
        [EnableCors]
        public IActionResult GetAllPets()
        {
            return Ok(candidateProfileRepository.GetCandidateProfiles());
        }

        [HttpGet("search")]
        [EnableQuery]
        [Authorize(Roles = "2")]
        [EnableCors]
        public IActionResult SearchPets(DateTime? birthday, string fullName)
        {
            return Ok(candidateProfileRepository.SearchCandidateProfiles(birthday, fullName));
        }

        [HttpGet("{id}")]
        [EnableQuery]
        [Authorize(Roles = "2")]
        [EnableCors]
        public IActionResult GetPetById(string id)
        {
            return Ok(candidateProfileRepository.GetCandidateProfileById(id));
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        [EnableCors]
        public IActionResult CreatePet([FromBody] CandidateProfile candidateProfile)
        {
            try
            {
                candidateProfileRepository.Add(candidateProfile);
                return StatusCode(StatusCodes.Status201Created, candidateProfile);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "2")]
        [EnableCors]
        public IActionResult UpdatePet([FromBody] CandidateProfile candidateProfile)
        {
            try
            {
                candidateProfileRepository.Uppdate(candidateProfile);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        [EnableCors]
        public IActionResult DeletePet(string id)
        {
            try
            {
                candidateProfileRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
