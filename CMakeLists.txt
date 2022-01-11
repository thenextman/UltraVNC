cmake_minimum_required(VERSION 3.1)

project(
    UltraVnc C CXX
)

set(CMAKE_COLOR_MAKEFILE ON)

INCLUDE_EXTERNAL_MSPROJECT(omnithread ${CMAKE_SOURCE_DIR}\\vncviewer\\omnithread\\omnithread_VC2017.vcxproj)
INCLUDE_EXTERNAL_MSPROJECT(rdr ${CMAKE_SOURCE_DIR}\\rdr\\rdr_VC2017.vcxproj)

add_subdirectory(UltraVncAx)