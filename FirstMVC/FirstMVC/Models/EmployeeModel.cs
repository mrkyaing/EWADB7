namespace FirstMVC.Models {
    public class EmployeeModel {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //Has-A relationship
        public AddressModel HomeAddress { get; set; }
    }
}
