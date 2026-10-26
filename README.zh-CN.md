# SWE30009 作业 2

[English](README.md)

这是一个用于软件测试作业的 C# 控制台程序。程序计算甜品订单金额（马来西亚令吉 RM），加上 6% 的销售与服务税（SST），并通过三个错误版本（mutants）演示蜕变测试。

## 环境要求

- Git
- .NET 10 SDK（项目目标框架为 `net10.0`）

## 克隆并运行

```bash
git clone https://github.com/print1Username/SWE30009-Assignment-2.git
cd SWE30009-Assignment-2
dotnet run
```

程序会输出原始计算版本以及 M1、M2、M3 三个错误版本的测试结果。

## 代码结构

- `Program.cs`：包含金额计算、结果验证和测试运行逻辑。
- `SWE30009-Assignment-2.csproj`：定义 .NET 控制台项目及其目标框架。

正确版本会累加商品价格并加上 6% SST。程序还包含两个验证方法和三个错误版本：M1 少算 RM 10，M2 使用 1.60 的税率乘数，M3 将折扣比例设为 60%（正确比例为 50%）。
