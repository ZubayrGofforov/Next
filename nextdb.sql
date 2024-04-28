CREATE TABLE Users
( Id CHAR(36) PRIMARY KEY,
  FirstName varchar2(50) NOT NULL,
  LastName varchar2(50) NOT NULL,
  PhoneNumber varchar2(20) NOT NULL,
  Email varchar(50) NOT NULL,
  CreatedAt TIMESTAMP, 
  UpdatedAt TIMESTAMP
);  

select * from users