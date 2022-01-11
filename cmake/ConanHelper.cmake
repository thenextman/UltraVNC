
include(conan)

# ensure we're running the required conan version
conan_minimum_required(1.11.2)

# generate conan profile name
if(ANDROID)
    set(CONAN_PROFILE_OS "android")
    set(CONAN_PROFILE_ARCH "${ANDROID_SYSROOT_ABI}")
elseif(IOS)
    set(CONAN_PROFILE_OS "ios")
    list(GET CMAKE_OSX_ARCHITECTURES 0 CMAKE_OSX_ARCHITECTURE)
    set(CONAN_PROFILE_ARCH "${CMAKE_OSX_ARCHITECTURE}")
    set(CONAN_PROFILE_ARCHS "${CMAKE_OSX_ARCHITECTURES}")
elseif(APPLE)
    set(CONAN_PROFILE_OS "macos")
    list(GET CMAKE_OSX_ARCHITECTURES 0 CMAKE_OSX_ARCHITECTURE)
    set(CONAN_PROFILE_ARCH "${CMAKE_OSX_ARCHITECTURE}")
    set(CONAN_PROFILE_ARCHS "${CMAKE_OSX_ARCHITECTURES}")
elseif(WIN32)
    set(CONAN_PROFILE_OS "windows")
    if("${CMAKE_GENERATOR_PLATFORM}" STREQUAL "ARM64")
        set(CONAN_PROFILE_ARCH "arm64")
    else()
        if(CMAKE_SIZEOF_VOID_P EQUAL 8)
            set(CONAN_PROFILE_ARCH "x86_64")
        else()
            set(CONAN_PROFILE_ARCH "x86")
        endif()
    endif()
elseif(UNIX)
    set(CONAN_PROFILE_OS "linux")
    if(CMAKE_SYSTEM_PROCESSOR MATCHES "aarch64|arm64|ARM64")
        set(CONAN_PROFILE_ARCH "arm64")
    elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "x86_64|x64|amd64|AMD64")
        set(CONAN_PROFILE_ARCH "x86_64")
    elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "x86|i386|i486|i586|i686")
        set(CONAN_PROFILE_ARCH "x86")
    endif()
endif()

set(CONAN_PROFILE "${CONAN_PROFILE_OS}-${CONAN_PROFILE_ARCH}")

if(NOT CMAKE_BUILD_TYPE)
	set(CMAKE_BUILD_TYPE "Release")
endif()

conan_check()

if(NOT CMAKE_HOST_APPLE)
    set(CONAN_BUILD_SETTING "never")
else()
    set(CONAN_BUILD_SETTING "missing")
endif()

conan_cmake_install(
    CONANFILE conanfile.txt
    PROFILE ${CONAN_PROFILE}
    GENERATORS cmake
    UPDATE
    BUILD ${CONAN_BUILD_SETTING}
    SETTINGS "build_type=${CMAKE_BUILD_TYPE}"
)

set(CONAN_DISABLE_CHECK_COMPILER ON)
conan_load_buildinfo()
conan_basic_setup(TARGETS NO_OUTPUT_DIRS)

if(NOT DEFINED CONAN_OUTPUT_DIRS)
	if(CMAKE_GENERATOR STREQUAL "Ninja")
		set(CONAN_OUTPUT_DIRS ON)
	else()
		set(CONAN_OUTPUT_DIRS OFF)
	endif()
endif()

if(CONAN_OUTPUT_DIRS)
	conan_output_dirs_setup()
endif()
