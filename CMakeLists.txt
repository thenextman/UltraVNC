cmake_minimum_required(VERSION 3.15)

project(
    UltraVnc C CXX
)

set(CMAKE_COLOR_MAKEFILE ON)
set(CMAKE_MODULE_PATH "${CMAKE_SOURCE_DIR}/cmake")

include(ConanHelper)

if(NOT CMAKE_BUILD_TYPE)
	set(CMAKE_BUILD_TYPE "Debug")
endif()

set(LIBJPEG_TARGET "CONAN_PKG::libjpeg-turbo")
add_definitions("-DWITH_JPEG")

set(ZLIB_TARGET "CONAN_PKG::zlib")
add_definitions("-DWITH_ZLIB")

INCLUDE_EXTERNAL_MSPROJECT(omnithread ${CMAKE_SOURCE_DIR}\\vncviewer\\omnithread\\omnithread_VC2017.vcxproj)
INCLUDE_EXTERNAL_MSPROJECT(rdr ${CMAKE_SOURCE_DIR}\\rdr\\rdr_VC2017.vcxproj)
INCLUDE_EXTERNAL_MSPROJECT(zip20 ${CMAKE_SOURCE_DIR}\\zipunzip_src\\zip20\\windll\\visualc\\lib\\zip32_VC2017.vcxproj)
INCLUDE_EXTERNAL_MSPROJECT(unzip ${CMAKE_SOURCE_DIR}\\zipunzip_src\\unzip\\windll\\vc6\\lib\\unz32lib_VC2017.vcxproj)

add_subdirectory(zstd)
add_subdirectory(UltraVncAx)