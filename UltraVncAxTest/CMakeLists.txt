cmake_minimum_required(VERSION 3.15)

project(UltraVncAxTest LANGUAGES CSharp)

include(CSharpUtilities)

set(TARGET UltraVncAxTest)

add_executable(${TARGET}
    App.config
    Form1.cs
    Form1.Designer.cs
    Program.cs
    UVNCaxHost.cs
    Properties/AssemblyInfo.cs
    Properties/Resources.Designer.cs
    Properties/Resources.resx
    Properties/Settings.Designer.cs
    Properties/Settings.settings
)

set_property(TARGET ${TARGET} PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.7.2")
set_property(TARGET ${TARGET} PROPERTY WIN32_EXECUTABLE TRUE)
set(CMAKE_CSharp_FLAGS "/langversion:latest")

csharp_set_windows_forms_properties(
    Form1.cs
    Form1.Designer.cs
    Program.cs
    UVNCaxHost.cs
    Properties/AssemblyInfo.cs
    Properties/Resources.Designer.cs
    Properties/Resources.resx
    Properties/Settings.Designer.cs
    Properties/Settings.settings
)

# If necessary, link in other library dependencies that were built locally in this source tree.
#target_link_libraries(MyWinFormApp MyLocalLib)

# If necessary, link in other library/DLL references, such as 3rd party libraries.
#set_property(TARGET MyWinFormApp PROPERTY 
#    VS_DOTNET_REFERENCE_MyThirdPartyLib /path/to/libs/MyThirdPartyLib.dll)

set_property(TARGET ${TARGET} PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "System"
    "System.Core"
    "System.Data"
    "System.Drawing"
    "System.Windows.Forms"
)

target_link_libraries(${TARGET} UltraVncAx)
target_link_libraries(${TARGET} Interop.UltraVncAx)