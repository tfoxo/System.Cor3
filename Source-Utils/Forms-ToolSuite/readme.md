

# NET45-Forms-ToolSuite

This program was a general experiment in a couple regards.

The idea was to harness databinding as similarly to WPF as possible through NET35 semantics.
Initially targeting NET20 (Windows XP and 2000 user workstations) by using NET35's corelib, which enabled NET35 characteristics such as LINQ and EXTENSIONS via NET20.

The project is now compiled targeting NET45.

The source to this project is here to genrally serve historical/reference purposes, where I migrated it up here to 

### MEF Binary Source

License
: MIT?

MEF semantics were a bit inspiring to me at the time this was written, provided generally indirectly by [NAudio][naudio] WinForms demo a while back.  I have since considered this library unnecessary, considering how lightly it is used in this and other applications, though the library was designed well, I find simpler, transparent libraries more useful.

The MEF binary provided here originally came [here][mef-source], and has been compiled with its dependency, so that only one binary ReferenceAssembly is required for usage.  Please refer to the readme that shipped with NAudio [mef-source] to find the source code used to compile this binary.

Note that the MEF binary used here was authored at a time before the general MEF concept shipped with later versions of Microsoft's DOTNET framework.

> had to get a special build of Composition.Initialization.Desktop.zip to be able to use ExportFactory<T> with .NET 3.5
http://cid-f8b2fd72406fb218.office.live.com/self.aspx/blog/Composition.Initialization.Desktop.zip

Note that the sources are no longer available via the provided url above.  I would expect the same general license to apply to the binary, as the .NET framwork.

I've since been using my ViewPoint strategy, available [here](https://github.com/tfoxo/System.Cor3/blob/master/Source/Cor3.Core/Internals/ViewPoint.cs) (though probably lacking adequate documentation).

### ICSharpCode.TextEditor

License
: [GNU LGPL][lgpl]

The text-editor used in this application is from SharpDevelop v3.x.

[naudio]: http://naudio.codeplex.com/
[mef-source]: from http://naudio.codeplex.com/SourceControl/latest#Lib/MEF/readme.txt
[lgpl]: http://www.gnu.org/copyleft/lesser.html
