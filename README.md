# CyberSecurity Awareness Bot

 Student Information
Name: ____________________
Subject: __________________
Project: Cybersecurity Awareness Chatbot
Language: C# (.NET Console Application)
 1. Project Overview
The Cybersecurity Awareness Chatbot is a console-based application developed in C#. The system is designed to educate users about cybersecurity threats while also providing interactive features such as task management, a quiz game, natural language processing simulation, and activity logging.
The chatbot helps users learn how to stay safe online while also managing cybersecurity-related tasks such as enabling two-factor authentication or reviewing privacy settings.
 2. Project Objectives
The main objectives of this project are:
To educate users about cybersecurity threats such as phishing, ransomware, and weak passwords
To simulate a smart chatbot using natural language processing (NLP)
To allow users to manage cybersecurity tasks
To implement a quiz system for knowledge testing
To log all user activity for tracking and debugging purposes
To store tasks using a database (SQLite)
 3. System Features
🔹 3.1 Task Management System
Users can:
Add cybersecurity-related tasks
Provide a title and description
Set optional reminders
View all tasks
Delete tasks
Mark tasks as completed
All tasks are stored in a SQLite database for permanent storage.
🔹 3.2 Quiz System
The chatbot includes a multiple-choice quiz that tests users on cybersecurity topics such as:
Password security
Phishing awareness
Safe browsing
Privacy protection
The system tracks user scores and provides feedback.
🔹 3.3 Natural Language Processing (NLP) Simulation
The chatbot simulates NLP by detecting keywords and intent from user input.
It responds to topics such as:
Password safety
Phishing attacks
Privacy protection
Ransomware awareness
Safe browsing
This improves user interaction and makes the chatbot feel more intelligent.
🔹 3.4 Activity Logging System
The system records all user actions, including:
Commands entered
Tasks created or deleted
Quiz activity
System responses
This helps track system usage and debugging.
🔹 3.5 Database Integration (SQLite)
The chatbot uses SQLite to store tasks permanently.
Features include:
Create (Add tasks)
Read (View tasks)
Update (Mark as completed)
Delete (Remove tasks)
This ensures data persistence even after the application is closed.
 4. System Architecture
The system follows an object-oriented structure:
Chatbot.cs → Main logic and user interaction
TaskRepository.cs → Database operations (CRUD)
Quiz.cs → Quiz logic and scoring
ActivityLogger.cs → Logs system activity
NLPProcessor.cs → Simulates natural language understanding
 5. Program Flow
User enters input
Chatbot processes input
NLP detects intent (if applicable)
System checks task/quiz/reminder states
Response is generated
Actions are logged
Tasks are stored in database (if applicable)
 6. Database Design
Table: Tasks
Field
Type
Description
TaskId
Integer
Unique ID
Title
Text
Task title
Description
Text
Task details
ReminderDate
Text
Optional reminder
IsCompleted
Integer
Completion status
 7. Testing
The system was tested using the following inputs:
add task
show tasks
delete task 1
complete task 1
start quiz
phishing questions
password safety queries
All features responded correctly and stored data properly.
 8. Technologies Used
C# (.NET Console Application)
SQLite Database
Object-Oriented Programming (OOP)
Basic NLP simulation logic
 9. Conclusion
The Cybersecurity Awareness Chatbot successfully demonstrates how programming can be used to create an interactive educational tool.
It integrates multiple computing concepts including:
Databases
Artificial intelligence simulation (NLP)
User interaction systems
Data logging
Game-based learning (quiz system)
This project provides a strong foundation for understanding both cybersecurity and software development.
 10. Acknowledgements
This project was developed as part of a Portfolio of Evidence (POE) assignment.