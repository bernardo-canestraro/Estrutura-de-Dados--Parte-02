📌 Overview
A practical implementation of data structures to simulate:

Patient triage process (vital signs collection)

Priority classification (red/yellow/green)

Priority-based treatment queue

Visit history (stack implementation)

✨ Key Features
✅ Triage Queue (Standard Queue)
✅ Automatic Priority Classification:

🔴 Red: BP > 18, Temp > 39°C, or SpO2 < 90%

🟡 Yellow: Moderate symptoms

🟢 Green: Non-urgent cases
✅ Priority Queue for clinical attention
✅ Visit History Stack
✅ GUI (Windows Forms + Guna UI) with:

Patient intake form

Real-time queue visualization

Treatment dashboard

💻 Tech Stack
Language: C#

UI: Windows Forms + Guna UI 2

Data Structures:

csharp
Queue<Patient> triageQueue = new Queue<Patient>();
PriorityQueue<Patient> treatmentQueue = new PriorityQueue<Patient>();
Stack<Patient> visitHistory = new Stack<Patient>();


🚀 Installation
Clone repository:

bash
git clone https://github.com/bernardo-canestraro/Estrutura-de-Dados--Parte-02.git
Open in Visual Studio 2022+

Restore NuGet packages:

bash
dotnet restore
Run MainForm.cs
