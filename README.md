# ðŸ“ˆ Progressive Compounding Calculator

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0_Windows-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Windows Forms](https://img.shields.io/badge/UI-Windows_Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

> A fast, native **C# .NET 8.0 Windows Forms** desktop application tailored for traders, investors, and quantitative analysts to model progressive compounding, geometric growth trajectories, and dynamic position risk scaling with detailed per-period breakdowns.

---

## âš¡ Key Features

- **ðŸ’° Exponential Compounding Engine**: Calculate cumulative balance growth using custom multipliers (e.g., 1.05 for \%$ per period) across $ compounding iterations.
- **ðŸ“‹ Step-by-Step Breakdown**: Generates a detailed audit log displaying each iteration's incremental gain and the resulting balance trajectory.
- **ðŸ”¢ Built-in Touch & Mouse Keypad**: Features a responsive virtual numpad for rapid touch-screen and mouse data entry alongside standard keyboard input.
- **âš¡ Native Performance**: Built natively targeting .NET 8.0 Windows for instant startup, zero runtime bloat, and minimal memory usage.
- **ðŸŽ¨ Clean Ergonomic Interface**: Modern clean layout with intuitive color coding for inputs, outputs, and financial gains.

---

## ðŸ§® Mathematical Model

The calculator computes compounding trajectories according to the iterative formula:

A_n = A_0 \times M^n

Where:
- $ = Initial starting balance
- $ = Growth multiplier per period (e.g., .02$ for $+2\%$)
- $ = Number of compounding intervals / execution iterations
- $ = Compounded balance after $ periods

The application generates the discrete breakdown at each period:
A_k = A_{k-1} \times M \quad \text{for } k = 1, 2, \dots, n

---

## ðŸ—ï¸ Project Structure

``
ProgressiveCompoundingCalculator/
â”œâ”€â”€ ProgressiveCompoundingCalculator.sln    # Visual Studio solution file
â””â”€â”€ ProgressiveCompoundingCalculator/       # Project source directory
    â”œâ”€â”€ Form1.cs                            # Main application form & logic
    â”œâ”€â”€ Form1.Designer.cs                   # Windows Forms designer layout
    â”œâ”€â”€ Form1.resx                          # Form resource definitions
    â”œâ”€â”€ Program.cs                          # Application bootstrap entry
    â””â”€â”€ ProgressiveCompoundingCalculator.csproj # .NET 8.0 project file
``

---

## ðŸš€ Getting Started

### Prerequisites

- Windows 10 / 11
- [.NET 8.0 Desktop Runtime / SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with *.NET desktop development* workload) or [VS Code](https://code.visualstudio.com/) with C# Dev Kit.

### Building & Running

1. **Clone the repository:**
   `ash
   git clone https://github.com/c-odenat/progressive-compounding-calculator.git
   cd progressive-compounding-calculator
   `

2. **Run using .NET CLI:**
   `ash
   dotnet run --project ProgressiveCompoundingCalculator
   `

3. **Or open with Visual Studio:**
   - Double-click ProgressiveCompoundingCalculator.sln
   - Press **F5** to build and run.

4. **Publish Standalone Executable:**
   `ash
   dotnet publish ProgressiveCompoundingCalculator -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
   `

---

## ðŸ‘¤ Author

**Nathaniel Darko**
- GitHub: [@c-odenat](https://github.com/c-odenat)
- Portfolio: [Nathaniel Darko Portfolio](https://c-odenat.github.io)

---

## ðŸ“„ License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
