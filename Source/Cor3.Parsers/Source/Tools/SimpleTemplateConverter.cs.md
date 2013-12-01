# SimpleTemplateConverter

This simple template converter is a simple little tool that I've used to replace
some common elements within (perhaps) simple template (*.tpl) files.

I could be wrong in assuming as such, however it seems that the main feature
of this guy is to do the common `string.Replace` using some defined value
and key.  I believe that I've used this specifically for html `*.tpl` files
where we place a tag in the template called `{root}`.  The root tag is replaced
with the root URI such as `http://vaio/mypath`.

I am currently unaware of weather or not this little script has any practical
use in any related project.  If so, it was once used within a simple build script.
Or, perhaps it was written for a build script but was ignored due to its lack
of ______ (quality?).
