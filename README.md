# .NET CLI application exploring openEHR

Explored how to use DIPS openEHR library to make a simple dotnet cli to generate compositions.

**NOTE:** The code is ONLY written to learn .NET and has noe meaningful use in eHealth!

## Purpose

The purpose of the repo is to explore how to create openEHR COMPOSITION using the .NET library from DIPS AS. The library is developed, maintained and only used within DIPS applications. The code is still shared to get an idea on how to use the library.

The code use .NET attributes to define the AQL paths for data. The Composition builder use an OPT and a dictionary of data to create the composition.

## About the data

The data in weight.config.json.TEMPLATE is the growth chart data for <https://github.com/bjornna> . The

## Run

```C#
dotnet  run -- -i .\weight.config.json -v weight
```
