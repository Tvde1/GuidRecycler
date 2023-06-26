``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-NTHQMS : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|                 Method | RecyclerCapacity |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |----------------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
|                **NewGuid** |               **10** | **647.9 ns** | **113.68 ns** | **327.99 ns** | **600.0 ns** |  **1.00** |    **0.00** |     **600 B** |        **1.00** |
| ConcurrentGuidRecycler |               10 | 307.1 ns |  49.97 ns | 146.56 ns | 300.0 ns |  0.58 |    0.39 |     600 B |        1.00 |
|       GuidRecyclerSlim |               10 | 224.0 ns |  28.33 ns |  81.75 ns | 200.0 ns |  0.45 |    0.30 |     600 B |        1.00 |
|                        |                  |          |           |           |          |       |         |           |             |
|                **NewGuid** |             **1000** | **708.8 ns** | **120.84 ns** | **338.84 ns** | **800.0 ns** |  **1.00** |    **0.00** |     **600 B** |        **1.00** |
| ConcurrentGuidRecycler |             1000 | 313.7 ns |  51.50 ns | 147.76 ns | 300.0 ns |  0.65 |    0.61 |     600 B |        1.00 |
|       GuidRecyclerSlim |             1000 | 237.4 ns |  33.47 ns |  93.87 ns | 200.0 ns |  0.49 |    0.56 |     600 B |        1.00 |
|                        |                  |          |           |           |          |       |         |           |             |
|                **NewGuid** |           **100000** | **625.8 ns** | **104.44 ns** | **289.41 ns** | **600.0 ns** |  **1.00** |    **0.00** |     **600 B** |        **1.00** |
| ConcurrentGuidRecycler |           100000 | 310.9 ns |  36.96 ns | 104.26 ns | 300.0 ns |  0.65 |    0.50 |     600 B |        1.00 |
|       GuidRecyclerSlim |           100000 | 205.4 ns |  34.21 ns |  96.49 ns | 200.0 ns |  0.45 |    0.40 |     600 B |        1.00 |
