//===============================
// UltraVncAxGlobalConstructor.h
//===============================

#pragma once

/////////////////////////////////////////////////////////////////////////////

#include "CCritSec.h"
#include "Helpers.h"

/////////////////////////////////////////////////////////////////////////////

class CUltraVncAxGlobalConstructor
{
public:

	// destruction.
	virtual ~ CUltraVncAxGlobalConstructor ();

public:

	// methods.
	VOID Construct ( HINSTANCE hInst );
	BOOL NewConnection ( CONST CHAR* pszHost , CONST CHAR* pszPassword=NULL, CONST CHAR* pszUser =NULL, CONST CHAR* pszDomain = NULL, CONST CHAR* pszDSM = NULL );
	VOID ProcessKeyEvent( HWND hwnd, WPARAM wParam, LPARAM lParam );
	charstring ExecuteCommand( HWND hwnd, charstring& csCmdText, BOOL& bIsErr );
	BOOL Initialize( charstring& csCmdText);

protected:

	// data.
	CCriticalSection				m_csConstructAccess;
	HINSTANCE						m_hInst ;
};

/////////////////////////////////////////////////////////////////////////////
