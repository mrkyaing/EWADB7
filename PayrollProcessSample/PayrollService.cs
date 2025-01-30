namespace PayrollProcessSample
{
    public class PayrollService : IPayrollService
    {
        private decimal benificalAmount;
        public void CalculatePayroll(int WorkingDays, decimal AttendanceDays, decimal BaseSalary, decimal Benefit, decimal Deduction)
        {
           decimal perDayAmount=(BaseSalary/WorkingDays);//300000/30
           decimal GrossPay=(perDayAmount*AttendanceDays)+Benefit-Deduction;
           benificalAmount=GrossPay;
           Console.WriteLine("Gross Pay:"+GrossPay);
        }

        public decimal PayrollTransfer(string AccountNo, string staffName)
        {
            Console.WriteLine($"Payroll transaction to this AccountNo: {AccountNo} for this staff:{staffName}");
           return benificalAmount;
        }
    }
}