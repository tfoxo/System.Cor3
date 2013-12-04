# Mu

It does nothing.

useful?

**Target**: SD v4.3.x or 4.4.x

## SCREEN

![](https://raw.github.com/tfoxo/System.Cor3/master/Source-ICSharpCode/Mu/build/mu-crop.png)

## USE

1. Install the SD4 compatible [addin](https://github.com/tfoxo/System.Cor3/releases/download/pdfcat-20131106/mu.sdaddin).
2. Click SD/IDE MenuItem: `/Tools/Generate Links`
3. ComboBoxes (right of 'Generate' button):
    - csproj-from: (left-most combo) source project (generation is based on this proj)
    - csproj-to: (right-most combo) this is here as a place-holder for future path-normalization on project-locations so the source-paths can be generated in a manner 'friendly' to existing project-file semantics.
4. Open your project in the text editor
    - RIGHT-CLICK the CS-PROJ you want to integrate sources from another project into, and
    - ...select the 'Open With...' option.
    - choose 'Text Editor'
5. Go back to the 'MuGenerator Tool' tab in the SD/IDE.
6. (Perhaps modify, and then) Copy the ItemGroup source from the TextEditor from the MuGen Tab.
7. Go back to your CSPROJ source and paste at the end of the last `ItemGroup`.

## TODO

- [normalize paths] such as a comparison of one project's path to another's (kind of like flash-develop does).
- Target-Specific types (None, Resource, EmbeddedResource, Compile, etc...)
- Include additional or more adequate version information in the Mu.addin-file.

[normalize paths]: https://github.com/tfoxo/System.Cor3/wiki/Normalize-Paths-Task
