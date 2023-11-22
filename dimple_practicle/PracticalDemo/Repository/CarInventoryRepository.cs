using Microsoft.EntityFrameworkCore;
using PracticalDemoWebAPI.DBContext;
using PracticalDemoWebAPI.Models;
using PracticalDemoWebAPI.Repository.Interface;

namespace PracticalDemoWebAPI.Repository
{
    public class CarInventoryRepository : ICarInventoryRepository
    {
        private readonly DBContextClass _dbContext;
        public CarInventoryRepository(DBContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        #region GetList
        public async Task<List<CarInventoryModel>> GetCarList()
        {
            try
            {
                var cars = await _dbContext.carInventroys.Select(c => new CarInventoryModel
                {
                    CompanyName = c.CompanyName,
                    Name = c.Name,
                    Condition = c.Condition,
                    Description = c.Description,
                    Years = c.Years,
                    HasValidInsurance = c.HasValidInsurance,
                    Id = c.Id,
                    Image = c.Image,
                }).ToListAsync();
                return cars;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetInventoryById
        public async Task<CarInventoryModel> GetCarInventoryById(Guid id)
        {
            try
            {
                var currentInventory = await _dbContext.carInventroys.FirstOrDefaultAsync(x => x.Id == id);
                if (currentInventory != null)
                {
                    return currentInventory;
                }
                return new CarInventoryModel();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region AddNewRecord
        public async Task<bool> AddNew(CarInventoryModel model)
        {
            try
            {
                var newData = new CarInventoryModel
                {
                    CompanyName = model.CompanyName.Trim(),
                    Name = model.Name.Trim(),
                    Image = model.Image,
                    Condition = model.Condition,
                    Description = model.Description,
                    HasValidInsurance = model.HasValidInsurance

                };
                await _dbContext.carInventroys.AddAsync(newData);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

        #region Update specific record
        public async Task<int> UpdateInventoryById(Guid id, CarInventoryModel model)
        {
            try
            {
                var currentRecord = await _dbContext.carInventroys.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (currentRecord == null)
                {
                    return 0;
                }

                currentRecord.CompanyName = model.CompanyName.Trim();
                currentRecord.Name = model.Name.Trim();
                currentRecord.Image = model.Image;
                currentRecord.Condition = model.Condition;
                currentRecord.Description = model.Description.Trim();
                currentRecord.HasValidInsurance = model.HasValidInsurance;
                currentRecord.Years = model.Years;


                _dbContext.carInventroys.Update(currentRecord);
                await _dbContext.SaveChangesAsync();
                return 1;

            }
            catch (Exception)
            {

                return 2;
            }
        }
        #endregion

        #region Delete
        public async Task<int> DeleteById(Guid id)
        {
            try
            {
                var currentInventory = await _dbContext.carInventroys.FirstOrDefaultAsync(x => x.Id == id);
                if (currentInventory != null)
                {
                    return 0;
                }
                _dbContext.carInventroys.Remove(currentInventory);
                await _dbContext.SaveChangesAsync();
                return 1;

            }
            catch (Exception)
            {
                return 2;
            }

        }
        #endregion
    }
}
