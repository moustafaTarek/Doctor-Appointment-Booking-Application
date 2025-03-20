# Doctor Appointment Booking Application
📌 Overview

The Doctor Appointment Booking Application is a modular monolith system designed to facilitate doctor appointment scheduling, availability management, and appointment confirmation. The application follows modular monolith structured architecture to ensure scalability, maintainability, and separation of concerns.

-------------

📁 Project Structure\
Doctor-Appointment-Booking-Application/\
├── Appointment.Booking/\
│   ├── Application/\
│   ├── Domain/\
│   ├── Infrastructure/\
├── Appointment.Confirmation/\
│   ├── Core/\
├── Doctor.Appointment.Management/\
│   ├── Core/\
│   ├── Shell/\
├── Doctor.Appointment.System/\
│   ├── API/\
├── Doctor.Availability/\
│   ├── Core/\
│   ├── DataAccess/\
├── Shared/\
│   ├── Enums/\
│   ├── Integration.DTOs/\
│   ├── IntegrationEvents/\
│   ├── IntegrationInterfaces/\
├── .gitignore\
├── Doctor.Appointment.sln\
└── README.md

-------------

🏗 Module Descriptions

📌 Appointment Booking Module  [Clean architecture pattern]

* Appointment.Booking.Application/ - Handles application-level services and business logic for appointment bookings.

* Appointment.Booking.Domain/ - Defines core domain models related to the booking system.

* Appointment.Booking.Infrastructure/ - Manages data access and containes database entities and infrastructure concerns for appointment bookings.

📌 Appointment Confirmation Module [Layered architecture pattern]

* Appointment.Confirmation.Core/ - Handles functionalities related to confirming appointments.

📌 Doctor Appointment Management Modules [Hexagonal architecture pattern]

* Doctor.Appointment.Management.Core/ - Contains core functionalities for doctor appointment management.

* Doctor.Appointment.Management.Shell/ - Acts as the Infrastructure layer for the appointment management.

📌 System API [Presenation layer for the whole system]

* Doctor.Appointment.System.API/ - Exposes APIs for interacting with the appointment system.

📌 Doctor Availability Module [Layered architecture pattern]

* Doctor.Availability.Core/ - Manages core functionalities related to doctor availability.

* Doctor.Availability.DataAccess/ - Handles data access operations concerning doctor availability.

📌 Shared Components

* Shared/Enums/ - Contains enumerations used across multiple modules.

* Shared/Integration.DTOs/ - Defines Data Transfer Objects for external integrations.

* Shared/IntegrationEvents/ - Manages events for system integrations.

* Shared/IntegrationInterfaces/ - Declares interfaces for standardizing external integrations.

-------------

⚙️ Technologies Used

🟢 .NET Core for API development

🟢 Entity Framework Core for database interactions

🟢 Modular monolith Software Architecture style

🟢 RESTful APIs for communication

-------------
🚀 Getting Started

🔧 Prerequisites

Ensure you have the following installed:

* .NET SDK

* Visual Studio / VS code

* Postgresql database

🛠 Installation

1- Clone the repository:
```
git clone https://github.com/moustafaTarek/Doctor-Appointment-Booking-Application.git
```

2- Navigate to the project directory:

```
cd Doctor-Appointment-Booking-Application/Doctor.Appointment (root path)
```

3- Open the Doctor.Appointment.sln solution file in Visual Studio.

4- Restore dependencies:

```
dotnet restore
```

5- Build the project:
```
dotnet build
```

6- Run the API:
```
dotnet run --project Doctor.Appointment.System.API
```

7- Access the APIs via Postman or a web browser.

---

🤝 Contributing

Contributions are welcome! Please follow these steps:

Fork the repository.

Create a feature branch (git checkout -b feature-name).

Commit your changes (git commit -m 'Add feature').

Push to the branch (git push origin feature-name).

Open a Pull Request.

---

👨‍💻 Developed by Moustafa Tarek