Use HRMS;
create Table DailyAttendance(
Id char(36) Primary Key,
AttendanceDate DateTime Not Null,
InTime Time Not Null,
OutTime Time Not Null,
EmployeeId char(36) Not Null,	
DepartmentId char(36) Not Null,
CreatedAt DateTime Not Null,
CreatedBy char(36) Not NUll,
UpdatedAt DateTime,
UpdatedBy char(36),
[Ip] char(255) Not Null,
IsActive bit Not Null
constraint fk_department_dailyAtt FOREIGN KEY (DepartmentId) references Department(Id),
constraint fk_employee_dailyAtt FOREIGN KEY (EmployeeId) references Employee(Id),
);

