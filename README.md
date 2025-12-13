# Elite: Dangerous Custom Binding File Reader

A simple library for parsing the `Custom.(version).binds` file containing controller bindings for
the game *Elite: Dangerous*.

Created so that I could query the state of bindings in other programs, particularly a Unity-based
MFD Controller that I'm toying with.

# .Net Standard

The Reader library targets .NET Standard 2.1 so that this can be used in a Unity 6 project. There was some extra
steps needed to install the .NET 10 SDK on OSX, via HomeBrew, but everything seems to be working now ...

# Installation

(Coming Soon - Release and NuGet Packages)

# Usage

```csharp
using Meancat.EliteBinding.Reader;

var doc = BindingFileReader.LoadBindingFile("path/to/your/Custom.4.2.binds");
var bindings = new Bindings(doc);

// these are the controls that don't have a device bound to them:        
foreach (var name in Bindings.NoDevice)
{
    Output.WriteLine($"Missing binding: {name}");
}
foreach(var binding in Bindings.ForDevice("044FB352")) // values from your Bindings file
{
    Output.WriteLine($"'{binding.Name}'' is key {binding.Key}");
    //Example: 'Supercruise'is key Joy_13
}
```


# Disclaimer
This library reads files from Elite: Dangerous, with the permission of Frontier Developments plc for non-commercial purposes. 
It is not endorsed by nor reflects the views or opinions of Frontier Developments and no employee of Frontier Developments was involved in the making of it.
