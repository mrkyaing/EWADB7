namespace PayrollProcessSample
{
    public class Staff : IShowDetail
    {
        public required string Name { get; set; }
        public required decimal BaseSalary { get; set; }
        public decimal AttendanceDays { get; set; }

        //Has-A Relationship
        public  BankAccount bankAccount { get; set; }
        
        public void StaffDetail()
        {
            Console.WriteLine("Staff Detail Information in Here");
            Console.WriteLine("Name:"+Name);
            Console.WriteLine("BaseSalary:"+Name);
            Console.WriteLine("AttendanceDays:"+Name);
        }
    }
}