# 💰 ExpenseTrackerGUI

![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![WinForms](https://img.shields.io/badge/WinForms-512BD4?logo=windows&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?logo=sqlite&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=white)

A simple **Windows Forms Expense Tracker** built with **C#** and **SQLite**.  
Track daily expenses, categorize them, filter by month/year, and view running totals.  

> ⚠️ Learning project — not a production-ready financial system.

---

## 🚀 Features

- 🗓️ Add new expenses with **date, category, description, and amount**  
- 🗑️ Delete selected expenses  
- 🔎 Filter expenses by **month/year**  
- 📊 View total spending for the current filter  
- 💾 Data stored in a local **SQLite** database (`expenses.db`)  

---

## 📚 Learning Goals

This project helped me strengthen my **C# WinForms** skills by learning how to:

- ✅ Work with **partial classes** (`MainForm.cs` + `MainForm.Designer.cs`)  
- ✅ Connect a WinForms UI to a **SQLite database** with `Microsoft.Data.Sqlite`  
- ✅ Perform **CRUD operations** (insert, read, delete)  
- ✅ Use `DataGridView` for displaying tabular data  
- ✅ Add **filtering logic** and update the UI dynamically  
- ✅ Show **totals and formatted currency values** in real time  

---

## 🖼 Screenshots

### 📊 Main Window with Total
<img src="./Expense .png" alt="Main Window" width="500"/>

---

## ⚡ Getting Started

### Prerequisites
- Visual Studio 2019/2022  
- .NET Framework **4.7.2**  
- NuGet Packages:  
  - `Microsoft.Data.Sqlite`  
  - `SQLitePCLRaw.bundle_e_sqlite3`  

### 📂 Project Structure

ExpenseTrackerGUI/
├── Program.cs

├── MainForm.cs

├── MainForm.Designer.cs

├── expenses.db          # created automatically

├── screenshots/         # store screenshots here

└── README.md

