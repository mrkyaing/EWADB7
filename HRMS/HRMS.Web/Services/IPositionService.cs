using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;

namespace HRMS.Web.Services {
    public interface IPositionService {
        //crud process
        PositionEntity Create(PositionViewModel viewModel);
        IEnumerable<PositionViewModel> GetAll();
        PositionViewModel GetById(string id);
        PositionEntity Update(PositionViewModel viewModel);
        bool Delete(string Id);

        //new implemenation in here 
        ///see more .....................................................
        ///............................................
        ///....................................................
        ///..................................................

    }
}
