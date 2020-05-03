using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiBestPractices.Contracts;
using WebApiBestPractices.Entities;
using WebApiBestPractices.Entities.Dto;
using WebApiBestPractices.Entities.Model;

namespace WebApiBestPractices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public OwnerController(IRepositoryWrapper repositoryWrapper, ILogger<OwnerController> logger, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _repositoryWrapper.Owner.GetAllOwnersAsync();

            var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);

            _logger.LogInformation("Getting All Owners");

            throw new ApplicationException("sdsadssssss ");
            return Ok(ownersResult);
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var owner = await _repositoryWrapper.Owner.GetOwnerByIdAsync(id);

            if (owner == null) return NotFound();

            var ownerResult = _mapper.Map<OwnerDto>(owner);

            return Ok(ownerResult);
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid id)
        {
             
                var owner = await _repositoryWrapper.Owner.GetOwnerWithDetailsAsync(id);

                if (owner == null) return NotFound();


                var ownerResult = _mapper.Map<OwnerDto>(owner);

                return Ok(ownerResult);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto owner)
        {

            if(owner == null) return BadRequest("Owner object is null");


            var ownerEntity = _mapper.Map<Owner>(owner);

            _repositoryWrapper.Owner.CreateOwner(ownerEntity);
            await _repositoryWrapper.SaveAsync();

            var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);


            return CreatedAtRoute("OwnerById", new {Id = createdOwner.Id}, createdOwner);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] OwnerForUpdateDto owner)
        {
            if(owner == null) return BadRequest("Owner object is null");

            var ownerEntity = await _repositoryWrapper.Owner.GetOwnerByIdAsync(id);

            if (ownerEntity == null) return NotFound();

            _mapper.Map(owner, ownerEntity);

            _repositoryWrapper.Owner.UpdateOwner(ownerEntity);
            await _repositoryWrapper.SaveAsync();


            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            var owner = await _repositoryWrapper.Owner.GetOwnerByIdAsync(id);

            if (owner == null) return NotFound();

            if (_repositoryWrapper.Account.AccountsByOwner(id).Any())
            { 
                return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
            }


            _repositoryWrapper.Owner.DeleteOwner(owner);
            await _repositoryWrapper.SaveAsync();

            return NoContent();
        }
    }
}