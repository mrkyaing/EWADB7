Use HRMS;
create Table Department(
Id char(36) Primary Key,
Code nvarchar(255) Not Null,
[Description] nvarchar(255) Not Null,
ExtensionPhone nvarchar(255),
CreatedAt DateTime Not Null,
CreatedBy char(36) Not NUll,
UpdatedAt DateTime,
UpdatedBy char(36),
[Ip] char(255) Not Null,
IsActive bit Not Null
);