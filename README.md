# IX.Libraries

## Introduction

IX.Libraries is a set of .NET libraries that seeks to implement various extensions in order to
standardize access to some functionality.

The motivation behind this library was introduced in .NET 4 where the
[`List<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1) class
introduced the ForEach method. Arrays have their own static ForEach method (which turns out to be
extremely slow compared to the foreach cycle), whereas IEnumerable do not have a ForEach at all.

Then came the Task Parallel Library which introduced Parallel.ForEach, which uses IEnumerable as a
parameter.

So I came up with this library that exposes extension methods which give the same ForEach approach
to enumerable and to array.

Furthermore, the ICloneable interface is recommended by MSDN to not be used at all, leaving us with
no baked-in way to define an object which can have shallow clones or an object which can have deep
clones. I had to make my own.

This is, in a nutshell, how I came up with this library.

## Documentation

Documentation is available [at this address](https://adrianmos.eu/Pages/Projects/ixstandardextensions/docs.md)
(and is currently under construction :construction: ).

## Requirements

Requirements for IX.StandardExtensions are the same across IX projects.
[This page](https://adrianmos.eu/Pages/Projects/FrameworkVersionsSupport.md) lists estimative .NET
version support information across various frameworks and OSes.

## Releases

- NuGet: [![IX.Libraries NuGet](https://img.shields.io/nuget/dt/IX.Library.svg)](https://www.nuget.org/packages/IX.Library/)
- Latest stable: [![IX.Libraries NuGet](https://img.shields.io/nuget/v/IX.Library.svg)](https://www.nuget.org/packages/IX.Library/)
- Latest with pre-release: [![IX.Libraries NuGet pre-release](https://img.shields.io/nuget/vpre/IX.Library.svg)](https://www.nuget.org/packages/IX.Library/)


## Highlights

- Extension methods for arrays that aim to implement the same behavior as IEnumerable
- Extension methods for string comparison (current/invariant culture, case sensitive/insensitive,
ordinal, etc.), such as string.CurrentCultureEqualsInsensitive()
- A character set detector at IX.StandardExtensions.Globalization.CharsetDetectionEngine
- Observable and thread-safe observable collections at IX.Observable
- Classes and extensions for undo/redo
- Thread-safe and atomic classes in IX.System.Threading
- Advanced locking and synchronization classes and extension methods in IX.System.Threading
- Object pools, standardized concurrent dictionaries and invalidating lazy in IX.Efficiency
- Busy UI scope and notification-related events and delegates in IX.StandardExtensions.ComponentModel
- Contracts-oriented helper methods for requires in IX.StandardExtensions.Contracts
- Abstractions for IO operations
- Standardized entitiy interfaces
- Asynchronous-related helper methods and classes

...and many many extension methods, as well as other goodies.

## Contributing

### Guidelines

Contributing can be done by anyone, at any time and in any form, as long as the
contributor has read the [contributing guidelines](https://adimosh.github.io/contributingguidelines)
beforehand and tries their best to abide by them.

### Licenses and structure

This project uses the MIT license. [![MIT license](https://img.shields.io/github/license/adimosh/ix.standardextensions)](LICENSE)

Additionally, the character set detection engine featured at _IX.StandardExtensions.Globalization_
takes bits and pieces from various other projects, and is licensed as such. You can find the additional
licenses in [/src/IX.StandardExtensions/StandardExtensions/Globalization/CharsetDetection/Licenses](src/IX.StandardExtensions/StandardExtensions/Globalization/CharsetDetection/Licenses).

The character set detector itself is based (and imports most of the code from)
[Julian Verdurmen](https://github.com/304NotModified)'s [UTF-Unknown](https://github.com/CharsetDetector/UTF-unknown) project. All applicable licenses translate to this code.
Changes from that project are:

- public classes have been made internal
- as much as possible, code has been formatted in a better way
- as much as possible, long has been used instead of int

I have made an effort to keep the original files (headers and license notice included) intact as
much as possible, however, adaptations will have occurred. I do not take any credit for that part
of the code, all of it goes to Julian and the respective contributors and original developers.

## Usage (to be moved to documentation soon)

The libraries expose a lot of methods in an attempt to standardize the approach to code, so we'll just take a few examples.

### ForEach on an IEnumerable.

Given we have:

```csharp
IEnumerable<someClass> someCollection;
```

We would call a method for each item of the collection like this:

```csharp
foreach (var item in someCollection)
{
    someMethod(item);
}
```

With the extension method, we could call it like this:

```csharp
someCollection.ForEach(someMethod);
```

The same would hold true for an array.

Although, to be fair, if you're going to have a benchmark of:

```csharp
i++;
```

...then the foreach cycle will be faster, since you will not have an extra method invocation.

As an extra bonus, you can run them using task parallel library (.NET Standard 1.1 and above only).

```csharp
someCollection.ParallelForEach(someMethod);
```

### Sequence Equals

The next example comes from the need to compare data. Comparison on arrays or enumerables (or between an array or an IEnumerable) has always been slightly burdensome. We have a helper for that:

```csharp
if (someCollection.SequenceEquals(someOtherCollection))
{
    // Do something
}
```

### Atomic enumerator

The _AtomicEnumerator_ class is an enumerator based on another enumerator, which synchronizes data fetching (e.g. the _Next_ and _Reset_ methods), and which will fail just like a regular enumerator if the collection is changed.

## IX.Math

IX.Math is a .NET library that reads mathematical formulas as text and creates delegates
and delegate placeholders for solving them at runtime.

The library is capable of interpreting any mathematical expression that makes sense from
a logical perspective, complete with a few mathematical functions. It supports integer
numbers (as [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64) in standard
numeric formats), floating-point numbers (as
[double](https://docs.microsoft.com/en-us/dotnet/api/system.double)), strings (as
[string](https://docs.microsoft.com/en-us/dotnet/api/system.string)), binary data (as
[byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)), and boolean (as
[bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)) values, and can
compute the most common mathematic operations, as well as certain mathematics functions.

### What you can do with it

Let's assume that you have a text box in which a user can introduce a formula:

```
1+2
```

You need to calculate the value of what the user has typed in for later use. In order to
do that, since the user can input any formula they wish, you would need an interpreter
that works with a given set of rules and that can calculate what the user types in.

With IX.Math, you can calculate formulas with varying degrees of complexity:

```
1+2   // 3
(1+2)*5   // 15
sqrt(25)+max(2,17)+min(sqrt(45)*sin(12),floor(pi))   // 25
```

...and so on.

Even if your formula involves different data types, you can still do calculations:

```
25*strlen("abc")   // 75
substr("ABC",1,1)+"ecause of love"   // "Because of love"
"I have "+min(strlen("abc"),5)+" oranges."   // "I have 3 oranges"
```

From within your .NET software, you can go with more complex formulas that can even
contain external variables:

```
(x+2)*y
```

...where _x_ and _y_ can be provided either as parameters to a delegate that is created
for you, or as externally-held data through the use of a data finder class. Assuming
that `x=3` and `y=5`, the above formula would yield 25.

Even assuming that your data changes and you wish to plot variations accross time,
you can still use IX.Math. Let's assume that calling multiple times for the value of _x_
returns 1, then 2, then 3:

```
"The values accross time are: "+x+","+x+", and "+x   // "The values are 1, 2, and 3"
```

Logical and bitwise operations are supported:

```
x|y
x&y
x^y
```

Comparison and equation are also supported:

```
x=y
x>y
x<=y
x!=y
```

...and, if you wish to specify tolerance for these operations, there are a multitude of
ways to specify tolerance, including range and percentage.

You can even rename your own operators:

```
x add y
x subtract y
x multiply by the power of 8
x [ y
x $big$boss$ y   // We don't judge
```

...or create custom functions, interpret values in funny ways, and many many more!

### How to get

This project is primarily available through NuGet.

The current version can be accessed by using NuGet commands:

#### Commands

##### .NET CLI

```powershell
dotnet add package IX.Math
```

##### PowerShell

```powershell
Install-Package IX.Math
```

##### Package reference

```xml
<PackageReference Include="IX.Math" Version="1.0.0" />
```

##### Paket

```powershell
paket add IX.Math
```

#### Versions

| Release | Package |
|:-------:|:-------:|
| Stable | [![IX.Math NuGet](https://img.shields.io/nuget/v/IX.Math)](https://www.nuget.org/packages/IX.Math/) |
| Pre-release | [![IX.Math NuGet](https://img.shields.io/nuget/vpre/IX.Math)](https://www.nuget.org/packages/IX.Math/) |

![](https://img.shields.io/nuget/dt/IX.Math)

### Usage

The [usage guide](Usage.md) page holds information on how to use IX.Math in your software.

Additionally, consult the [extensibility page](Extensibility.md) if you need customized
behavior for IX.Math.