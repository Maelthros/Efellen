Simple guide for compiling `World.exe` based on system.

## Compiling on Windows

Ensure [.NET Framework 4.0](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net40) is installed.

* Launch `PowerShell` via the Start Menu
* Navigate to the SoS repo's `Data\System` directory

```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc /optimize /unsafe /t:exe /out:World.exe /win32icon:Source\icon.ico /d:NEWTIMERS /d:NEWPARENT /recurse:Source\*.cs
```

## Compiling on macOS

Ensure [dotnet](https://formulae.brew.sh/formula/dotnet) is installed via [Homebrew](https://brew.sh/).

* Launch `Terminal.app` via Spotlight
* Navigate to the SoS repo's `Data\System` directory

```
dotnet build Source
```
## Compiling on Linux

To compile under Linux, navigate do /Data/System and run the following:

```
mcs -optimize+ -unsafe -t:exe -out:../../WorldLinux.exe -win32icon:Source/icon.ico -nowarn:219,414 -d:NEWTIMERS -d:NEWPARENT -d:MONO -recurse:Source/*.cs
```

later, run it with mono on the root folder, where WorldLinux.exe was created:

```
mono WorldLinux.exe
```