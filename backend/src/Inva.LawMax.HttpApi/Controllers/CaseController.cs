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
    public class CasesController : AbpControllerBase
    {
        private readonly IRepository<Case, Guid> _caseRepository;

        public CasesController(IRepository<Case, Guid> caseRepository)
        {
            LocalizationResource = typeof(LawMaxResource);
            _caseRepository = caseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Case>>> GetAll()
        {
            return await _caseRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> Get(Guid id)
        {
            var caseItem = await _caseRepository.GetAsync(id);
            if (caseItem == null)
            {
                return NotFound();
            }
            return caseItem;
        }

        [HttpPost]
        public async Task<ActionResult<Case>> Create(Case caseItem)
        {
            await _caseRepository.InsertAsync(caseItem);
            return CreatedAtAction(nameof(Get), new { id = caseItem.Id }, caseItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Case caseItem)
        {
            if (id != caseItem.Id)
            {
                return BadRequest();
            }

            await _caseRepository.UpdateAsync(caseItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var caseItem = await _caseRepository.FindAsync(id);
            if (caseItem == null)
            {
                return NotFound();
            }

            await _caseRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
