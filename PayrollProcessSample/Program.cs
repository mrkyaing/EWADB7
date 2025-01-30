// See https://aka.ms/new-console-template for more information
using PayrollProcessSample;

Console.WriteLine("Hello, World!");
BankAccount account = new BankAccount()
{
    AccountNo = "123-08-9",
    OpeningBalance = 1000
};
Staff aStaff = new Staff()
{
    Name = "MG MG",
    BaseSalary = 300000,
    AttendanceDays=30,
    bankAccount=account
};
IPayrollService payrollService=new PayrollService();
payrollService.CalculatePayroll(30,aStaff.AttendanceDays,aStaff.BaseSalary,50000,0);
account.Deposit(payrollService.PayrollTransfer(account.AccountNo,aStaff.Name));

account.CheckBalance();//351000
account.Withdraw(10000);
account.CheckBalance();//341000
account.Withdraw(500000);