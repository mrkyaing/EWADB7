Use HRMS;
create Table ShiftAssign(
Id char(36) Primary Key,
EmployeeId Char(36) Not Null,
ShiftId Char(36) Not Null,
DepartmentId char(36) Not Null,	
FromDate DateTime Not Null,
ToDate DateTime Not Null,
CreatedAt DateTime Not Null,
CreatedBy char(36) Not NUll,
UpdatedAt DateTime,
UpdatedBy char(36),
[Ip] char(255) Not Null,
IsActive bit Not Null
constraint fk_department_shiftassg FOREIGN KEY (DepartmentId) references Department(Id),
constraint fk_employee_shiftassg FOREIGN KEY (EmployeeId) references Employee(Id),
constraint fk_shift_shiftassg FOREIGN KEY (ShiftId) references Shift(Id),
);

