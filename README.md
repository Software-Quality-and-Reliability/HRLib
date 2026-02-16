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
  Software Life Cycle Models and Methodologies 
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

# Software Life Cycle Models and Methodologies

This document provides a theoretical overview of various Software Development Life Cycle (SDLC) models and methodologies, ranging from traditional sequential models to modern agile and collaborative approaches. It was prepared by students at the University of West Attica, Department of Informatics and Computer Engineering.

---

## Table of Contents

| Section | Folder/File | Description |
|------:|-------------|-------------|
| 1 | `docs/` | Documentation on software life cycle models and methodologies |
| 1.1 | `docs/Software-Life-Cycle-Models-and-Methodologies.pdf` | Documentation (English) |
| 1.2 | `docs/Μοντέλα-και-Μεθοδολογίες-Κύκλου-Ζωής-Λογισμικού.pdf` | Documentation (Greek) |
| 2 | `models/` | Software development models illustrations |
| 2.1 | `models/EN/` | Model diagrams (English) |
| 2.1.1 | `models/EN/agile.png` | Agile model diagram |
| 2.1.2 | `models/EN/DevOps.png` | DevOps model diagram |
| 2.1.3 | `models/EN/Extreme-programming.png` | Extreme Programming model diagram |
| 2.1.4 | `models/EN/functional.png` | Functional model diagram |
| 2.1.5 | `models/EN/Prototype.png` | Prototype model diagram |
| 2.1.6 | `models/EN/scrum.png` | Scrum model diagram |
| 2.1.7 | `models/EN/Spiral.png` | Spiral model diagram |
| 2.1.8 | `models/EN/test-driven.png` | Test-Driven Development diagram |
| 2.1.9 | `models/EN/unified_process.png` | Unified Process diagram |
| 2.1.10 | `models/EN/V-Model.png` | V-Model diagram |
| 2.1.11 | `models/EN/waterfall.png` | Waterfall model diagram |
| 2.2 | `models/GR/` | Model diagrams (Greek) |
| 2.2.1 | `models/GR/agile.png` | Agile model diagram (Greek) |
| 2.2.2 | `models/GR/DevOps.jpg` | DevOps model diagram (Greek) |
| 2.2.3 | `models/GR/Extreme.png` | Extreme Programming diagram (Greek) |
| 2.2.4 | `models/GR/Functional.png` | Functional model diagram (Greek) |
| 2.2.5 | `models/GR/model V.jpg` | V-Model diagram (Greek) |
| 2.2.6 | `models/GR/Prototype.png` | Prototype model diagram (Greek) |
| 2.2.7 | `models/GR/Scrum.png` | Scrum model diagram (Greek) |
| 2.2.8 | `models/GR/Spiral-Model.png` | Spiral model diagram (Greek) |
| 2.2.9 | `models/GR/Test-driven.png` | Test-Driven Development diagram (Greek) |
| 2.2.10 | `models/GR/Unified-process.jpg` | Unified Process diagram (Greek) |
| 2.3 | `models/Intro3.jpg` | Introductory slide/image |
| 2.4 | `models/questions.jpg` | Questions / summary slide |
| 3 | `presentation/` | Course presentation slides |
| 3.1 | `presentation/#GR_Software-Methodologies_Present.pptx` | Presentation slides (Greek version) |
| 3.2 | `presentation/Μοντέλα-και-Μεθοδολογίες-Κύκλου-Ζωής-Λογισμικού.pptx` | Presentation slides (Greek) |
| 4 | `README.md` | Repository overview and usage instructions |

---

## General Introduction

The **Software Life Cycle (SDLC)** is a structured framework guiding a project from inception to completion, defining stages such as requirements analysis, design, development, delivery, and maintenance.

- **SDLC Model:** Defines the stages of a software project.
- **Methodology:** A set of practices, techniques, and procedures used to organize and control development activities within those stages.
- **Goal:** To provide structured guidelines that improve efficiency and help achieve project objectives.

---

## 1. Basic Software Development Models

### 1.1 The Waterfall Model

The Waterfall model is a linear and sequential development approach where each phase must be completed before moving to the next.

**Typical Phases**
- Requirements Analysis
- Architectural Design
- Detailed Design
- Coding and Testing
- System Testing
- Maintenance

**Advantages**
- Simple and easy to understand
- Well-structured and easy to manage
- Suitable for projects with stable and clearly defined requirements

**Disadvantages**
- Very rigid and inflexible
- Errors are often discovered late in development
- Returning to previous phases is difficult and costly

---

### 1.2 The V-Model

The V-Model extends the waterfall approach by associating each development phase with a corresponding testing phase.

**Structure**

**Left Side (Development Phases)**
- Requirements analysis
- System design
- Architectural design
- Detailed design

**Right Side (Testing Phases)**
- Unit testing
- Integration testing
- System testing
- Acceptance testing

**Key Focus**
- Verification and validation at each stage
- Frequently used in safety-critical or high-reliability systems

---

### 1.3 Other Basic Models

The document also introduces additional development models:

- **Prototyping Model:** Early software versions are built to clarify requirements and improve communication with stakeholders.
- **Functional Augmentation Model:** Features are added incrementally over time.
- **Spiral Model:** Combines iterative development with risk analysis and systematic planning.

---

## 2. Modern Software Development Methodologies

Modern methodologies focus on flexibility, collaboration, and rapid delivery.

Key approaches include:

- **Unified Process (UP):** Iterative and incremental development framework.
- **Agile Development:** Emphasizes flexibility, customer collaboration, and continuous improvement.
- **DevOps:** Integrates development and operations to enable continuous integration and delivery.
- **Scrum & Extreme Programming (XP):** Agile frameworks emphasizing teamwork, feedback, and iterative progress.
- **Test-Driven Development (TDD):** Tests are written before implementation to guide development.

---

## 3. Choosing a Methodology

The final section of the report discusses how to select an appropriate development methodology based on:

- Project size and complexity
- Requirement stability
- Risk levels
- Team expertise
- Organizational environment

Selecting the correct methodology ensures better resource utilization, smoother development, and higher-quality results.

---

## Conclusion

Understanding both classical and modern SDLC models helps organizations choose suitable development approaches. Proper selection and application of methodologies significantly improve project success and software quality.