create database FALL2021_SWP201;
use FALL2021_SWP201;

create table dbo.class(
	id int primary key identity(1, 1),
	name nvarchar(20) not null unique,
);

create table dbo.account(
	id int primary key identity(1, 1),
	username nvarchar(50) unique not null,
	password nvarchar(32) not null,
	role_id int,
);

create table dbo.admin_profile (
	id int primary key identity(1, 1),
	fullname nvarchar(50) not null,
	avatar nvarchar(255) not null default '/media/profiles/default.png',
	email nvarchar(50),
	phone nvarchar(11),
	gender bit,
	account_id int unique,
	foreign key (account_id) references dbo.account (id) on delete cascade on update cascade,
);

create table dbo.teacher_profile(
	id int primary key identity(1, 1),
	fullname nvarchar(50) not null,
	avatar nvarchar(255) not null default '/media/profiles/default.png',
	email nvarchar(50),
	phone nvarchar(11),
	gender bit,
	birthday date,
	teacher_code nvarchar(10),
	account_id int unique,
	foreign key (account_id) references dbo.account (id) on delete cascade on update cascade,
);

create table dbo.student_profile(
	id int primary key identity(1, 1),
	fullname nvarchar(50) not null,
	avatar nvarchar(255) not null default '/media/profiles/default.png',
	email nvarchar(50),
	phone nvarchar(11),
	gender bit,
	birthday date,
	major nvarchar(50),
	student_code nvarchar(10) not null,
	account_id int unique,
	class_id int,
	foreign key (account_id) references dbo.account (id) on delete cascade on update cascade,
	foreign key (class_id) references dbo.class (id) on delete set null on update cascade,
);

create table dbo.subject(
	id int primary key identity(1, 1),
	code nvarchar(10) unique not null,
	fullname nvarchar(255) not null,
);

create table dbo.room_chat(
	id int primary key identity(1, 1),
	class_id int,
	subject_id int,
	teacher_id int,
	constraint uc_room_chat unique(class_id, subject_id),
	foreign key (class_id) references dbo.class (id) on delete set null on update cascade,
	foreign key (subject_id) references dbo.subject (id) on delete set null on update cascade,
	foreign key (teacher_id) references dbo.teacher_profile (id) on delete set null on update cascade,
);

create table dbo.group_chat (
	id int primary key identity(1, 1),
	name nvarchar(50) not null,
	room_id int not null,
	_index int,
	foreign key (room_id) references dbo.room_chat (id) on delete cascade on update cascade,
);

create table dbo.group_manage (
	id int primary key identity(1, 1),
	student_id int not null,
	group_id int not null,
	role bit default 0,
	foreign key (student_id) references dbo.student_profile (id) on delete cascade,
	foreign key (group_id) references dbo.group_chat (id) on delete cascade,
);

create table dbo.room_message (
	id int primary key identity(1, 1),
	account_id int,
	room_id int,
	content nvarchar(500) not null,
	time_message datetime not null,
	foreign key (room_id) references dbo.room_chat (id) on delete cascade,
	foreign key (account_id) references dbo.account (id) on delete set null,
);

create table dbo.group_message (
	id int primary key identity(1, 1),
	account_id int,
	group_id int,
	content nvarchar(500) not null,
	foreign key (group_id) references dbo.group_chat (id) on delete cascade,
	foreign key (account_id) references dbo.account (id) on delete set null,
);

create table dbo.room_file (
	id int primary key identity(1, 1),
	room_message_id int,
	file_url nvarchar(255),
	foreign key (room_message_id) references dbo.room_message (id) on delete no action,
);

create table dbo.group_file (
	id int primary key identity(1, 1),
	group_message_id int,
	file_url nvarchar(255),
	foreign key (group_message_id) references dbo.group_message (id) on delete no action,
);

create table dbo.notifications (
	id int primary key identity(1, 1),
	account_id int not null,
	content nvarchar(255) not null,
	foreign key (account_id) references dbo.account (id) on delete cascade,
);

create table dbo.login_cookie (
	id int primary key identity(1, 1),
	login_key nvarchar(24) unique not null,
	account_id int not null,
	expiration_time datetime not null,
);

create table dbo.room_marked_message (
	id int primary key identity(1, 1),
	room_message_id int not null,
	time_marked datetime default current_timestamp,
	foreign key (room_message_id) references dbo.room_message (id) on delete cascade,
);

create table dbo.group_marked_message (
	id int primary key identity(1, 1),
	group_message_id int not null,
	time_marked datetime default current_timestamp,
	foreign key (group_message_id) references dbo.group_message (id) on delete cascade,
);

create table dbo.room_dealine (
	id int primary key identity(1, 1),
	room_id int not null,
	content nvarchar(500) not null,
	expiration_time datetime,
	foreign key (room_id) references dbo.room_chat (id) on delete cascade,
);

create table dbo.group_dealine (
	id int primary key identity(1, 1),
	group_id int not null,
	content nvarchar(500) not null,
	expiration_time datetime,
	foreign key (group_id) references dbo.group_chat (id) on delete cascade,
);