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
                        DisplayName = "Tony Stark",
                        UserName = "tony",
                        Email = "tony@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Steve Rogers",
                        UserName = "steve",
                        Email = "steve@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Peter Parker",
                        UserName = "peter",
                        Email = "peter@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Nathalie Romanoff",
                        UserName = "nathalie",
                        Email = "nathalie@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Wanda Maximoff",
                        UserName = "wanda",
                        Email = "wanda@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Pepper Potts",
                        UserName = "pepper",
                        Email = "pepper@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Bucky Barnes",
                        UserName = "bucky",
                        Email = "bucky@test.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                var rides = new List<Ride>
                {
                    new Ride
                    {
                        Departure = "Kobeih, Mount Lebanon",
                        Destination = "Aley, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "4",
                        Cost = "4000",
                        Description = "Going to Aley for about 3 hours",
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
                        Departure = "Tripoli, North Lebanon",
                        Destination = "Saida, South Lebanon",
                        departureDate = DateTime.Now.AddMonths(2),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "4",
                        Cost = "70000",
                        Description = "Going for Vaccation, returning after a month",
                        Children = true,
                        Animals = false,
                        Smoking = true,
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
                        Departure = "Aley, Mount Lebanon",
                        Destination = "Beirut, Beirut",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "20000",
                        Description = "Going to Beirut for about 5 hours",
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
                        Departure = "Jeita Grotto, North Lebanon",
                        Destination = "Tyre , North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "3",
                        Cost = "55000",
                        Description = "Going to Tyre for about 3 months",
                        Children = false,
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
                        Departure = "Aanjar , Bekaa Valley",
                        Destination = "Beit ed-Dine ,Chouf District in the Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "2",
                        Cost = "66000",
                        Description = "Going to Beit- ed-Dine for  5 days",
                        Children = false,
                        Animals = true,
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
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = false
                            }
                            
                        }
                    },
                    new Ride
                    {
                        Departure = "Aabey ,Mount Lebanon",
                        Destination = "Aramoun ,Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(2),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "1",
                        Cost = "8000",
                        Description = "Ride 1 month ago",
                        Children = true,
                        Animals = false,
                        Smoking = true,
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[2],
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
                        Departure = "Aalay,Mount Lebanon",
                        Destination = "Aramoun ,Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "5",
                        Cost = "10000",
                        Description = "Going to Aramoun for 3 months",
                        Children = false,
                        Animals = false,
                        Smoking = true,
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
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = false
                            },
                            new RideAttendee
                            {
                                AppUser = users[4],
                                IsDriver = false
                            }
                        }
                    },
                    new Ride
                    {
                        Departure = "Aalay ,Mount Lebanon",
                        Destination = "bnachii lake,North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "3",
                        Cost = "88000",
                        Description = "Going to bnachii lake for about  5 hours",
                        Children = false,
                        Animals = true,
                        Smoking = true,
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
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = false
                            }
                        }
                    },
                    new Ride
                    {
                        Departure = "Horsh Ehden,North Lebanon",
                        Destination = "Btater, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "2",
                        Cost = "110000",
                        Description = "Going to Btater for about 1 week",
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
                        Departure = "Harissa, North Lebanon",
                        Destination = "Jounieh , North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "2",
                        Cost = "30000",
                        Description = "Going to Jounieh for about 2 months",
                        Children = true,
                        Animals = true,
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
                        Departure = "Baalbek, North Lebanon",
                        Destination = "Tyre , North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "6",
                        Cost = "35000",
                        Description = "Going to Tyre for about 3 months",
                        Children = false,
                        Animals = false,
                        Smoking = true,
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
                            new RideAttendee
                            {
                                AppUser = users[5],
                                IsDriver = false
                            },
                            new RideAttendee
                            {
                                AppUser = users[4],
                                IsDriver = false
                            },
                            
                        }
                    },
                    new Ride
                    {
                        Departure = "Aley ,Mount Lebanon",
                        Destination = "Kadisha Valley,North Lebanon",
                        departureDate = DateTime.Now.AddMonths(3),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "7",
                        Cost = "120000",
                        Description = "Going to Kadisha Valley for about 1 day",
                        Children = true,
                        Animals = false,
                        Smoking = true,
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
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = false
                            },
                            new RideAttendee
                            {
                                AppUser = users[4],
                                IsDriver = false
                            },
                            new RideAttendee
                            {
                                AppUser = users[5],
                                IsDriver = false
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Baalbek, North Lebanon",
                        Destination = "Rocca Marina ,Chekka  Lebanon",
                        departureDate = DateTime.Now.AddMonths(4),
                        returnDate = DateTime.Now.AddMonths(6),
                        passengerNumber = "3",
                        Cost = "160000",
                        Description = "Going to Rocca Marina  for about 40 days",
                        Children = false,
                        Animals = true,
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
                        Departure = "Bhamdoun,Mount Lebanon",
                        Destination = "Byblos Castle,Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "5",
                        Cost = "85000",
                        Description = "Going to Byblos for about 4 months",
                        Children = true,
                        Animals = true,
                        Smoking = true,
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
