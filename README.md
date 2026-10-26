# SWE30009 Assignment 2

[简体中文](README.zh-CN.md)

A small C# console program for a software testing assignment. It calculates dessert orders in Malaysian Ringgit (RM), applies 6% SST, and demonstrates metamorphic testing with three faulty program variants (mutants).

## Requirements

- Git
- .NET 10 SDK (the project targets `net10.0`)

## Clone and run

```bash
git clone https://github.com/print1Username/SWE30009-Assignment-2.git
cd SWE30009-Assignment-2
dotnet run
```

The program prints the test results for the original calculation and mutants M1, M2, and M3.

## Code structure

- `Program.cs` contains the calculation, validation, and test-run logic.
- `SWE30009-Assignment-2.csproj` defines the .NET console project and its target framework.

The reference calculation sums item prices and applies 6% SST. The program also includes two validation methods and three mutants: M1 subtracts RM 10, M2 applies a 60% tax multiplier, and M3 applies a 60% discount instead of 50%.
