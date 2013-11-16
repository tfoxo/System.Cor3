# Mu

It does nothing.

useful?

**Target**: SD v4.3.x or 4.4.x

## SCREEN

![](https://raw.github.com/tfoxo/System.Cor3/master/Source-ICSharpCode/Mu/build/mu.png)

## to use:

1. Install the SD4 compatible [addin](https://github.com/tfoxo/System.Cor3/releases/download/pdfcat-20131106/mu.sdaddin).
2. In the SD/IDE select the menu-item: `Tools/Generate Links`
3. Note that following the generate button are two combo-boxes: from, to
    - the from combo is used for the source project where links are generated from
    - the to combo is used as the relative path for the mentioned todo below (normalizing paths)
4. Open your project in the text editor
    - RIGHT-CLICK the CS-PROJ you want to integrate sources from another project into, and
    - ...select the 'Open With...' option.
    - choose 'Text Editor'
5. Go back to the 'MuGenerator Tool' tab in the SD/IDE.
6. (Perhaps modify, and then) Copy the ItemGroup source from the TextEditor from the MuGen Tab.
7. Go back to your CSPROJ source and paste at the end of the last `ItemGroup`.

## todos

- normalize paths such as a comparison of one project's path to another's.
- Target-Specific types (None, Resource, EmbeddedResource, Compile, etc...)
