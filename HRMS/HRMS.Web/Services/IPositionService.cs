using HRMS.Web.Models.ViewModels;

namespace HRMS.Web.Services {
    public interface IPositionService {
        //crud process
        void Create(PositionViewModel viewModel);
        IEnumerable<PositionViewModel> GetAll();
        PositionViewModel GetById(string id);
        void Update(PositionViewModel viewModel);
        void Delete(string Id);
    }
}
