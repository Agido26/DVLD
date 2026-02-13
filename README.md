# DVLD
# Driving & Vehicle Licensing Department (DVLD) System
# 📌 Project Overview
The DVLD System is a comprehensive desktop application designed to manage the full lifecycle of driving licenses and vehicle-related services. It automates administrative tasks for a licensing department, including person registration, user management, application processing, multi-stage testing, and license issuance (local and international).
The project is built with a focus on Object-Oriented Programming (OOP) principles and follows a strict N-Tier Architecture to ensure scalability, maintainability, and separation of concerns.
# 🛠 Technology Stack
Language: C#
Platform: .NET Framework (Windows Forms)[1]
Database: Microsoft SQL Server
Data Access: ADO.NET (Procedural and Prepared Statements)
Architecture: 3-Tier Architecture (Presentation, Business, Data)
UI Components: standard WinForms / (Optional: Guna UI Framework for enhanced styling)
# 🏗 Technical Architecture
The system is divided into three distinct layers to decouple the business logic from data access and user interface:
Presentation Layer (PL):
Contains the Windows Forms and User Controls.[2][3]
Handles user input, validation, and UI updates.
Communicates strictly with the Business Layer.
Business Logic Layer (BLL):
Represented as a Class Library (.dll).
Contains business objects (e.g., clsPerson, clsUser, clsLicense).
Handles data validation, business rules, and mapping data between the PL and DAL.
Data Access Layer (DAL):
Represented as a Class Library (.dll).
Contains static methods for CRUD operations.
Directly interacts with the SQL Server database using ADO.NET.
# 🚀 Key Features
1. People & User Management
Person Module: Centralized storage for personal information (National No, Name, DOB, Address, Image).
User Module: Role-based access control (RBAC). Management of system users (Admin/Operator) with secure password hashing.
2. Application Management
New Driving Licenses: Workflow for local and international applications.
Application Types: Dynamic management of application fees (Renewals, Replacements, Damaged).
Status Tracking: New, Completed, and Cancelled statuses.
3. Testing System
Multi-Stage Tests: Vision Test, Written (Theory) Test, and Street (Practical) Test.
Test Appointments: Scheduling system with "Pass/Fail" logic that prevents advancing without passing previous stages.
4. License Management
Local Licenses: Issue, Renew, and Replace (Lost/Damaged).
International Licenses: Issuance based on a valid local license.
Detain/Release: Ability to detain licenses with associated fines and release them upon payment.
5. Reporting & Drivers
Driver History: View all licenses (Local/International) associated with a specific person.
System Logs: Management of login activities and transaction history.
# 🗄 Database Schema
The project utilizes a relational database with the following core entities:
People: Stores personal details.
Users: System account credentials linked to People.
Applications: Tracks all service requests.
Licenses: Details of issued licenses.
Drivers: Links people to their active driving record.
TestAppointments & Tests: Records of examination attempts.
