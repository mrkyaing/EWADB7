namespace HRMS.Web.Services {
    public interface IUserService {
        Task<string> CreateUserWithRole(string userName, string email);
    }
}
