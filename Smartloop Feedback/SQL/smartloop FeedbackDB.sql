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

-- Create the tutor table
CREATE TABLE tutor (
    tutorId INT PRIMARY KEY,
    name VARCHAR(225) NOT NULL,
    email VARCHAR(225) NOT NULL,
    password VARCHAR(225) NOT NULL,
    profileImage VARBINARY(MAX)
);
GO

-- Create the year table
CREATE TABLE year (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name INT,
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

-- Create the course table
CREATE TABLE course (
    id INT IDENTITY(1,1) PRIMARY KEY,
    code INT,
    name VARCHAR(MAX),
    creditPoint INT,
    description VARCHAR(MAX),
    year VARCHAR(MAX),
    semester VARCHAR(MAX),
    canvasLink VARCHAR(MAX)
);
GO

-- Create the course table
--CREATE TABLE course (
--    id INT IDENTITY(1,1) PRIMARY KEY,
--    code INT,
--    title VARCHAR(225),
--    creditPoint INT,
--    description VARCHAR(MAX),
--    isCompleted BIT,
--    canvasLink VARCHAR(MAX),
--    semesterId INT,
--    studentId INT,
--    FOREIGN KEY (semesterId) REFERENCES semester(id),
--    FOREIGN KEY (studentId) REFERENCES student(studentId)
--);
--GO

-- Create the assessment table
CREATE TABLE assessment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(225),
    description VARCHAR(MAX),
    courseDescription VARCHAR(MAX),
    type VARCHAR(225),
    date DATE,
    status INT,
    weight DECIMAL (18,2),
    mark DECIMAL (18,2),
    finalMark DECIMAL (18,2),
    individual BIT,
    [group] BIT,
    isFinalised BIT,
    finalFeedback VARCHAR(MAX),
    canvasLink VARCHAR(MAX),
    courseId INT,
    studentId INT,
    FOREIGN KEY (courseId) REFERENCES course(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO

-- Create the criteria table
CREATE TABLE criteria (
    id INT IDENTITY(1,1) PRIMARY KEY,
    description VARCHAR(MAX),
    assessmentId INT,
    studentId INT,
    FOREIGN KEY (assessmentId) REFERENCES assessment(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO

-- Create the rating table
CREATE TABLE rating (
    id INT IDENTITY(1,1) PRIMARY KEY,
    description VARCHAR(MAX),
    grade VARCHAR(225),
    criteriaId INT,
    studentId INT,
    FOREIGN KEY (criteriaId) REFERENCES criteria(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO

-- Create the event table
CREATE TABLE event (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(MAX),
    date DATETIME,
    startTime TIME (7),
    endTime TIME (7),
    category VARCHAR(MAX),
    color INT,
    courseId INT,
    studentId INT,
    FOREIGN KEY (courseId) REFERENCES course(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO

-- Create the checkList table
CREATE TABLE checkList (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(MAX),
    isChecked BIT,
    assessmentId INT,
    studentId INT,
    FOREIGN KEY (assessmentId) REFERENCES assessment(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO

-- Create the feedbackResult table
CREATE TABLE feedbackResult (
    id INT IDENTITY(1,1) PRIMARY KEY,
    attempt INT,
    teacherFeedback VARCHAR(MAX),
    fileName VARCHAR(MAX),
    fileData VARBINARY(MAX),
    notes VARCHAR(MAX),
    feedback VARCHAR(MAX),
    previousAttemptId VARCHAR(MAX),
    previousAssessmentId VARCHAR(MAX),
    assessmentId INT,
    studentId INT,
    FOREIGN KEY (assessmentId) REFERENCES assessment(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId)
);
GO