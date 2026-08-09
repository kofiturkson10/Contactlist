# 📒 Address Book – Inlämningsuppgift 2, Grupp 4

A simple **C# console application** for managing contacts in an address book.

The application allows the user to **add, update, delete, search for, and display contacts**.  
Contact data is stored locally in a text file so the information remains available between program runs.

---

## ✨ Features

The main menu provides the following options:

### ➕ Add contact
Add a new contact with:
- 👤 Name
- 🏠 Street address
- 📮 Postal code
- 🌍 City
- 📞 Phone number
- ✉️ Email

### ✏️ Update contact
- Select a contact using their email address.
- Update one or more fields.
- Press **Enter** to keep the current value.

### 🗑️ Delete contact
- Search for a contact by name.
- Remove matching contacts from the address book.

### 🔎 Search contacts
Search contacts by:
- 👤 Name
- 🌍 City

### 📋 View all contacts
Display all contacts currently stored in the address book.

### 🚪 Exit
Close the application.

---

## 👤 Contact information

Each contact contains the following information:

| Field | Description |
|---|---|
| 👤 Name | Contact's full name |
| 🏠 Street Address | Contact's address |
| 📮 Postal Code | Postal code |
| 🌍 City | City |
| 📞 Phone Number | Phone number |
| ✉️ Email | Email address |

---

## 📁 Project structure

```text
📦 Project
├── 📄 AddressBook.cs
├── 📄 Contact.cs
├── 📄 FileHandler.cs
├── 📄 Program.cs
├── 🗃️ ContactList.txt
├── ⚙️ inlämingsuppgift 2 - grupp 4.csproj
└── 🧩 inlämingsuppgift 2 - grupp 4.sln
```

### 📄 `Program.cs`
Contains the application's main menu and handles the user's menu selections.

### 📄 `AddressBook.cs`
Contains the main address-book functionality:

- `AddContact()`
- `UpdateContact()`
- `DeleteContact()`
- `SearchContact()`
- `ViewContactList()`

### 📄 `Contact.cs`
Represents a contact and stores the contact's information.

### 💾 `FileHandler.cs`
Handles reading and writing contacts to `ContactList.txt`.

### 🗃️ `ContactList.txt`
Stores contacts as comma-separated text, with one contact per line.

---

## 🛠️ Technologies

- 💻 C#
- ⚙️ .NET
- 🖥️ Console application
- 💾 File handling
- 📚 `List<Contact>`
- 🔎 LINQ

---

## ✅ Requirements

To run the project you need:

- 🟣 Visual Studio 2022 or another editor with C# support
- ⚙️ The .NET SDK required by the project

---

## ▶️ How to run

### 🟣 Visual Studio

1. Clone or download the repository.
2. Open:

```text
inlämingsuppgift 2 - grupp 4.sln
```

3. Build the solution.
4. Run the project.

### ⌨️ .NET CLI

Open a terminal in the project folder and run:

```bash
dotnet restore
dotnet build
dotnet run
```

---

## 💾 Data storage

Contacts are stored in:

```text
ContactList.txt
```

The application reads the file when contacts need to be:

- 👀 Displayed
- 🔎 Searched
- ✏️ Updated
- 🗑️ Deleted

When a new contact is added, it is appended to the file.

When a contact is updated or deleted, the contact list is saved again with the latest information.

---

## 🖥️ Example menu

```text
=== Adressboken ===

--- MENY ---

(1) Lägg till kontakt
(2) Uppdatera kontakt
(3) Radera kontakt
(4) Sök kontakt
(5) Visa kontaktlistan
(6) Avsluta adressboken
```

---

## 🎯 Purpose

This project was created as **Inlämningsuppgift 2 – Grupp 4**.

The project demonstrates basic concepts in C#, including:

- 🧱 Object-oriented programming
- ⌨️ Console input and output
- 📚 Lists and collections
- 🔎 Searching and LINQ
- 💾 Reading and writing files
- 🧩 Separation of responsibilities between classes

---

## 👥 Group

**Grupp 4**
