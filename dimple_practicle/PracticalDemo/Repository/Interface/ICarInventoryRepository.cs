using PracticalDemoWebAPI.Models;

namespace PracticalDemoWebAPI.Repository.Interface
{
    public interface ICarInventoryRepository
    {
        Task<List<CarInventoryModel>> GetCarList();
        Task<CarInventoryModel> GetCarInventoryById(Guid id);
        Task<bool> AddNew(CarInventoryModel model);
        Task<int> UpdateInventoryById(Guid id, CarInventoryModel model);
        Task<int> DeleteById(Guid id);


    }
}
