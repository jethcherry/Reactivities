using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        // private readonly IMediator _mediator;
        // public ActivitiesController(IMediator mediator)
        // {
        //     _mediator = mediator;
            
        // }


        [HttpGet] // GET api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] // GET api/activities/{id}
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id=id});
        }

        [HttpPost] //Post api/activities/
        public async Task<IActionResult> CreateActivity (Activity activity){
            await Mediator.Send(new Create.Command{Activity=activity});
            return Ok();

        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> EditActivity(Guid id,Activity activity)
        {
            activity.Id = id;

            await Mediator.Send(new Edit.Command{Activity = activity});
            return Ok();

        }
     }
}
