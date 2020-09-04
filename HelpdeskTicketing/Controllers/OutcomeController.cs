using System;
namespace HelpdeskTicketing.Controllers
{
    public class OutcomeController
    {
        [ApiController]
        [Route("[controller]")]
        public class OutcomeController : ControllerBase
        {


            private readonly OutcomeService _outcomeService;

            public OutcomeController(OutcomeService outcomeService)
            {
                _outcomeService = outcomeService;
            }

            [HttpGet]
            public ActionResult<List<Outcome>> Get() =>
                _outcomeService.Get();


            [HttpGet("{Id}", Name = "GetOutcome")]
            public ActionResult<Outcome> Get(string id)
            {
                var outcome = _outcomeService.Get(id);

                if (outcome == null)
                {
                    return NotFound();
                }

                return outcome;
            }

            [HttpPost]
            public ActionResult<Outcome> Create(Outcome outcome)
            {
                _outcomeService.Create(outcome);

                return CreatedAtRoute("GetOutcome", new { id = outcome.Id.ToString() }, outcome);
            }

            [HttpPut("{Id}")]
            public IActionResult Update(string id, Outcome outcomeIn)
            {
                var outcome = _outcomeService.Get(id);

                if (outcome == null)
                {
                    return NotFound();
                }

                _outcomeService.Update(id, outcomeIn);

                return NoContent();
            }

            [HttpDelete("{Id}")]
            public IActionResult Delete(string id)
            {
                var outcome = _outcomeService.Get(id);

                if (outcome == null)
                {
                    return NotFound();
                }

                _outcomeService.Remove(outcome.Id);

                return NoContent();
            }
        }
}
