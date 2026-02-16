<p align="center">
  <img src="https://www.especial.gr/wp-content/uploads/2019/03/panepisthmio-dut-attikhs.png" alt="UNIWA" width="150"/>
</p>

<p align="center">
  <strong>UNIVERSITY OF WEST ATTICA</strong><br>
  SCHOOL OF ENGINEERING<br>
  DEPARTMENT OF COMPUTER ENGINEERING AND INFORMATICS
</p>

---

<p align="center">
  <strong>Software Quality and Reliability</strong>
</p>

<h1 align="center">
  Software Development in C# and Reliability using Unit Tests 
</h1>

<p align="center">
  <strong>Vasileios Evangelos Athanasiou</strong><br>
  Student ID: 19390005
</p>

<p align="center">
  <a href="https://github.com/Ath21" target="_blank">GitHub</a> ·
  <a href="https://www.linkedin.com/in/vasilis-athanasiou-7036b53a4/" target="_blank">LinkedIn</a>
</p>

<p align="center">
  <strong>Georgios Theocharis</strong><br>
  Student ID: 19390283
</p>

<p align="center">
  <a href="https://github.com/geotheo01" target="_blank">GitHub</a>
</p>

<p align="center">
  <strong>Omar Alhaz Omar</strong><br>
  Student ID: 19390010
</p>

<p align="center">
  <a href="https://github.com/OmarAlhaz" target="_blank">GitHub</a> ·
  <a href="https://www.linkedin.com/in/omar-alchaz/" target="_blank">LinkedIn</a>
</p>

<p align="center">
  Supervisor: Christos Troussas, Assistant Professor<br>
</p>

<p align="center">
  <a href="https://ice.uniwa.gr/en/emd_person/christos-troussas/" target="_blank">UNIWA Profile</a>  ·
  <a href="https://gr.linkedin.com/in/christos-troussas" target="_blank">LinkedIn</a>
</p>

<p align="center">
  Co-Supervisor: Akrivi Krouska, Assistant Professor<br>
</p>

<p align="center">
  <a href="https://ice.uniwa.gr/en/emd_person/akrivi-krouska-2/" target="_blank">UNIWA Profile</a>  ·
  <a href="https://www.linkedin.com/in/akrivi-krouska-ak/" target="_blank">LinkedIn</a>
</p>

<p align="center">
  Athens, February 2024
</p>

---

# Personnel Management Function Library (DLL)

This project involves the development of a C# class library (**HRLib.dll**) designed for personnel management tasks. It includes functions for data validation, encryption, and employee information processing, all verified through rigorous unit testing to ensure software reliability.

---

## Table of Contents

| Section | Folder/File | Description |
|------:|-------------|-------------|
| 1 | `assign/` | Assignment instructions and lab material |
| 1.1 | `assign/Lab Assignment- Part II.pdf` | Assignment description (English) |
| 1.2 | `assign/Εργασία Εργαστηρίου- Μέρος ΙΙ.pdf` | Assignment description (Greek) |
| 2 | `build/` | Compiled project outputs |
| 2.1 | `build/HRLib.dll` | Compiled HRLib library |
| 3 | `docs/` | Documentation and learning material |
| 3.1 | `docs/Software-Development-in-C#-and-Reliability-using-Unit-Tests.pdf` | Documentation (English) |
| 3.2 | `docs/Ανάπτυξη-Λογισμικού-σε-C#-και-Αξιοπιστία-με-Χρήση-Unit-Tests.pdf` | Documentation (Greek) |
| 4 | `src/` | Source code of the solution |
| 4.1 | `src/HRLib/` | Main HR library project |
| 4.1.1 | `src/HRLib/Properties/` | Assembly metadata configuration |
| 4.1.2 | `src/HRLib/HRLib.csproj` | HRLib project configuration |
| 4.1.3 | `src/HRLib/Personnel.cs` | Core personnel management implementation |
| 4.2 | `src/UnitTestHRLib/` | Unit test project for HRLib |
| 4.2.1 | `src/UnitTestHRLib/packages.config` | NuGet package configuration |
| 4.2.2 | `src/UnitTestHRLib/UnitTestHRLib.csproj` | Unit test project configuration |
| 4.2.3 | `src/UnitTestHRLib/UnitTestPersonnel.cs` | Unit tests for Personnel functionality |
| 4.3 | `src/HRLib_Project.sln` | Visual Studio solution file |
| 5 | `README.md` | Repository overview and usage instructions |

---

## Core Features

### 1. Personnel Data Validation

**ValidName(string Name)**  
Validates that an employee's name:
- Contains exactly two parts (First and Last name)
- Uses Latin characters only
- Follows capitalization rules (first letter uppercase, remaining letters lowercase)

**ValidPassword(string Password)**  
Ensures passwords meet security requirements:
- Length between 12 and 24 characters
- At least one uppercase letter
- At least one lowercase letter
- At least one digit
- At least one special character

**CheckPhone(...)**  
Validates Greek phone numbers:
- Must contain exactly 10 digits
- Distinguishes landline numbers (starting with `2`)
- Distinguishes mobile numbers (starting with `69`)
- Identifies geographic zone or provider when applicable

---

### 2. Security

**EncryptPassword(string Password, ref string EncryptedPW)**  
Implements password encryption using a Caesar Cipher with an ASCII shift of 5, applied only after successful password validation.

---

### 3. Employee Management

**InfoEmployee(...)**  
Calculates:
- Employee age
- Years of service

Business rules enforced:
- Employee age must be between 18 and 70 years.

**LiveInAthens(Employee Empls)**  
Counts employees living in the Athens–Piraeus metropolitan area based on landline prefixes starting with `21`.

---

## Quality Assurance & Testing

Reliability is ensured through structured testing processes.

### Test Case Design
Systematic creation of valid and invalid test data for all functions.

### Unit Testing
Automated tests implemented using the `[TestMethod]` attribute in C# to verify correctness of functionality.

### Audit Reporting
Test results include:
- Error identifiers
- Descriptions of performed audits
- Screenshots and reports from Test Explorer

---

## Technical Implementation

- **Language:** C#
- **Output:** Function Library (DLL)
- **Testing Framework:** MSTest / Visual Studio Test Explorer

---

## Conclusion
The Personnel Management Function Library provides validated, secure, and tested functionality for managing employee data, ensuring reliability and maintainability through comprehensive unit testing.

---

# Installation & Setup Guide  
## HRLib — Personnel Management Function Library (C#)

This guide explains how to install requirements, build the solution, and run the unit tests for the **HRLib Personnel Management Library**.

---

## 1. Prerequisites

To build and run the project, you need:

### Required Software
- **Windows OS** (recommended for Visual Studio compatibility)
- **Visual Studio 2019 or newer**
  - Workload: **.NET desktop development**
- **.NET Framework Developer Pack** (version required by project)
- **Git** (optional, for cloning the repository)

### Optional Tools
- Visual Studio Code (code viewing)
- NuGet Package Manager (included with Visual Studio)

---

## 2. Obtain the Project

### Option A — Clone Repository (Recommended)

Open a terminal or Git Bash and run:

```bash
git clone https://github.com/Software-Quality-and-Reliability/HRLib.git
```

### Option B — Download ZIP
1. Open the repository in a browser.
2. Click Code → Download ZIP.
3. Extract the archive to a folder on your system.

## 3. Open the Solution in Visual Studio
1. Launch Visual Studio.
2. Select Open a project or solution.
3. Navigate to:
```bash
src/HRLib_Project.sln
```
4. Open the solution file.

Visual Studio will automatically load:
- HRLib class library project
- Unit test project

## 4. Restore NuGet Packages
If prompted, restore dependencies automatically.

Or manually:
```bash
Tools → NuGet Package Manager → Restore NuGet Packages
```

## 5. Build the Solution
To compile the library:
```bash
Build → Build Solution
```
or press:
```bash
Ctrl + Shift + B
```
After building, the compiled DLL appears in:
```bash
build/HRLib.dll
```
or inside the project `bin/` folder.

## 6. Running Unit Tests
Unit tests verify correctness and reliability.
### Run Tests in Visual Studio
1. Open Test Explorer:
```bash
Test → Test Explorer
```
2. Click Run All Tests.
All tests in `UnitTestHRLib` should execute automatically.

## 7. Using the HRLib Library in Another Project
To use the compiled library:
1. Copy `HRLib.dll` into another project.
2. Add reference:
```bash
Project → Add Reference → Browse
```
3. Select `HRLib.dll`.

Then include namespace:
```bash
using HRLib;
```

## 8. Expected Build Output
Successful setup provides:
- Compiled `HRLib.dll`
- Passing unit tests
- Test Explorer execution results
- Build output without errors

## 9. Common Issues & Fixes
### NuGet Packages Missing
Run:
```bash
Restore NuGet Packages
```
or rebuild solution.

### Tests Not Appearing
Ensure:
- Test project builds successfully.
- MSTest framework is installed.

### Build Errors
Verify:
- Correct .NET Framework version installed.
- Visual Studio workloads include .NET desktop tools.