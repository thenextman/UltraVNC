cmake_minimum_required(VERSION 3.15)

project(
    zstd C CXX
)

add_definitions("-DWIN32 -D_CONSOLE -D_CRT_SECURE_NO_WARNINGS")
add_definitions("-DZSTD_MULTITHREAD=1 -DZSTD_LEGACY_SUPPORT=5")

set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>")

set(TARGET_NAME zstd)

add_library(${TARGET_NAME} STATIC "")

target_sources(${TARGET_NAME}
  PRIVATE
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/pool.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/debug.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/threading.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/entropy_common.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/hist.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/error_private.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/xxhash.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/zstd_common.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/fse_decompress.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/fse_compress.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/huf_compress.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_compress.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_compress_literals.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_compress_sequences.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_compress_superblock.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_fast.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_double_fast.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_lazy.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_opt.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_ldm.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstdmt_compress.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/decompress/huf_decompress.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/decompress/zstd_decompress.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/decompress/zstd_decompress_block.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/decompress/zstd_ddict.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/dictBuilder/cover.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/dictBuilder/fastcover.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/dictBuilder/divsufsort.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/dictBuilder/zdict.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v01.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v02.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v03.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v04.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v05.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v06.c"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v07.c"
  PRIVATE
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/pool.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/threading.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/bitstream.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/error_private.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/zstd_errors.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/mem.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/fse.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/huf.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/xxhash.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_legacy.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v01.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v02.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v03.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v04.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v05.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v06.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/legacy/zstd_v07.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/zstd.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/common/zstd_internal.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_compress_literals.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_compress_sequences.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_cwksp.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_compress_superblock.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_fast.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_double_fast.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_lazy.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_opt.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstd_ldm.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/compress/zstdmt_compress.h"
    "${CMAKE_CURRENT_LIST_DIR}/lib/decompress/zstd_ddict.h"
)
