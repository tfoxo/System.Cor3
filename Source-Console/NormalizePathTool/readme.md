# NormalizePathTool

The idea is to take two paths: (1) the `target`-path and (2) the `base`-path &ndash; 
and return a tidy result that is 'normalized' based on the "base-path".

The best way of looking a the concept would be by navigating from `Base` to `Target` path.
That said, we would end up with a path that looks something like `../../../dir/subdir/file.ext`
as the path would be recognized by a some other tool.

cs-source containing the task: [NormalizePathTool.cs]

File references stored in CSPROJ files are stored relative to the `$(ProjectDir)`
as pertains to MsBuild, CSharp Targets.

## NormalizePathOptions

intrinsic:

	char IllegalPathSeparator    { get;set; } = '\\'
	bool IsConsoleEnabled        { get;set; } = false
	bool MatchCase               { get;set; } = true
	char PathSeparator           { get;set; } = '/'
	bool UseFullWidthWhenShorter { get;set; } = false

## EXAMPLE OUTPUT

The following output is the result of the following command

### Command-Line (`test-tool.cmd`)

By default, the tool uses a particular set of `[NormalizePathOptions]`.

	:: Command-Options (fixed in binary)
	:: new NormalizePathOptions { IsConsoleEnabled=true, MatchCase=true, UseFullPathWhenShorter=true }
	NormalizePath "D:/DEV/WIN/CS_ROOT/Projects/github-cor3/Source-Console/NormalizePathTool/bin/Debug/NormalizePath.exe" "D:/DEV/BIN/cyg/etc/emacs/site-start.d/autoconf.el" 1> output.txt

### Output

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

[NormalizePathTool.cs]: https://github.com/tfoxo/System.Cor3/blob/master/Source/Cor3.Core/Tasks/NormalizePathTool.cs
