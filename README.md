<!-- omit in toc -->
# 🚗 GoogleDistanceMatrix

[![NuGet Version](https://img.shields.io/nuget/v/MichelMichels.Google.DistanceMatrix)](https://www.nuget.org/packages/MichelMichels.Google.DistanceMatrix)
[![.NET](https://github.com/MichelMichels/GoogleDistanceMatrix/actions/workflows/dotnet.yml/badge.svg)](https://github.com/MichelMichels/GoogleDistanceMatrix/actions/workflows/dotnet.yml)

This projects is a C# wrapper library to [retrieve distance in meter and estimated time between 2 places through Google Distance matrix]("https://developers.google.com/maps/documentation/distance-matrix/overview").

<details>
<summary>Table of Contents</summary>

- [Prerequisites](#prerequisites)
- [Building](#building)
- [Installation](#installation)
- [Getting started](#getting-started)
  - [Usage](#usage)
- [Credits](#credits)

</details>

---

## Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Building

Use [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) to build the project. 

## Installation

Get the NuGet packages from [nuget.org](https://www.nuget.org/) or search for `MichelMichels.Google.DistanceMatrix` in the GUI package manager in Visual Studio.

You can also use the cli of the package manager with following command:

```cli
Install-Package MichelMichels.Google.DistanceMatrix
```
<br />
<hr>

## Getting started

This repository contains 2 projects:
- `MichelMichels.Google.DistanceMatrix` - Core library
- `MichelMichels.Google.DistanceMatrixTests` - Testing library

### Usage

Create an instance of `DistanceMatrixClient`:

```csharp
DistanceMatrixClient client = new("{YOUR-API-KEY}");
```

Following methods are available and are self-explanatory:

```csharp
Task<int> GetMetersBetweenPlaces(string origin, string destination);
Task<int> GetSecondsBetweenPlaces(string origin, string destination);

Task<DistanceMatrixResponse> GetDistanceMatrixReponse(DistanceMatrixRequest request);
```

## Credits

Written by [Michel Michels](https://github.com/MichelMichels).
