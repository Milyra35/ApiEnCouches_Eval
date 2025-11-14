
using ApiEnCouches.DataAccess.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace ApiEnCouches.DataAccess.Seed
{
    public class RoomSeeder : ISeeder
    {
        //private readonly Microsoft.AspNet.Identity.UserManager<IdentityUser> _userManager;
        public async Task Execute(AppDbContext appDbContext, bool isProduction)
        {

            if (!isProduction && !appDbContext.Rooms.Any())
            {
                var rooms = new List<Room>
                { 
                    new()
                    {
                        Name = "Room 101",
                        Capacity = 15,
                        Timeslots = new List<TimeSlot>()
                        {
                            new TimeSlot()
                            {
                                StartTime = new TimeOnly(14, 0),
                                EndTime = new TimeOnly(15, 0),
                                UserId = null
                            },
                            new TimeSlot()
                            {
                                StartTime = new TimeOnly(16, 00),
                                EndTime = new TimeOnly(17, 00),
                                UserId  = null
                            }
                        }
                    },
                    new()
                    {
                        Name = "Room 102",
                        Capacity = 20,
                        Timeslots = new List<TimeSlot>()
                        {
                            new TimeSlot()
                            {
                                StartTime = new TimeOnly(10, 0),
                                EndTime = new TimeOnly(11, 0),
                                UserId = null
                            },
                            new TimeSlot()
                            {
                                StartTime = new TimeOnly(13, 0),
                                EndTime = new TimeOnly(14, 0),
                                UserId = null
                            }
                        }
                    }
                };
                appDbContext.Rooms.AddRange(rooms);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}