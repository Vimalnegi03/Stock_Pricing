# 🦈 Stock_Pricing

![Homepage](/homepage.png)

**FinShark** is a robust and modern financial web application that allows users to track, analyze, and manage stock market investments. Built with ASP.NET Core Web API, it provides secure user authentication, portfolio management, real-time stock data integration, and interactive commenting features.

---

## 🚀 Features

- 🔐 **User Authentication** (Register/Login)
- 📈 **Stock Data Retrieval** (via FMP or similar API)
- 💼 **Portfolio Management**
- 💬 **Comments System** for stock discussion
- 🧰 Clean Architecture with Repositories & DTOs
- 🌐 RESTful API endpoints

---

## 🛠 Tech Stack

| Backend        | Details                      |
|----------------|------------------------------|
| Language       | C# (.NET 7 / ASP.NET Core)   |
| Database       | Entity Framework Core + MySQL |
| Auth           | JWT Bearer Token              |
| Architecture   | Clean Code, Repository Pattern |
| Config         | `appsettings.json` based env |

---

## 📁 Project Structure
```
FinShark-master/
├── backend/
│ ├── Controllers/
│ ├── Dtos/
│ ├── Interfaces/
│ ├── Helpers/
│ ├── Data/
│ ├── Extensions/
│ └── Program.cs
├── teddy_smith.sln
├── homepage.png
```

---

## 🧪 Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/Vimalnegi03/Stock_Pricing
   cd backend
   dotnet restore
   dotnet run
   ```

   🤝 Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Made with ❤️ by Vimal

