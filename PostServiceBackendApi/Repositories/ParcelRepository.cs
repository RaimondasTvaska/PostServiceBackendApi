using Microsoft.EntityFrameworkCore;
using PostServiceBackendApi.Data;
using PostServiceBackendApi.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackendApi.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _context;

        public ParcelRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddParcelAsync(Parcel parcel)
        {
            _context.Add(parcel);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Parcel>> GetAllParcelsAsync()
        {
            return await _context.Parcels.Include(po => po.Post).ToListAsync();
        }
        public async Task<Parcel> GetParcelByIdAsync(int id)
        {
            return await _context.Parcels.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateParcelAsync(Parcel parcel)
        {
            _context.Update(parcel);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Parcel parcel)
        {
            _context.Remove(parcel);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Parcel>> GetAllParcelsByPostIdAsync(int postId)
        {
            return await _context.Parcels.Include(po => po.Post).Where(pa => pa.PostId == postId).ToListAsync();
        }
    }
}
