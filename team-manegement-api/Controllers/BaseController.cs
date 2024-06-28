using Application.Services;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace team_manegement_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T : class, IBaseEntity
    {
        private readonly BaseService<T> _service;

        public BaseController(BaseService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetByIdAsync(Guid id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<T>> AddAsync(T entity)
        {
            var addedEntity = await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = addedEntity.Id }, addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            var success = await _service.UpdateAsync(entity);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
