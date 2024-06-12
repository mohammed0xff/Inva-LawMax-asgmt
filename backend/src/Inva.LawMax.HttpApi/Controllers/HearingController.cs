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
    public class HearingsController : AbpControllerBase
    {
        private readonly IRepository<Hearing, Guid> _hearingRepository;

        public HearingsController(IRepository<Hearing, Guid> hearingRepository)
        {
            LocalizationResource = typeof(LawMaxResource);
            _hearingRepository = hearingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hearing>>> GetAll()
        {
            return await _hearingRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hearing>> Get(Guid id)
        {
            var hearing = await _hearingRepository.GetAsync(id);
            if (hearing == null)
            {
                return NotFound();
            }
            return hearing;
        }

        [HttpPost]
        public async Task<ActionResult<Hearing>> Create(Hearing hearing)
        {
            await _hearingRepository.InsertAsync(hearing);
            return CreatedAtAction(nameof(Get), new { id = hearing.Id }, hearing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Hearing hearing)
        {
            if (id != hearing.Id)
            {
                return BadRequest();
            }

            await _hearingRepository.UpdateAsync(hearing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var hearing = await _hearingRepository.FindAsync(id);
            if (hearing == null)
            {
                return NotFound();
            }

            await _hearingRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
