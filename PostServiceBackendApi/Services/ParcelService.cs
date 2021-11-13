using PostServiceBackendApi.Entities;
using PostServiceBackendApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackendApi.Services
{
    public class ParcelService
    {
        private readonly ParcelRepository _parcelRepository;
        private readonly PostRepository _postRepository;

        public ParcelService(ParcelRepository parcelRepository, PostRepository postRepository)
        {
            _parcelRepository = parcelRepository;
            _postRepository = postRepository;
        }
        public async Task<int> AddAsync(Parcel parcel)
        {

            var entity = new Parcel()
            {
                Weight = parcel.Weight,
                PhoneNo = parcel.PhoneNo,
                Info = parcel.Info,
                PostId = parcel.PostId
            };

            if (entity.PostId == 0)
            {
                entity.PostId = null;
            }
            await _parcelRepository.AddParcelAsync(entity);
            return entity.Id;
        }
        public async Task<List<Parcel>> GetAllAsync()
        {
            var parcelEntities = await _parcelRepository.GetAllParcelsAsync();

            return parcelEntities.ToList();
        }
        public async Task<Parcel> GetByIdAsync(int id)
        {
            var parcel = await _parcelRepository.GetParcelByIdAsync(id);
            if (parcel == null)
            {
                throw new ArgumentException("Record not found");
            }
            return parcel;
        }
        public async Task UpdateParcelAsync(Parcel parcel)
        {
            var entity = new Parcel()
            {
                Id = parcel.Id,
                Weight = parcel.Weight,
                PhoneNo = parcel.PhoneNo,
                Info = parcel.Info,
                PostId = parcel.PostId
            };
            if (entity.Id != parcel.Id)
            {
                throw new ArgumentException("Parcel not found");
            }
            if (parcel.PostId != parcel.PostId)
            {
                throw new ArgumentException("Post not found");
            }
            await _parcelRepository.UpdateParcelAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var parcel = await GetByIdAsync(id);
            await _parcelRepository.DeleteAsync(parcel);
        }
        public async Task<List<Parcel>> GetParcelsByPostIdAsync(int postId)
        {
            var parcelEntities = await _parcelRepository.GetAllParcelsAsync();
            if (postId != 0)
            {
                return await _parcelRepository.GetAllParcelsByPostIdAsync(postId);
            }

            return parcelEntities.ToList();
        }
    }
}
