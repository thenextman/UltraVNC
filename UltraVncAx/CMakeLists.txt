cmake_minimum_required(VERSION 3.15)

project(
    UltraVncAx C CXX
)

add_definitions("-DWIN32 -D_WINDOWS -D_USRDLL -D__NT__ -D__WIN32__")
add_definitions("-D_AFXDLL -D_WINDLL")
add_definitions("-D_WINSTATIC -D_ULTRAVNCAX_ -D_VIEWER")

set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>")

set(TARGET_NAME UltraVncAx)

add_library(${TARGET_NAME} SHARED "")

set(RESOURCES
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\B46.ico
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\back.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\both.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\closeup.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\cursor1.cur
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\cursorsel.cur
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\dir.ico
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\drive.ico
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\file.ico
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\flash.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\front.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\hoch.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\idr_tray.ico
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\mainicon.ico
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\maximizeup.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\minimizeup.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\nocursor.cur
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\none.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\pindown.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\stat\\pinup.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\quer.bmp
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\vnc32.BMP
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\vnc64.BMP
  ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\vncviewer.ico
)
source_group("Resource Files" FILES ${RESOURCES})
set(CMAKE_RC_FLAGS "${CMAKE_RC_FLAGS} /l 0x0410 /i ${CMAKE_SOURCE_DIR}\\vncviewer\\res")

target_sources(${TARGET_NAME}
  PRIVATE
    ${CMAKE_SOURCE_DIR}\\common\\Clipboard.cpp
    ${CMAKE_SOURCE_DIR}\\common\\UltraVncZ.cpp
    ${CMAKE_SOURCE_DIR}\\common\\win32_helpers.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\directx\\directxviewer.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\display.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\vnctouch.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\Snapshot.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\MessBox2.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionUltra2.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\sessiondialogLoadSave.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\SessionDialogTabs.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\AboutBox.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\AccelKeys.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\AuthDialog.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\buildtime.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnection.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionCacheRect.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionClipboard.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionCopyRect.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionCoRRE.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionCursor.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionFile.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionFullScreen.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionHextile.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionRaw.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionRRE.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionTight.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionUltra.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionZlib.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnectionZlibHex.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\d3des.c
    ${CMAKE_SOURCE_DIR}\\vncviewer\\Daemon.cpp
    ${CMAKE_SOURCE_DIR}\\rfb\\dh.cpp
    ${CMAKE_SOURCE_DIR}\\DSMPlugin\\DSMPlugin.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\Exception.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\FileTransfer.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\FullScreenTitleBar.cpp
    Helpers.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\KeyMap.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\KeyMapJap.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\Log.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\LowLevelHook.cpp
    ${CMAKE_SOURCE_DIR}\\lzo\\minilzo.c
    ${CMAKE_SOURCE_DIR}\\vncviewer\\MRU.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\SessionDialog.cpp
    StdAfx.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\TextChat.cpp
    UltraVncAx.cpp
    UltraVncAxGlobalConstructor.cpp
    UltraVncAxObj.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\vncauth.c
    ${CMAKE_SOURCE_DIR}\\vncviewer\\VNCOptions.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\vncviewer.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\VNCviewerApp.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\VNCviewerApp32.cpp
    ${CMAKE_SOURCE_DIR}\\ZipUnZip32\\ZipUnzip32.cpp
    ${CMAKE_SOURCE_DIR}\\vncviewer\\zrle.cpp
  PRIVATE
    ${CMAKE_SOURCE_DIR}\\vncviewer\\AboutBox.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\AccelKeys.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\AuthDialog.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\ClientConnection.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\d3des.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\Daemon.h
    ${CMAKE_SOURCE_DIR}\\rfb\\dh.h
    ${CMAKE_SOURCE_DIR}\\DSMPlugin\\DSMPlugin.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\Exception.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\FileTransfer.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\FullScreenTitleBar.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\FullScreenTitleBarConst.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\KeyMap.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\keysymdef.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\Log.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\LowLevelHook.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\MRU.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\res\\resource.h
    Resource.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\rfb.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\SessionDialog.h
    StdAfx.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\TextChat.h
    UltraVncAxCP.h
    UltraVncAxObj.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\vncauth.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\VNCOptions.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\vncviewer.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\VNCviewerApp.h
    ${CMAKE_SOURCE_DIR}\\vncviewer\\VNCviewerApp32.h
    ${CMAKE_SOURCE_DIR}\\ZipUnZip32\\ZipUnZip32.h
    ${RESOURCES}
)

add_dependencies(${TARGET_NAME} omnithread)
add_dependencies(${TARGET_NAME} rdr)
add_dependencies(${TARGET_NAME} unzip)
add_dependencies(${TARGET_NAME} zip20)
add_dependencies(${TARGET_NAME} zstd)

target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_SOURCE_DIR} ${CMAKE_SOURCE_DIR}\\vncviewer\\omnithread)
target_link_libraries(${TARGET_NAME} comctl32 winmm odbc32 odbccp32 wsock32)
target_link_libraries(${TARGET_NAME} zstd)
target_link_libraries(${TARGET_NAME} ${CONAN_TARGETS})

