USE [master]
GO

/****** Object:  Database [BookShop]    Script Date: 05.05.2023 19:43:14 ******/
CREATE DATABASE [BookShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BookShop] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BookShop] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BookShop] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BookShop] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BookShop] SET ARITHABORT OFF 
GO

ALTER DATABASE [BookShop] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BookShop] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BookShop] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BookShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BookShop] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BookShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BookShop] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BookShop] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BookShop] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BookShop] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BookShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BookShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BookShop] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BookShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BookShop] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BookShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BookShop] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BookShop] SET RECOVERY FULL 
GO

ALTER DATABASE [BookShop] SET  MULTI_USER 
GO

ALTER DATABASE [BookShop] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BookShop] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BookShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BookShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BookShop] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BookShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BookShop] SET QUERY_STORE = OFF
GO

ALTER DATABASE [BookShop] SET  READ_WRITE 
GO

USE [BookShop]

create table Customer(
Login varchar(20) Primary Key,
Password varchar(16) not null,
Last_name varchar(20) null,
First_name varchar(20) null,
Middle_name varchar(20) null,
Phone_number char(12) not null,
Zip_code int null,
Region varchar(50) null,
City varchar(30) null,
Street varchar(30) null,
House int null,
Flat int null,
Age int not null,
Gender bit not null,
Deleted bit default 0 not null)

create table Category(
Name varchar(30) Primary key,
Deleted bit default 0 not null)

create table Attribute(
Name varchar(50) Primary key,
Deleted bit default 0 not null)

create table Book(
ISBN int Primary Key,
Category varchar(30) not null,
Name varchar(50) not null,
Author varchar(50) not null,
Publishing_house varchar(50) not null,
Year_of_publishing int not null,
Pages int not null,
Amount_in_stock int not null,
Price decimal(7,2) not null,
Deleted bit default 0 not null,
Foreign key (Category) references Category(Name))

create table Category_attribute(
Category varchar(30) not null,
Attribute varchar(50) not null,
Deleted bit default 0 not null,
Primary key(Category, Attribute),
Foreign key(Category) references Category(Name),
Foreign key(Attribute) references Attribute(Name))

create table Book_property(
ISBN int not null,
Attribute varchar(50) not null,
Value sql_variant not null,
Deleted bit default 0 not null,
Primary key(ISBN, Attribute),
Foreign key (ISBN) references Book(ISBN),
Foreign key(Attribute) references Attribute(Name))

create table Cart(
Id int Primary key,
Customer_login varchar(20) not null,
Deleted bit default 0 not null,
Foreign key(Customer_login) references Customer(login))

create table Cart_item(
Cart_id int not null,
ISBN int not null,
Amount int not null,
Deleted bit default 0 not null,
Primary key(Cart_id, ISBN),
Foreign key(Cart_id) references Cart(Id),
Foreign key(ISBN) references Book(ISBN))

create table Order_details(
Cart_id int Primary key,
Registration_time datetime not null,
Pickup bit not null,
Delivery_zip_code int null,
Delivery_region varchar(50) null,
Delivery_city varchar(30) null,
Delivery_street varchar(30) null,
Delivery_house int null,
Delivery_flat int null,
Delivery_date date null,
Delivery_price decimal(6,2) null,
Completion_time datetime null,
Payment_type varchar(20) not null,
Payed bit not null,
Status varchar(20) not null,
Deleted bit default 0 not null,
Foreign key(Cart_id) references Cart(id))