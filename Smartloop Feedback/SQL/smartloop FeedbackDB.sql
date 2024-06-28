-- Drop the database if it exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'smartloop_feedbackdb')
BEGIN
    DROP DATABASE smartloop_feedbackdb;
END;
GO

-- Create the new database
CREATE DATABASE smartloop_feedbackdb;
GO

-- Use the new database
USE smartloop_feedbackdb;
GO

-- Create the student table
CREATE TABLE student (
    studentId INT PRIMARY KEY,
    name VARCHAR(225) NOT NULL,
    email VARCHAR(225) NOT NULL,
    password VARCHAR(225) NOT NULL,
    degree VARCHAR(225),
    profileImage VARBINARY(MAX)
);
GO

-- Create the year table
CREATE TABLE year (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(225),
    studentId INT,
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO

-- Create the semester table
CREATE TABLE semester (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(225),
    yearId INT,
    studentId INT,
    FOREIGN KEY (yearId) REFERENCES year(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO

-- Create the subject table
CREATE TABLE course (
    id INT IDENTITY(1,1) PRIMARY KEY,
    code INT,
    title VARCHAR(225),
    creditPoint INT,
    description VARCHAR(225),
    semesterId INT,
    studentId INT,
    FOREIGN KEY (semesterId) REFERENCES semester(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO
