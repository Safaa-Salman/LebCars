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
                        Email = "tony@test.com",
                        Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Age ="41",
                        Gender ="Male",
                        CarModel="New Land Rover Discovery",
                        CarNumber ="A 123456"
                    },
                    new AppUser
                    {
                        DisplayName = "Steve Rogers",
                        UserName = "steve",
                        Email = "steve@test.com",
                        Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Age ="35",
                        Gender ="Male",
                        CarModel="2021 A 220 Sedan",
                        CarNumber ="B 123456"
                    },
                    new AppUser
                    {
                        DisplayName = "Peter Parker",
                        UserName = "peter",
                        Email = "peter@test.com",
                        Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Age ="18",
                        Gender ="Male",
                        CarModel="2022 SQ7 Audi",
                        CarNumber ="C 123456"
                    },
                    new AppUser
                    {
                        DisplayName = "Nathalie Romanoff",
                        UserName = "nathalie",
                        Email = "nathalie@test.com",
                        Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Age ="31",
                        Gender ="Female",
                        CarModel="Tesla Model S",
                        CarNumber ="D 123456"
                    },
                    new AppUser
                    {
                        DisplayName = "Wanda Maximoff",
                        UserName = "wanda",
                        Email = "wanda@test.com",
                        Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Age ="27",
                        Gender ="Female",
                        CarModel="Porsche Panamera 4",
                        CarNumber ="E 123456"
                    },
                    new AppUser
                    {
                        DisplayName = "Pepper Potts",
                        UserName = "pepper",
                        Email = "pepper@test.com",
                        Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Age ="35",
                        Gender ="Female",
                        CarModel="Lexus IS 500",
                        CarNumber ="F 123456"
                    },
                    new AppUser
                    {
                        DisplayName = "Bucky Barnes",
                        UserName = "bucky",
                        Email = "bucky@test.com",
                        Bio = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Age ="34",
                        Gender ="Male",
                        CarModel="Lexus The 2022 NX",
                        CarNumber ="G 123456"
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
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true", 
                        Animals = "false",
                        Smoking = "false",
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
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "true",
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
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "false",
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
                        Destination = "Tyre, North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "3",
                        Cost = "55000",
                        Description = "Going to Tyre for about 3 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false", 
                        Animals = "false",
                        Smoking = "false",
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
                        Departure = "Aanjar, Bekaa Valley",
                        Destination = "Beit ed-Dine, Chouf District in the Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "2",
                        Cost = "66000",
                        Description = "Going to Beit- ed-Dine for  5 days",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "true",
                        Smoking = "false",
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
                        Departure = "Aabey, Mount Lebanon",
                        Destination = "Aramoun, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(2),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "1",
                        Cost = "8000",
                        Description = "Ride 1 month ago",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "true",
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
                        Departure = "Aley, Mount Lebanon",
                        Destination = "Aramoun, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "5",
                        Cost = "10000",
                        Description = "Going to Aramoun for 3 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "false",
                        Smoking = "true",
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
                        Departure = "Aley, Mount Lebanon",
                        Destination = "Bnachii lake, North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "3",
                        Cost = "88000",
                        Description = "Going to bnachii lake for about  5 hours",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "true",
                        Smoking = "true",
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
                        Departure = "Horsh Ehden, North Lebanon",
                        Destination = "Btater, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "2",
                        Cost = "110000",
                        Description = "Going to Btater for about 1 week",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "false",
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
                        Destination = "Jounieh, North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "2",
                        Cost = "30000",
                        Description = "Going to Jounieh for about 2 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "true",
                        Smoking = "false",
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
                        Destination = "Tyre, North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "6",
                        Cost = "35000",
                        Description = "Going to Tyre for about 3 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "false",
                        Smoking = "true",
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
                        Departure = "Aley, Mount Lebanon",
                        Destination = "Kadisha Valley, North Lebanon",
                        departureDate = DateTime.Now.AddMonths(3),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "7",
                        Cost = "120000",
                        Description = "Going to Kadisha Valley for about 1 day",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "true",
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
                        Destination = "Rocca Marina, Chekka  Lebanon",
                        departureDate = DateTime.Now.AddMonths(4),
                        returnDate = DateTime.Now.AddMonths(6),
                        passengerNumber = "3",
                        Cost = "160000",
                        Description = "Going to Rocca Marina  for about 40 days",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "true",
                        Smoking = "false",
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
                        Departure = "Bhamdoun, Mount Lebanon",
                        Destination = "Byblos Castle, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "5",
                        Cost = "85000",
                        Description = "Going to Byblos for about 4 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "true",
                        Smoking = "true",
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
                        Departure = "Bhamdoun, Mount Lebanon",
                        Destination = "Baabda, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "6",
                        Cost = "85000",
                        Description = "Going to Baabda for about 4 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "true",
                        Smoking = "false",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = false                            
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Jeita Grotto, North Lebanon",
                        Destination = "Bsarin, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "3",
                        Cost = "120000",
                        Description = "Going to Bsarin for about 3 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "true",
                        Smoking = "false",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = false                            
                            },
                        }
                    },

                     new Ride
                    {
                        Departure = "Zahle, Beqaa Lebanon",
                        Destination = "Rashaya, Beqaa Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "2",
                        Cost = "23000",
                        Description = "Going to Rashaya for about 2 days",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "false",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = true                            
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
                        Departure = "Koura, North Lebanon",
                        Destination = "Zgharta, North Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "2",
                        Cost = "35000",
                        Description = "Going to Zgharta for about 3 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "true",
                        Smoking = "false",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[5],
                                IsDriver = true                            
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
                        Departure = "Keserwan, Mount Lebanon",
                        Destination = "Bsarin, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "8",
                        Cost = "76000",
                        Description = "Going to Keserwan for about 1 hour",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "false",
                        Smoking = "false",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = false                            
                            },
                        }
                    },

                      new Ride
                    {
                        Departure = "Sour, South Lebanon",
                        Destination = "Bent Jbail, South Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "4",
                        Cost = "7000",
                        Description = "Going to Bent Jbail for about 5 hours",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "true",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = true                            
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
                        Departure = "Aley, Mount Lebanon",
                        Destination = "Sharoun, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "6",
                        Cost = "9000",
                        Description = "Going to Sharoun for about 5 hours",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "true",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[4],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = false                            
                            },
                        }
                    },

                    

                    new Ride
                    {
                        Departure = "Aanjar, Bekaa Valley",
                        Destination = "Bsarin, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "6",
                        Cost = "95000",
                        Description = "Going to Bsarin for  5 days",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "true",
                        Smoking = "false",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[5],
                                IsDriver = true
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
                        Departure = "Aabey, Mount Lebanon",
                        Destination = "Beirut, midpoint of Lebanon",
                        departureDate = DateTime.Now.AddMonths(2),
                        returnDate = DateTime.Now.AddMonths(5),
                        passengerNumber = "8",
                        Cost = "17000",
                        Description = "Ride 3 month ago",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = true
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
                        Departure = "Aley, Mount Lebanon",
                        Destination = "Beirut, midpoint of Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(2),
                        passengerNumber = "2",
                        Cost = "5000",
                        Description = "Going to Beirut,midpoint of Lebanon for 3 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[4],
                                IsDriver = true
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
                        Departure = "Aley ,Mount Lebanon",
                        Destination = "Sawfar ,Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "2",
                        Cost = "7000",
                        Description = "Going to Sawfar for about  2 hours",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "true",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = false                            
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Btater, Mount Lebanon",
                        Destination = "Sawfar, Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(-1),
                        passengerNumber = "5",
                        Cost = "7000",
                        Description = "Going to Sawfar for about 1 week",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[5],
                                IsDriver = true                            
                            }
                        }
                    },
                    new Ride
                    {
                        Departure = "Harissa, North Lebanon",
                        Destination = "Kaukaba, Southern Lebanon",
                        departureDate = DateTime.Now.AddMonths(-1),
                        returnDate = DateTime.Now.AddMonths(1),
                        passengerNumber = "8",
                        Cost = "66000",
                        Description = "Going to Kaukaba for about 2 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "true",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[0],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = false                            
                            },
                        }
                    },
                    new Ride
                    {
                        Departure = "Reshmaya, Mount Lebanon",
                        Destination = "Tyre , North Lebanon",
                        departureDate = DateTime.Now.AddMonths(3),
                        returnDate = DateTime.Now.AddMonths(3),
                        passengerNumber = "1",
                        Cost = "98000",
                        Description = "Going to Tyre for about 2 weeks",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "true",
                        Attendees = new List<RideAttendee>
                        {
                             new RideAttendee
                            {
                                AppUser = users[5],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = false                            
                            },
                            
                        }
                    },
                    new Ride
                    {
                        Departure = "Aley ,Mount Lebanon",
                        Destination = "Chouf,Mount Lebanon",
                        departureDate = DateTime.Now.AddMonths(3),
                        returnDate = DateTime.Now.AddMonths(4),
                        passengerNumber = "3",
                        Cost = "16000",
                        Description = "Going to Chouf for about 2 weeks",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "true",
                        Animals = "false",
                        Smoking = "false",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[3],
                                IsDriver = true                            
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
                        Destination = "Akkar ,  Lebanon",
                        departureDate = DateTime.Now.AddMonths(4),
                        returnDate = DateTime.Now.AddMonths(7),
                        passengerNumber = "4",
                        Cost = "160000",
                        Description = "Going to Akkar  for about 3 months",
                        BaggageCost = "0",
                        Baggage = "false",
                        Children = "false",
                        Animals = "false",
                        Smoking = "false",
                        Attendees = new List<RideAttendee>
                        {
                            new RideAttendee
                            {
                                AppUser = users[6],
                                IsDriver = true                            
                            },
                            new RideAttendee
                            {
                                AppUser = users[4],
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
