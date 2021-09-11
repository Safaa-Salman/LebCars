using System;
using System.Threading.Tasks;
using Application.Rides;
using Application.Core;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RidesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetRides([FromQuery] RideParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query{Params = param}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRide(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRide(Ride ride)
        {
            return HandleResult(await Mediator.Send(new Create.Command {Ride = ride}));
        }

        [Authorize(Policy = "IsRideDriver")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRide(Guid id, Ride ride)
        {
            ride.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command{Ride = ride}));
        }

        [Authorize(Policy = "IsRideDriver")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRide(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{Id = id}));
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command{Id = id}));
        }
    }
}