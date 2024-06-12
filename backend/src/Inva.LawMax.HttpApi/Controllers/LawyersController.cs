using Inva.LawMax.Entities;
using Inva.LawMax.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;


namespace Inva.LawMax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyersController : AbpControllerBase
    {
        private readonly IRepository<Lawyer, Guid> _lawyerRepository;

        public LawyersController(IRepository<Lawyer, Guid> lawyerRepository)
        {
            LocalizationResource = typeof(LawMaxResource);
            _lawyerRepository = lawyerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lawyer>>> GetAll()
        {
            return await _lawyerRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lawyer>> Get(Guid id)
        {
            var lawyer = await _lawyerRepository.GetAsync(id);
            if (lawyer == null)
            {
                return NotFound();
            }
            return lawyer;
        }

        [HttpPost]
        public async Task<ActionResult<Lawyer>> Create(Lawyer lawyer)
        {
            await _lawyerRepository.InsertAsync(lawyer);
            return CreatedAtAction(nameof(Get), new { id = lawyer.Id }, lawyer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Lawyer lawyer)
        {
            if (id != lawyer.Id)
            {
                return BadRequest();
            }

            await _lawyerRepository.UpdateAsync(lawyer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var lawyer = await _lawyerRepository.FindAsync(id);
            if (lawyer == null)
            {
                return NotFound();
            }

            await _lawyerRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
