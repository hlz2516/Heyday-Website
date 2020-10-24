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
	_Hours int,
	Credit decimal,
	Tnumber nvarchar(10) references Teacher(TNumber)
);

create table Score(
	SNumber nvarchar(20) references Student(SNumber),
	CNumber nvarchar(10) references Course(CNumber),
	Score int,
	primary key(SNumber,CNumber)
);

insert into Department(DNumber,Name,Leader) values 
('01','机电','李三'),
('02','能源','李四'),
('03','计算机','李五'),
('04','自动控制','李六');

insert into Student(SNumber,Name,Sex,Age,DNumber,Sclass) values
('98030101','张三','男','20','03','980301'),
('98030102','张四','女','20','03','980301'),
('98030103','张五','男','19','03','980301'),
('98040201','王三','男','20','04','980302'),
('98040202','王四','男','21','04','980302'),
('98040203','王五','女','19','04','980302');

insert into Teacher(TNumber,Name,DNumber,Salary) values
('001','赵三','01',1200.00),
('002','赵四','03',1400.00),
('003','赵五','03',1000.00);


insert into Course(CNumber,Name,_Hours,Credit,Tnumber) values
('001','数据库',40,6,'001'),
('002','计算机导论',30,6,'002'),
('003','数据结构',40,6,'003'),
('004','编译原理',40,6,'001'),
('005','C语言',30,4.5,'003');

insert into Score(SNumber,CNumber,Score) values
('98030101','001',92),
('98030101','002',85),
('98030101','003',88),
('98040202','002',90),
('98040202','003',80),
('98040202','001',55),
('98040203','003',56),
('98030102','001',54),
('98030102','002',85);