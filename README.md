# VisualBasicSDL
Slow process of converting [SharpDL](https://github.com/babelshift/SharpDL)

## Required Files _currently_
 - NuGet Packages
   - [SharpDL-SDL2-CS](https://www.nuget.org/packages/sharpdl-sdl2-cs)
     - [Fork Location](https://github.com/babelshift/SDL2-CS)
   - [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging)
 - Required Runtimes
   - [SDL2 Library](https://www.libsdl.org)
     - [64bit SDL2 DLL](https://www.libsdl.org/download-2.0.php)
     - [64bit TTF DLL](https://www.libsdl.org/projects/SDL_ttf/)
     - [64bit Image DLL](https://www.libsdl.org/projects/SDL_image/)
     - [64bit Mixer DLL](https://www.libsdl.org/projects/SDL_mixer/)
       - _(the mixer is refed in the SDL2-CS lib but not used as of yet)_

## Build
Must be built as 64bit
