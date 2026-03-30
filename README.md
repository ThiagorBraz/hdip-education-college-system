# HDip Education College System

A full-stack web system developed as part of the 2nd Semester 
Web Design module at Atlantic Technological University (ATU), 
Sligo, Ireland.

## About the Project

This system manages student registrations and grant application 
decisions for an educational college. It consists of two 
interconnected projects that communicate via HTTP requests.

## System Architecture

### HDipEducationCollegeOfficial (MVC)
An ASP.NET MVC web application for managing student records. 
Features include:
- List all registered students
- Add new students (Student ID, Name and PPS Number)
- Edit student details
- View student details and grant application status
- Delete students
- Real-time grant status retrieved from the Grant Decision API

### StudentSupportAgency_API (Web API)
A RESTful Web API that provides grant application decisions 
based on a student's PPS Number. The MVC application queries 
this API in real time when viewing student details.

## Technologies Used

- C# / ASP.NET MVC 5
- ASP.NET Web API
- Entity Framework 6
- SQL Server Express
- .NET Framework 4.8
- HTTP Client for API communication

## Database Structure

### EducateDB
Stores student records with StudentID, StudentName and PPSNumber.

### GrantDB
Stores grant application decisions with ApplicationID, PPSNumber 
and Decision (True = Approved and False = Rejected).

## How to Run

1. Open `StudentSupportAgency_API` in Visual Studio and run it 
   — the API must be running on port 51637
2. Open `HDipEducationCollegeOfficial` in Visual Studio and run it
3. Both projects must be running simultaneously for the grant 
   status feature to work

## Database Setup

Run the following scripts in SQL Server Management Studio (SSMS):
- `GrantDB_script.sql` — creates and populates the GrantDB database
- `EducateDB_script.sql` — creates and populates the EducateDB database

## Academic Context

Developed at Atlantic Technological University (ATU), Sligo — 
Higher Diploma in Computer Science, 2nd Semester, Web Design Module.
