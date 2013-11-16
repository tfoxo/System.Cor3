# Mu

It does nothing.

useful?

a basic process goes 

## does

![](https://raw.github.com/tfoxo/System.Cor3/master/Source-ICSharpCode/Mu/build/mu.png)

## to use:

1. In the SD/IDE select the menu-item: `Tools/Generate Links`
2. Note that following the generate button are two combo-boxes: from, to
    - the from combo is used for the source project where links are generated from
    - the to combo is used as the relative path for the mentioned todo below (normalizing paths)
3. Open your project in the text editor
    - RIGHT-CLICK the CS-PROJ you want to integrate sources from another project into, and
    - ...select the 'Open With...' option.
    - choose 'Text Editor'
4. Go back to the 'MuGenerator Tool' tab in the SD/IDE.
5. (Perhaps modify, and then) Copy the ItemGroup source from the TextEditor from the MuGen Tab.
6. Go back to your CSPROJ source and paste at the end of the last `ItemGroup`.

## todos

- normalize paths such as a comparison of one project's path to another's.
- Target-Specific types (None, Resource, EmbeddedResource, Compile, etc...)
