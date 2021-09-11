using System;
using Application.Core;

namespace Application.Rides
{
    public class RideParams : PagingParams
    {
        public bool IsGoing { get; set; }
        public bool IsDriver { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}