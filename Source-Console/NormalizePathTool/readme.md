[NormalizePathTool](#normalizepathtool)
[RenameFileTool](#renamefiletool)
[XRename](#xrename)

With the few things that have been elaborating in this space, it seems
appropriate to start clustering tool-related tests to this program-space.

# NormalizePathTool

The idea is to take two paths: (1) the `target`-path and (2) the `base`-path &ndash; 
and return a tidy result that is 'normalized' based on the "base-path".

The best way of looking a the concept would be by navigating from `Base` to `Target` path.
That said, we would end up with a path that looks something like `../../../dir/subdir/file.ext`
as the path would be recognized by a some other tool.

cs-source containing the task: [NormalizePathTool.cs]

File references stored in CSPROJ files are stored relative to the `$(ProjectDir)`
as pertains to `MsBuild` CSharp Targets.

## NormalizePathOptions

intrinsic: (defaults)

<pre class="brush: csharp">
	char IllegalPathSeparator    { get;set; } = '\\'
	bool IsConsoleEnabled        { get;set; } = false
	bool MatchCase               { get;set; } = true
	char PathSeparator           { get;set; } = '/'
	bool UseFullWidthWhenShorter { get;set; } = false
</pre>

## EXAMPLE OUTPUT

The following output is the result of the following command

### Command-Line (`test-tool.cmd`)

By default, the tool (EXE) uses non-default `[NormalizePathOptions]`.

	:: Command-Options (fixed in binary)
	:: new NormalizePathOptions { IsConsoleEnabled=true, UseFullPathWhenShorter=true }
	NormalizePath ^
		"D:/DEV/WIN/CS_ROOT/Projects/github-cor3/Source-Console/NormalizePathTool/bin/Debug/NormalizePath.exe" ^
		"D:/DEV/BIN/cyg/etc/emacs/site-start.d/autoconf.el" ^
		1> output.txt

### Output

In the following example, the NormailzePathTool result is a failure to find a
common or consolidated path, so the full path to the file is returned.

Also its interesting to note here that the file-name of the given file is
lost in this process.

Apparently the tool is designed for the resulting directory.

<pre class="brush: csharp">
	var pt = new PathToolTing(dest: "c:/basepath", base: "c:/dest");
	string friendly = pt.Base.Replace(pt.After)
</pre>

That being said, the **`Base.After`** property of the command returns a value
that I wasn't quite expecting to see when editing this text document.

<pre class="brush: bash">	
	NormalizePathTool
	=================
	
	GENERALLY:
	  Similar Index    = 2
	  Target Length    = 10
	  Target Remainder = 8
	  Base   Length    = 7
	  Base   Remainder = 5
	
	SIMILARITY:
	  D:/DEV
	
	TARGET (DESTINATION):
	  Disk  = 'D:'
	  Path  = 'D:/DEV/WIN/CS_ROOT/Projects/github-cor3/Source-Console/NormalizePathTool/bin/Debug'
	  IsDir =  False, Exists =  True
	  After = 'WIN/CS_ROOT/Projects/github-cor3/Source-Console/NormalizePathTool/bin/Debug'
	  FName = 'NormalizePath.exe'
	
	BASE (CONTEXT):
	  Disk  = 'D:'
	  Path  = 'D:/DEV/BIN/cyg/etc/emacs/site-start.d'
	  IsDir =  False, Exists = False
	  After = 'BIN/cyg/etc/emacs/site-start.d'
	  FName = 'autoconf.el'
	
	RESULT:
	  Full  = D:/DEV/WIN/CS_ROOT/Projects/github-cor3/Source-Console/NormalizePathTool/bin/Debug
	  FullIsShorter  = True
	  Exist = False
	  D:/DEV/WIN/CS_ROOT/Projects/github-cor3/Source-Console/NormalizePathTool/bin/Debug
</pre>

[NormalizePathTool.cs]: https://github.com/tfoxo/System.Cor3/blob/master/Source/Cor3.Core/Tasks/NormalizePathTool.cs

# RenameFileTool

A batch tool for renaming multiple files to a format such as "file000.ext"

things that are needed:

* (1) only rename matched regular expressions.  only regex flag
* (2) cbz/cbr compression configuration
	* look in windows registry
	* look for uninstall
	* look in environment
* (2A) CBZ/R Creation From Directory as input COMMAND STRING
* (2B) Execute the command

## xrename

> Regular-Expression Rename

I thought that this application was fully in a working status,
but apparently I had moved a bunch of the settings onto the
`Setting` class inside the task/tool.

Apparently this is the kind of little tool that can be pushed
a bit further, and it appears to be caught up in such a process.

For one thing, this program was designed to cater to one case:
Image files contained within a cbr (, cbz, ...) archive are 
sorted by their distinctive file-name, when organized into a
set of pages as displayed in a reader.

### Settings: Switches

* `-i` InputDirectories (List)
* `-x` Expression
* `-xr` ExpressionReplace
* `-spr` SortPre
* `-spo` SortPost
* `-r` Reverse (order)

### Settings: Types

* string Expression
* Regex ExpressionReplace
* List<string> Items
* bool OnlyUseMatches
* string OutputDir
* bool Recursive
* Regex RegularExpression
* bool Reverse
* bool SortPost
* bool SortPre

