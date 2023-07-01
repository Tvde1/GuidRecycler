GuidRecycler
=======

![GuidRecycler](https://raw.githubusercontent.com/Tvde1/GuidRecycler/main/icon.png "GuidRecycler")

![CI](https://github.com/Tvde1/GuidRecycler/workflows/CI/badge.svg)
[![NuGet](https://img.shields.io/nuget/dt/GuidRecycler.svg)](https://www.nuget.org/packages/GuidRecycler)
[![NuGet](https://img.shields.io/nuget/vpre/GuidRecycler.svg)](https://www.nuget.org/packages/GuidRecycler)
![Guids Recycled](https://img.shields.io/badge/guids%20recycled-61k-blue)
![Code coverage](https://img.shields.io/badge/code%20coverage-59%25-yellow)
![Uptime](https://img.shields.io/badge/uptime-100%25-green)

*Save the planet, recycle your guids!*

## What is it?
GuidRecycler is a library that allows you to recycle guids. It is a simple concept.

## Installation
GuidRecycler is available as a [NuGet package](https://www.nuget.org/packages/GuidRecycler/).
```powershell
Install-Package GuidRecycler
```

## Usage:
Guid recyclers implement the common interface `IGuidRecycler` which has the following methods:

```csharp
void Recycle(Guid guid);
```
To recycle a guid to the recycle bin.

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

### Example
The guid recycler can be created manually or retrieved through dependency injection.
```csharp
class UserService
{
    private readonly DatabaseContext _context;
    private readonly IGuidRecycler recycler = new GuidRecyclerSlim();

    public async Task DeleteUser(User user)
    {
        _context.Users.Remove(user);
        recycler.Recycle(user.Id);
        await _context.SaveChangesAsync();
    }

    public async Task<User> CreateUser(string name)
    {
        var user = new User
        {
            Id = recycler.GetGuid(),
            Name = name
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
```
As you can see, this code is very simple and eco-friendly. The only thing you need to do is to recycle the guid when you delete the entity and to get a new guid when you create a new entity.

### Microsoft.Extensions.DependencyInjection
Coming soon

## Performance
See the benchmarks in the benchmarks folder. It clearly shows that the both the concurrent guid recycler and the guid recycler slim are faster than the default guid generator.
|                 Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
|           **Guid.NewGuid** | **647.9 ns** | **113.68 ns** | **327.99 ns** | **600.0 ns** |  **1.00** |    **0.00** |     **600 B** |        **1.00** |
| ConcurrentGuidRecycler | 307.1 ns |  49.97 ns | 146.56 ns | 300.0 ns |  0.58 |    0.39 |     600 B |        1.00 |
|       GuidRecyclerSlim | 224.0 ns |  28.33 ns |  81.75 ns | 200.0 ns |  0.45 |    0.30 |     600 B |        1.00 |

## Contributing
PRs welcome. Merging not guaranteed.