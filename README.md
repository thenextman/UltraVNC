# UltraVNC

### Updating the fork

TODO

### Prequisites

vs2019
cmake
conan
nasm

### Build

```
mkdir build && cd build
cmake -G "Visual Studio 16 2019" -A Win32 ..
cmake --build .
```

Or generate the project (`cmake -G...`) and open UltraVncAx.sln

### TODO

- x64 build. The build works by passing the `x64` architecture to cmake and ensuring that `_X64` is defined. However there are runtime issues with the interop library.
- Generation of the AxInterop library and registration-free COM using AxHostEx.
