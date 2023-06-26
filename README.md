# GuidRecycler
*Save the planet, recycle your guids!*

## What is it?
GuidRecycler is a library that allows you to recycle guids. It is a simple concept.

## Installation
GuidRecycler is available as a [NuGet package](https://www.nuget.org/packages/GuidRecycler/).
```powershell
Install-Package GuidRecycler
```

## Usage:
Guid recyclers implement the common interface:

```csharp
void Recycle(Guid guid);
```
To recycle a guid.

```csharp
Guid GetGuid();
```
To retrieve a recycled (or new) guid.

### Strategies
There are curently two strategies implemented:
- ConcurrentGuidRecycler  
  A robust thread-safe concurrent guid recycler.
- GuidRecyclerSlim  
  A non-thread-safe guid recycler that is faster than the concurrent guid recycler.

## Performance
See the benchmarks in the benchmarks folder. It clearly shows that the both the concurrent guid recycler and the guid recycler slim are faster than the default guid generator.
|                 Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
|           **Guid.NewGuid** | **647.9 ns** | **113.68 ns** | **327.99 ns** | **600.0 ns** |  **1.00** |    **0.00** |     **600 B** |        **1.00** |
| ConcurrentGuidRecycler | 307.1 ns |  49.97 ns | 146.56 ns | 300.0 ns |  0.58 |    0.39 |     600 B |        1.00 |
|       GuidRecyclerSlim | 224.0 ns |  28.33 ns |  81.75 ns | 200.0 ns |  0.45 |    0.30 |     600 B |        1.00 |

## Contributing
PRs welcome. Merging not guaranteed.