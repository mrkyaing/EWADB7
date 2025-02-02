namespace WorkOutMVC.Models {
    public class EmployeeModel {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Has-A relatiosnip
        public AddressModel HomeAddress { get; set; }
    }
}
