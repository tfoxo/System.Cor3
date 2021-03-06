# NET45-Forms-ToolSuite

This program was a general experiment in a couple regards.

The idea was to harness databinding as similarly to WPF as possible through NET35 semantics.
Initially targeting NET20 (Windows XP and 2000 user workstations) by using NET35's corelib, which enabled NET35 characteristics such as LINQ and EXTENSIONS via NET20.

The project is now compiled targeting NET45.

## Template Viewer Utility

I would like to integrate the features generally exibited here, into the Generator application.

The only useful utility provided here is the “Template Viewer”, which is one of a few pages availible in the application. The source to this project is here to genrally serve historical/reference purposes, where I migrated it up here meditating on

* updating the Template Viewer concept
* I would like to generate a resource file (resx) so that templates are embedded in the application.

![](https://raw.github.com/tfoxo/System.Cor3/master/Source-Utils/Forms-ToolSuite/doc/snapshot.png)

The template editor utility is a 'special' template system that I've used for a web-project, or more importantly for designing a web-project.

I deal with a few different kinds of template-based systems.  For example, the generator application has one, somewhate different template system where we are dealing with tables, and the fields within the table.  This template system is designed for HTML rendering of information from a databsae, as well as to simplify the design process, where we could simply update the templates, and restart the web application.

Particularly here, we have a template system that is well suited for rendering advanced tables, with grouping.  As shown in the above image, we have the following fields within a single template:

* container --- topmost encapsulation
* row --- like a row within a table
* grouphead --- a group header
* groupfoot --- a group footer
* head --- like a table-header
* foot --- like a table-footer
* note --- non template, just for writing notes.
* table --- the name of the table that the template applies to.  This field might be used like a tag within the other template-sections mentioned above.
* fields --- a comma-delimited list of the fields.  The fields are simply here for reference.

### MEF Binary Source

License
: MIT?

More information on MEF
: https://mef.codeplex.com/

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
[mef-source]: http://naudio.codeplex.com/SourceControl/latest#Lib/MEF/readme.txt
[lgpl]: http://www.gnu.org/copyleft/lesser.html
