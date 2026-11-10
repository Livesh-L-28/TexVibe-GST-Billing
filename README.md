# TexVibe GST Billing & Invoicing System

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0.0-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/Platform-Windows%2010%20%7C%2011%20(x64)-0078D6?style=flat&logo=windows&logoColor=white)](https://microsoft.com/windows)
[![WPF](https://img.shields.io/badge/UI-WPF%20%7C%20XAML-blue?style=flat)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)
[![Database](https://img.shields.io/badge/Database-SQLite%20(EF%20Core)-003B57?style=flat&logo=sqlite&logoColor=white)](https://www.sqlite.org/)
[![Invoicing](https://img.shields.io/badge/Engine-QuestPDF-success?style=flat)](https://www.questpdf.com/)
[![Tests](https://img.shields.io/badge/Unit%20Tests-100%25%20Passing-brightgreen?style=flat)](https://xunit.net/)

A modern, high-performance, and fully offline **GST Billing & ERP Software** designed specifically for cloth manufacturers, apparel retailers, and wholesale trading businesses. Built using **C# 12, .NET 8, WPF (MVVM Architecture), Entity Framework Core (SQLite)**, and **QuestPDF** for high-resolution vector invoice rendering.

---

## 📥 Downloadable Installer

| Package | Format | Architecture | Download Link |
| :--- | :--- | :--- | :--- |
| **Offline Setup Installer** | Executable (`.exe`) | Windows x64 | [**Download Setup Installer (v1.0.0)**](InstallerOutput/TexVibe_GST_Billing_Setup.exe) |

> **Note**: The setup installer is fully self-contained (~59 MB) and installs the required application assets, database initializers, and desktop shortcuts with zero internet connectivity required.

---

## 🔑 Login Credentials & Terminals

The software features a **Dual-Terminal Role Selector** on launch, allowing operators to immediately log into either the primary administrator terminal or the cashier counter terminal:

| Terminal / Role | Company Profile | Username | Password | Access Level |
| :--- | :--- | :--- | :--- | :--- |
| 👑 **Admin Terminal** | **TEXVIBE TEXTILES** *(ID: 1)* | `admin` | `admin123` | **Full Access**: Billing, Master Catalogs, GST Reports, Company Settings, User Management, Database Backup & Restore |
| 🛒 **Cashier Terminal** | **VIBE WEAVES** *(ID: 2)* | `cashier` | `admin123` | **Standard Billing**: Fast counter billing, customer lookup, barcode search, PDF generation |
| 👔 **Store Manager** | All Companies | `manager` | `manager123` | Operational access to billing, inventory, customers, and standard reports |
| 👤 **Sales Assistant** | All Companies | `staff` | `staff123` | Product inquiry and customer directory lookup |

---

## ✨ Key Features

### 1. 🏢 Multi-Company & Terminal Architecture
- Seamless switching between multiple business entities (**TexVibe Textiles** and **Vibe Weaves**) with distinct company headers, GSTINs, bank accounts, and invoice prefix series (`TXV` and `VBW`).
- Isolated user subfolders for generated PDF invoices (`Documents\BillingSoftware\Invoices\{role}`).

### 2. 🧾 GST Compliance & Smart Tax Engine
- **Intra-State vs. Inter-State Auto Detection**: Automatically compares supplier and customer GSTIN state codes (e.g. `33` for Tamil Nadu, `27` for Maharashtra).
- Applies **CGST + SGST** (50/50 split) for Intra-State or **IGST** for Inter-State sales.
- Configurable GST slabs (0%, 5%, 12%, 18%, 28%) with support for textile HSN codes (`6304`, `5208`, etc.).
- Automated Round-Off algorithm conforming to Indian accounting standards.

### 3. 📄 High-Resolution QuestPDF Invoicing
- Pixel-perfect, professional vector Tax Invoice generation.
- Complete breakdown: Original for Recipient, Duplicate for Transporter, Triplicate for Supplier.
- Dynamic company profile, bank details (NEFT/RTGS IFSC), and legal declarations.
- Direct print preview and automatic local PDF archive generation.

### 4. 📦 Inventory & Stock Control
- Real-time stock decrement upon invoice finalization.
- Low-stock warning indicators and batch inventory updates.
- Support for multiple units of measurement (Meters, Pieces, Rolls, Kilograms).

### 5. 👥 Customer & Ledger Management
- Comprehensive customer profiles with GSTIN, PAN, and address management.
- Credit limit days and outstanding balance tracking.
- Transaction history and customer sales summaries.

### 6. 🔒 Offline Security & Data Protection
- Local **SQLite** database stored securely at `%LOCALAPPDATA%\BillingSoftware\billing.db`.
- Salted and hashed user password storage (`PBKDF2` / `HMACSHA256`).
- Built-in one-click database backup and restore manager.
- Audit trail logging operator actions, bill edits, and login events.

---

## 🚀 Quick Start (Running from Source)

### Prerequisites
- Windows 10 (Build 19041+) or Windows 11 (64-bit).
- [.NET 8.0 Desktop SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (includes Windows Desktop Runtime).
- Visual Studio 2022 (v17.8+) with *.NET desktop development* workload **OR** VS Code with C# Dev Kit.

### Clone & Build
```bash
# 1. Clone the repository
git clone https://github.com/Livesh-L-28/TexVibe-GST-Billing.git
cd TexVibe-GST-Billing

# 2. Restore NuGet dependencies
dotnet restore

# 3. Build solution
dotnet build -c Release

# 4. Run automated test suite
dotnet test

# 5. Launch Application
dotnet run --project BillingSoftware.UI/BillingSoftware.UI.csproj -c Debug
```

---

## 🛠️ Windows 11 Smart App Control Note

If you build or run the binaries on Windows 11 with **Smart App Control (SAC)** enabled in strict enforcement mode:
- Because newly compiled local binaries do not yet possess Microsoft cloud telemetry reputation, SAC (`CI.dll`) may temporarily flag unsigned executables.
- **Recommended workaround**: Run the project directly through Visual Studio / `dotnet run` (which runs under the trusted Microsoft-signed SDK runtime host), or install via the signed setup installer.

---

## 📂 Architecture & Solution Structure

```
TexVibe-GST-Billing/
├── BillingSoftware.sln                         # Visual Studio Solution File
├── installer.iss                               # Inno Setup offline compiler script
├── InstallerOutput/
│   └── TexVibe_GST_Billing_Setup.exe           # Standalone Offline Setup Package
│
├── BillingSoftware.Core/                       # Domain Entities & Contracts
│   ├── Entities/                               # Company, Invoice, Product, User, Customer
│   └── Interfaces/                             # Repositories & Context contracts
│
├── BillingSoftware.Database/                   # Data Access & Entity Framework Core
│   ├── BillingDbContext.cs                     # EF Core SQLite DbContext
│   ├── DbInitializer.cs                        # Automated Seeding & Sanitization
│   └── Migrations/                             # Schema evolution scripts
│
├── BillingSoftware.Application/                # Application Business Services
│   └── Services/                               # SessionContext, AuthService, BillingService
│
├── BillingSoftware.Infrastructure/             # Repository Implementations & Audit
│   └── Repositories/                           # Concrete CRUD Data Access
│
├── BillingSoftware.Printing/                   # QuestPDF Document Engine
│   └── InvoicePdfGenerator.cs                  # Vector Tax Invoice Layout & Rendering
│
├── BillingSoftware.Reporting/                  # Analytics & Reporting
│   └── Services/                               # GST GSTR-1 & Sales Reports
│
├── BillingSoftware.Backup/                     # Database Engine
│   └── Services/                               # SQLite Online Backup & Restore
│
├── BillingSoftware.UI/                         # Presentation Layer (WPF XAML + MVVM)
│   ├── ViewModels/                             # CommunityToolkit MVVM ViewModels
│   ├── Views/                                  # BillingView, Customers, Products, Settings
│   ├── LoginSelectionWindow.xaml               # Multi-Terminal Startup Selection
│   └── Themes/                                 # Modern Dark/Light Design Themes
│
└── BillingSoftware.Tests/                      # Automated Unit Test Suite
    └── UnitTest1.cs                            # PDF Generation, Tax & Concurrency Tests
```

---

## 🛡️ License

This project is licensed under the **MIT License** — feel free to use, modify, and distribute for commercial or personal applications.
