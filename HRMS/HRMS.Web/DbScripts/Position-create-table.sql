Use HRMS;
create Table Position(
Id char(36) Primary Key,
Code nvarchar(255) Not Null,
[Description] nvarchar(255) Not Null,
Level int ,
CreatedAt DateTime Not Null,
CreatedBy char(36) Not NUll,
UpdatedAt DateTime,
UpdatedBy char(36),
[Ip] char(255) Not Null,
IsActive bit Not Null
);