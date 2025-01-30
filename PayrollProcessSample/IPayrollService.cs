namespace PayrollProcessSample
{
    public interface IPayrollService
    {
        public void CalculatePayroll(int WorkingDays, decimal AttendanceDays, decimal BaseSalary, decimal Benefit, decimal Deduction);
        decimal PayrollTransfer(string AccountNo,string staffName);
    }
}