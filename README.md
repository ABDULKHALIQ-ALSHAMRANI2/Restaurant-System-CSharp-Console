# Restaurant System (Console Application) 🍔☕

A structured and clean C# Console Application designed to simulate a real-world restaurant ordering and billing system. This project was developed as a practical application to master core programming fundamentals, logical code structuring, and efficient data handling.

---

## 📌 Project Overview
This application provides a text-based user interface (CLI) that allows users to navigate through different food menus (such as Breakfast), select items, confirm orders dynamically, and generate a formalized, tax-compliant receipt. 

The primary focus of this project is **not** to build a commercial product, but rather to showcase fundamental software engineering concepts as a student in Web & Mobile Development.

---

## 🚀 Core Concepts Applied
To ensure high code quality, several essential programming practices were implemented:

* **Separation of Concerns (Clean Architecture):** The code is modularly broken down into isolated static methods (`ManageRestaurantSystem`, `ShowBreakfastMenu`, `ConfirmOrder`, `PrintFinalInvoice`) rather than dumping all logic inside the `Main` method.
* **Code Reusability (DRY Principle):** Developed a unified `ConfirmOrder` function that dynamically accepts any meal name and price, eliminating redundant code blocks across different sub-menus.
* **Efficient Memory Management:** Practiced modifying data types directly via memory referencing by utilizing the `ref` keyword for updating the running total price.
* **Dynamic Data Structures:** Utilized `List<string>` to dynamically store, append, and keep track of ordered items throughout the user session.
* **Real-world Business Logic:** Integrated `DateTime.Now` to fetch accurate live timestamps and applied specific string formatting (`:F2`) to properly display monetary figures alongside a simulated 15% VAT calculation.

---

## 🛠️ Future Upgrades (Roadmap)
As part of my continuous learning journey, I plan to improve this repository with the following enhancements:
1. **Object-Oriented Programming (OOP) Refactoring:** Migrate from procedural static methods to class-based models (e.g., creating independent `Meal`, `Order`, and `Invoice` classes).
2. **Feature Completion:** Develop and integrate the remaining menu systems for *Fast Food* and *Drinks* which are currently under development.
3. **Data Persistence:** Implement file handling or a local database connection to log transaction histories permanently.

---

## 👨‍💻 Author
* **Name:** ABDULKHALIQ ALSHAMRANI
* **GitHub:** [ABDULKHALIQ-ALSHAMRANI2](https://github.com/ABDULKHALIQ-ALSHAMRANI2)
* **Current Focus:** Completing my Web & Mobile Development Diploma
