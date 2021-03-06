﻿USE [master]
GO

/****** Object:  Database [NHibernateDemo]    Script Date: 25. 11. 2015 10:15:22 ******/
CREATE DATABASE [NHibernateDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NHibernateDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.PTOPSQL2012\MSSQL\DATA\NHibernateDemo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NHibernateDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.PTOPSQL2012\MSSQL\DATA\NHibernateDemo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [NHibernateDemo] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NHibernateDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [NHibernateDemo] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [NHibernateDemo] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [NHibernateDemo] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [NHibernateDemo] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [NHibernateDemo] SET ARITHABORT OFF 
GO

ALTER DATABASE [NHibernateDemo] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [NHibernateDemo] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [NHibernateDemo] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [NHibernateDemo] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [NHibernateDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [NHibernateDemo] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [NHibernateDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [NHibernateDemo] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [NHibernateDemo] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [NHibernateDemo] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [NHibernateDemo] SET  DISABLE_BROKER 
GO

ALTER DATABASE [NHibernateDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [NHibernateDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [NHibernateDemo] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [NHibernateDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [NHibernateDemo] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [NHibernateDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [NHibernateDemo] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [NHibernateDemo] SET RECOVERY FULL 
GO

ALTER DATABASE [NHibernateDemo] SET  MULTI_USER 
GO

ALTER DATABASE [NHibernateDemo] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [NHibernateDemo] SET DB_CHAINING OFF 
GO

ALTER DATABASE [NHibernateDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [NHibernateDemo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [NHibernateDemo] SET  READ_WRITE 
GO