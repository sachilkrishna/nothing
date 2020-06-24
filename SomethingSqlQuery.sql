ADMIN-PC\SQLEXPRESS

--create database something
use something


create table user_type
(user_type_id int primary key ,user_type_name varchar(max))

insert into user_type values(1,'Normal')
insert into user_type values(2,'Admin')

create table users
(
uid int primary key identity(1,1),  fname varchar(max), lname varchar(max), email_id varchar(max), password varchar(max), user_type_id int foreign key references user_type(user_type_id) ON DELETE SET NULL ON UPDATE CASCADE)



create proc register_user
(
@fname varchar(max), @lname varchar(max), @email_id varchar(max), @password varchar(max)
)
as
begin
declare @user_type_id int
set @user_type_id=1
insert into users (fname , lname, email_id , password , user_type_id ) values(@fname , @lname, @email_id , @password , @user_type_id)
end

