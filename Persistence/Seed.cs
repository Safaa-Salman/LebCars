using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !context.Rides.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                var rides = new List<Ride>
                {
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[0],
                                IsDriver = true
                            }
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[0],
                                IsDriver = true
                            },
                            new RideAttendee
                            {
                                AppUser = users[1],
                                IsDriver = false
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[2],
                                IsDriver = true
                            },
                            new RideAttendee
                            {
                                AppUser = users[1],
                                IsDriver = false
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[0],
                                IsDriver = true
                            },
                            new RideAttendee
                            {
                                AppUser = users[2],
                                IsDriver = false
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[1],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[0],
                                IsDriver = false                            
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[1],
                                IsDriver = true                            
                            }
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[0],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[1],
                                IsDriver = false                            
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[2],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[1],
                                IsDriver = false                            
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[0],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[2],
                                IsDriver = false                            
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Ride 1 month ago",
                        Destination = "Ride 1 month ago",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Activity 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = false,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[2],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[1],
                                IsDriver = false                            
                            },
                        }
                    }
                };

                await context.Rides.AddRangeAsync(rides);
                await context.SaveChangesAsync();
            }
        }
    }
}
