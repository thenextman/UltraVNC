//===============================================================
// UltraVncAxGlobalConstructor.cpp
//
// -- Implementation file of class CUltraVncAxGlobalConstructor.
//===============================================================

/////////////////////////////////////////////////////////////////////////////

// -- App obj definition file:
#include "..\VNCviewerApp32.h"

// -- Resource symbols:
#include "..\res\resource.h"

// -- Win32 VncViewer app entry point function:
extern int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow);

// -- Global application object pointer (mantained by the VNCviewerApp class):
extern VNCviewerApp *pApp;

// -- other externs:
bool ParseDisplay(LPTSTR display, LPTSTR phost, int hostlen, int *port);

/////////////////////////////////////////////////////////////////////////////

#include "UltraVncAxGlobalConstructor.h"

//
// Implementation:
//

CUltraVncAxGlobalConstructor:: ~ CUltraVncAxGlobalConstructor ()
{
	// free.
	if ( pApp )
		delete pApp;
}



VOID CUltraVncAxGlobalConstructor::Construct ( HINSTANCE hInst )
{
	CCriticalSection::scope			__access__( m_csConstructAccess );
	m_hInst = hInst;
}


BOOL CUltraVncAxGlobalConstructor::Initialize(charstring& csCmdText)
{
	//if ( pApp == NULL )
	{
		// create the app obj...
		WinMain( m_hInst, NULL, (char*)(csCmdText.c_str()), 0 );
		pApp = new VNCviewerApp32( m_hInst, (char*)(csCmdText.c_str()) );
	}
	return true;
}

BOOL CUltraVncAxGlobalConstructor::NewConnection ( CONST CHAR* pszHost , CONST CHAR* pszPassword, CONST CHAR* pszUser, CONST CHAR* pszDomain, CONST CHAR* pszDSM )
{
	INT				iPort = 0;

	// parse host name.
	CHAR			host[ 256 ] = "";
	if ( ! ::ParseDisplay( const_cast<CHAR*>( pszHost ), host, 255, & iPort ) )
		return FALSE;
	if (pszPassword!=NULL && strlen(pszPassword) > 0 &&
		pApp!=NULL ) {
		strcpy(pApp->m_options.m_clearPassword, pszPassword);
	}
	//if (pszUser!=NULL && strlen(pszUser) > 0 &&
	//		pApp!=NULL ) {
	//			strcpy(pApp->m_options.m_UserName, pszUser);
	//}
	//if (pszDomain!=NULL && strlen(pszDomain) > 0 &&
	//		pApp!=NULL ) {
	//			strcpy(pApp->m_options.m_Domain, pszDomain);
	//}
	if (pszDSM!=NULL && strlen(pszDSM) > 0 &&
			pApp!=NULL ) {
					pApp->m_options.m_fUseDSMPlugin = true;
					strcpy(pApp->m_options.m_szDSMPluginFilename, pszDSM);
	
	}
	
	// start the new connection.
	pApp->NewConnection ( host, iPort );
	return TRUE;

}

VOID CUltraVncAxGlobalConstructor::ProcessKeyEvent( HWND hwnd, WPARAM wParam, LPARAM lParam )
{
	// call the implementation.
	ClientConnection*		pConn = (ClientConnection*) ::GetWindowLong( hwnd, GWL_USERDATA );
	//if ( pConn->m_running )
	//	pConn->ProcessKeyEvent( (int) wParam, (DWORD) lParam );
}

charstring CUltraVncAxGlobalConstructor::ExecuteCommand( HWND hwnd, charstring& csCmdText, BOOL& bIsErr )
{
	bIsErr = FALSE;
	charstring			csRetVal = "Command ok.";

	::TrimAtBothSides( csCmdText );

	// which command ?

	ClientConnection*		pConn = (ClientConnection*) ::GetWindowLong( hwnd, GWL_USERDATA );
	if ( pConn->m_running )
	{
		if ( ::stricmp( csCmdText.c_str (), "sendctrlaltdel" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_CAD, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "optiondialog" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_PROPERTIES, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "requestrefresh" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_REFRESH, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "sendstart" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_STRG_ESC, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "customkey" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_SEP, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "info" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_INFO, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "endconnection" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_END, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "toggleinput" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_DINPUT, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "filetransfer" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_FTRANS, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "selectwindow" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_SW, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "selectdesktop" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_DESKTOP, 0); 
		}
		else if ( ::stricmp( csCmdText.c_str (), "textchat" ) == 0 )
		{
			pConn->SendFakeButtonEvent(hwnd, WM_COMMAND, ID_BUTTON_TEXTCHAT, 0); 
		}
		
		
		
		else if ( ::stricmp( csCmdText.c_str (), "fullcolors" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_MAXCOLORS, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "256colors" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_256COLORS, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "sendctrldown" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_CONN_CTLDOWN, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "sendctrlup" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_CONN_CTLUP, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "sendaltdown" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_CONN_ALTDOWN, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "sendaltup" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_CONN_ALTUP, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "about" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, IDD_APP_ABOUT, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "autoScaling" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_AUTOSCALING, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "normalScaling" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_NORMALSCREEN, 0 );
		else if ( ::stricmp( csCmdText.c_str (), "viewonlytoggle" ) == 0 )
			::SendMessage( hwnd, WM_SYSCOMMAND, ID_VIEWONLYTOGGLE, 0 );
		//else if ( ::stricmp( csCmdText.c_str (), "resize" ) == 0 )
		//	pConn->SizeWindow();
		else
		{
			// return an error.
			csRetVal = "Invalid command.";
			bIsErr = TRUE;
		}
	}
	else
	{
		// return an error.
		csRetVal = "Client not connected.";
		bIsErr = TRUE;
	}

	// return.
	return csRetVal;
}

/////////////////////////////////////////////////////////////////////////////
