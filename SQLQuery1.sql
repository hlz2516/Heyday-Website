create table Department(
	DNumber nvarchar(20) primary key,
	Name nvarchar(20),
	Leader nvarchar(20)
);

create table Student(
	SNumber nvarchar(20) primary key,
	Name nvarchar(50) not null,
	Sex nvarchar(2),
	Age tinyint,
	DNumber nvarchar(20) references Department(DNumber),
	Sclass nvarchar(20)
);

create table Teacher(
	TNumber nvarchar(10) primary key,
	Name nvarchar(50),
	DNumber nvarchar(20) references Department(DNumber),
	Salary decimal
);

create table Course(
	CNumber nvarchar(10) primary key,
	Name nvarchar(50),
	Hours int,
	Credit decimal,
	Tnumber nvarchar(10) references Teacher(TNumber)
);

create table Score(
	SNumber nvarchar(20) references Student(SNumber),
	CNumber nvarchar(10) references Course(CNumber),
	Score decimal
);