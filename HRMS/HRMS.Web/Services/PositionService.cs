using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.UnitOfWorks;
using HRMS.Web.Utilities;

namespace HRMS.Web.Services {
    public class PositionService : IPositionService {
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(IUnitOfWork unitOfWork) {
            this._unitOfWork = unitOfWork;
        }
        public async void Create(PositionViewModel viewModel) {
            try {
                //DTO >> Data Transfer Object in hre ( from View Models to Data Model)
                PositionEntity positionEntity = new PositionEntity() {
                    Id = Guid.NewGuid().ToString(),//for Primary Key 
                    Code = viewModel.Code,
                    Description = viewModel.Description,
                    Level = viewModel.Level,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = await NetworkHelper.GetIpAddressAsnyc()
                };
                _unitOfWork.PositoryRepository.Create(positionEntity);
                _unitOfWork.Commit();
            }
            catch (Exception e) {
                _unitOfWork.Rollback();
            }
        }

        public void Delete(string Id) {
            try {
                PositionEntity positionEntity = _unitOfWork.PositoryRepository.GetAll(w => w.Id == Id).FirstOrDefault();
                if (positionEntity is not null) {
                    positionEntity.IsActive = false;
                    _unitOfWork.PositoryRepository.Delete(positionEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception e) {
                _unitOfWork.Rollback();
            }
        }

        public IEnumerable<PositionViewModel> GetAll() {
            return _unitOfWork.PositoryRepository.GetAll(w => w.IsActive).Select(s => new PositionViewModel {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description,
                Level = s.Level.Value
            });
        }

        public PositionViewModel GetById(string id) {
            return _unitOfWork.PositoryRepository.GetAll(w => w.IsActive && w.Id == id).Select(s => new PositionViewModel {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description,
                Level = s.Level.Value
            }).FirstOrDefault();
        }

        public async void Update(PositionViewModel positionVM) {
            try {
                //DTO >> Data Transfer Object in hre ( from View Models to Data Model)
                PositionEntity existingPositionEntity = _unitOfWork.PositoryRepository.GetAll(w => w.IsActive && w.Id == positionVM.Id).FirstOrDefault();
                if (existingPositionEntity is not null) {
                    existingPositionEntity.Description = positionVM.Description;
                    existingPositionEntity.Level = positionVM.Level;
                    existingPositionEntity.UpdatedAt = DateTime.Now;
                    existingPositionEntity.UpdatedBy = "system";
                    existingPositionEntity.Ip = await NetworkHelper.GetIpAddressAsnyc();
                    _unitOfWork.PositoryRepository.Update(existingPositionEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception e) {
                _unitOfWork.Rollback();
            }
        }
    }
}
