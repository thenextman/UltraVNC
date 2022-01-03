

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Mon Jan 18 19:14:07 2038
 */
/* Compiler settings for UltraVncAx.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 8.01.0622 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        EXTERN_C __declspec(selectany) const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif // !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, IID_IUltraVncAxObj,0x02EC92A0,0x6F22,0x4AF0,0x8C,0x60,0xD3,0x0B,0x8D,0x8C,0x11,0x09);


MIDL_DEFINE_GUID(IID, LIBID_ULTRAVNCAXLib,0x987AD05D,0x338A,0x4E92,0x99,0x1B,0xF3,0x0C,0x31,0x82,0x49,0x68);


MIDL_DEFINE_GUID(IID, DIID__IUltraVncAxObjEvents,0x5A54BC6C,0x6386,0x41D1,0xA7,0xD0,0x69,0x4E,0x10,0xD8,0x4D,0xD8);


MIDL_DEFINE_GUID(CLSID, CLSID_UltraVncAxObj,0x3B6D183B,0xF70D,0x43EB,0xA8,0x8D,0x21,0x64,0x2D,0x6F,0x75,0xA7);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



