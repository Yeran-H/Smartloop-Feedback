﻿-- Drop the database if it exists
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

-- Create the year table
CREATE TABLE year (
    name INT PRIMARY KEY
);
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

-- Create the semester table
CREATE TABLE semester (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(MAX),
    yearName INT,
    FOREIGN KEY (yearName) REFERENCES year(name)
);
GO

-- Create the course table
CREATE TABLE course (
    id INT IDENTITY(1,1) PRIMARY KEY,
    code INT,
    name VARCHAR(MAX),
    creditPoint INT,
    description VARCHAR(MAX),
    yearName INT,
    semesterId INT,
    canvasLink VARCHAR(MAX),
    tutorNum INT,
    FOREIGN KEY (yearName) REFERENCES year(name),
    FOREIGN KEY (semesterId) REFERENCES semester(id)
);
GO

-- Create the assessment table (before tutorialAssessment and tutorialAssociation since they reference it)
CREATE TABLE assessment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(225),
    description VARCHAR(MAX),
    courseDescription VARCHAR(MAX),
    type VARCHAR(225),
    date DATE,
    weight DECIMAL (18,2),
    mark DECIMAL (18,2),
    canvasLink VARCHAR(MAX),
    fileName VARCHAR(MAX),
    fileData VARBINARY(MAX),
    courseId INT,
    FOREIGN KEY (courseId) REFERENCES course(id)
);
GO

-- Create the tutorial table
CREATE TABLE tutorial (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(MAX),
    courseId INT,
    FOREIGN KEY (courseId) REFERENCES course(id)
);
GO

-- Create the tutorialAssociation table
CREATE TABLE tutorialAssociation (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tutorialId INT NULL,
    generalFeedback VARCHAR(MAX),
    isCompleted BIT,
    FOREIGN KEY (tutorialId) REFERENCES tutorial(id)
);
GO

-- Create the tutorialAssessment table
CREATE TABLE tutorialAssessment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tutorialId INT NULL,
    generalFeedback VARCHAR(MAX),
    isCompleted BIT,
    assessmentId INT NULL,
    FOREIGN KEY (tutorialId) REFERENCES tutorialAssociation(id),
    FOREIGN KEY (assessmentId) REFERENCES assessment(id)
);
GO

-- Create the criteria table
CREATE TABLE criteria (
    id INT IDENTITY(1,1) PRIMARY KEY,
    description VARCHAR(MAX),
    assessmentId INT,
    FOREIGN KEY (assessmentId) REFERENCES assessment(id)
);
GO

-- Create the rating table
CREATE TABLE rating (
    id INT IDENTITY(1,1) PRIMARY KEY,
    description VARCHAR(MAX),
    grade VARCHAR(225),
    criteriaId INT,
    FOREIGN KEY (criteriaId) REFERENCES criteria(id)
);
GO

-- Create the yearAssociation table
CREATE TABLE yearAssociation (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name INT,
    isStudent BIT,
    studentId INT,
    tutorId INT,
    FOREIGN KEY (name) REFERENCES year(name),
    FOREIGN KEY (studentId) REFERENCES student(studentId),
    FOREIGN KEY (tutorId) REFERENCES tutor(tutorId)
);
GO

-- Create the semesterAssociation table
CREATE TABLE semesterAssociation (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(MAX),
    isStudent BIT,
    yearId INT,
    semesterId INT,
    studentId INT,
    tutorId INT,
    FOREIGN KEY (semesterId) REFERENCES semester(id),
    FOREIGN KEY (yearId) REFERENCES yearAssociation(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId),
    FOREIGN KEY (tutorId) REFERENCES tutor(tutorId)
);
GO

-- Create the courseAssociation table
CREATE TABLE courseAssociation (
    id INT IDENTITY(1,1) PRIMARY KEY,
    isStudent BIT,
    isCompleted BIT,
    courseId INT,
    semesterId INT,
    studentId INT,
    tutorId INT,
    FOREIGN KEY (semesterId) REFERENCES semesterAssociation(id),
    FOREIGN KEY (courseId) REFERENCES course(id),
    FOREIGN KEY (studentId) REFERENCES student(studentId),
    FOREIGN KEY (tutorId) REFERENCES tutor(tutorId)
);
GO

-- Create the studentCourse table
CREATE TABLE studentCourse (
    id INT IDENTITY(1,1) PRIMARY KEY,
    courseAssociationId INT,
    courseMark DECIMAL (18,2),
    tutorialId INT,
    userId INT,
    FOREIGN KEY (courseAssociationId) REFERENCES courseAssociation(id),
    FOREIGN KEY (tutorialId) REFERENCES tutorial(id),
    FOREIGN KEY (userId) REFERENCES student(studentId)
);
GO

-- Create the tutorCourse table
CREATE TABLE tutorCourse (
    id INT IDENTITY(1,1) PRIMARY KEY,
    courseAssociationId INT,
    tutorialId VARCHAR(MAX),
    userId INT,
    FOREIGN KEY (courseAssociationId) REFERENCES courseAssociation(id),
    FOREIGN KEY (userId) REFERENCES tutor(tutorId)
);
GO

-- Create the studentAssessment table
CREATE TABLE studentAssessment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    assessmentId INT,
    status INT,
    studentMark DECIMAL (18,2),
    isFinalised BIT,
    feedback VARCHAR(MAX),
    courseId INT,
    userId INT,
    FOREIGN KEY (assessmentId) REFERENCES assessment(id),
    FOREIGN KEY (userId) REFERENCES student(studentId),
    FOREIGN KEY (courseId) REFERENCES courseAssociation(id)
);
GO

-- Create the checkList table
CREATE TABLE checkList (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(MAX),
    isChecked BIT,
    assessmentId INT,
    userId INT,
    FOREIGN KEY (assessmentId) REFERENCES studentAssessment(id),
    FOREIGN KEY (userId) REFERENCES student(studentId)
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
    userId INT,
    FOREIGN KEY (assessmentId) REFERENCES studentAssessment(id),
    FOREIGN KEY (userId) REFERENCES student(studentId)
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
    userId INT,
    FOREIGN KEY (courseId) REFERENCES courseAssociation(id)
);
GO

-- Create the triggers (after all necessary tables are created)

-- Trigger for yearAssociation
CREATE TRIGGER TRG_Check_UserAssociation_Year
ON yearAssociation
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM yearAssociation
        WHERE 
            (studentId IS NOT NULL AND tutorId IS NOT NULL) OR 
            (studentId IS NULL AND tutorId IS NULL)
    )
    BEGIN
        RAISERROR('Either studentId or tutorId must be populated, but not both or neither.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Trigger for semesterAssociation
CREATE TRIGGER TRG_Check_UserAssociation_Semester
ON semesterAssociation
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM semesterAssociation
        WHERE 
            (studentId IS NOT NULL AND tutorId IS NOT NULL) OR 
            (studentId IS NULL AND tutorId IS NULL)
    )
    BEGIN
        RAISERROR('Either studentId or tutorId must be populated, but not both or neither.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Trigger for courseAssociation
CREATE TRIGGER TRG_Check_UserAssociation_CourseAssociation
ON courseAssociation
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM courseAssociation
        WHERE 
            (studentId IS NOT NULL AND tutorId IS NOT NULL) OR 
            (studentId IS NULL AND tutorId IS NULL)
    )
    BEGIN
        RAISERROR('Either studentId or tutorId must be populated, but not both or neither.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO
