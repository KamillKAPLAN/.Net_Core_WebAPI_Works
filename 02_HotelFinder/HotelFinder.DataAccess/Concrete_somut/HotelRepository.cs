using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext hotelDbContext = new HotelDbContext();

        public List<Hotel> GetAllHotels()
        {
            return hotelDbContext.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return hotelDbContext.Hotels.Find(id);
            /* eğer id alanı pk olmazsa Find yerine FirstOrDefault kullanılır. */
        }

        public Hotel CreateHotel(Hotel hotel)
        {
            hotelDbContext.Hotels.Add(hotel);
            hotelDbContext.SaveChanges();
            return hotel;
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            hotelDbContext.Hotels.Update(hotel);
            /* hotelDbContext.Hotels.OrderBy(x => x.Id); 
            hotelDbContext.Hotels.OrderByDescending(x => x.Id); */
            return hotel;
        }

        public void DeleteHotel(int id)
        {
            var deletedHotel = GetHotelById(id);
            hotelDbContext.Hotels.Remove(deletedHotel);
            hotelDbContext.SaveChanges();
        }
    }
}