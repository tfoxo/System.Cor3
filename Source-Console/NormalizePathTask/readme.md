# NormalizePathTask

The idea is to take two paths: (1) the `target`-path and (2) the `base`-path &ndash; 
and return a tidy result that is 'normalized' based on the "base-path".

The best way of looking a the concept would be by navigating from `Base` to `Target` path.
That said, we would end up with a path that looks something like `../../../dir/subdir/file.ext`
as the path would be recognized by a some other tool.

cs-source containing the task: [NormalizePathTask.cs](https://github.com/tfoxo/System.Cor3/blob/master/Source/Cor3.Core/Tasks/NormalizePathTask.cs)

File references stored in CSPROJ files are stored relative to the `$(ProjectDir)`
as pertains to MsBuild, CSharp Targets.

