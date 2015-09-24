// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using WCL.Callbacks;
using WCL.Enums;

namespace WCL.Structs
{
		/// <summary>
		/// Representation of the Win32 WND_CLASS structure.
		/// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms633576(v=vs.85).aspx for more details.
		/// </summary>
	public class WndClass : Structure<_WndClass>
	{
#region Initialization
		public WndClass (string a_class_name): base()
			// Initialize current instance with `a_class_name' as `class_name'.
		{
			Contract.Requires (a_class_name != null, "a_class_name not null");

			ClassName = a_class_name;
			unsafe {
				Handle->hInstance = Win32.GetModuleHandle (null);
			}

			Contract.Ensures (ClassName.Equals (a_class_name), "class_name_set");
			Contract.Ensures (_handle != IntPtr.Zero, "item_set");
		}
#endregion

#region Access
		public unsafe _WndClass* Handle
		{
			get { return (_WndClass*) _handle; }
		}

		public unsafe string ClassName
		{
			get {
				if (Handle->lpszClassName != IntPtr.Zero) {
					return Marshal.PtrToStringUni (Handle->lpszClassName);
				} else {
					return null;
				}
			}
			set {
				if (value != null) {
					_class_name = new WclString (value);
					Handle->lpszClassName = _class_name.Handle;
				} else {
					_class_name = null;
					Handle->lpszClassName = IntPtr.Zero;
				}
			}
		}

		public unsafe string MenuName
		{
			get {
				if (Handle->lpszMenuName != IntPtr.Zero) {
					return Marshal.PtrToStringUni (Handle->lpszMenuName);
				} else {
					return null;
				}
			}
			set {
				_menu_name = new WclString (value);
				Handle->lpszMenuName = _menu_name.Handle;
			}
		}

		public unsafe WndProc WindowProcedure
		{
			get { return _window_procedure; }
			set {
				_window_procedure = value;
				Handle->lpfnWndProc = Marshal.GetFunctionPointerForDelegate <WndProc> (value);
			}
		}

		public unsafe IntPtr Cursor
		{
			get { return Handle->hCursor; }
			set { Handle->hCursor = value; }
		}

		public unsafe IntPtr Icon
		{
			get { return Handle->hIcon; }
			set { Handle->hIcon = value; }
		}
		public unsafe IntPtr BackgroundBrush
		{
			get { return Handle->hbrBackground; }
			set { Handle->hbrBackground = value; }
		}

		public unsafe ClassStyles Style
		{
			get { return (ClassStyles) Handle->style; }
			set { Handle->style = (uint) value; }
		}
#endregion

#region Basic operations
		public void Register ()
		{
				// This returns the atom of the new registered class. For now we do not store it.
			Win32.RegisterClass (_handle);
		}

		public unsafe void UnRegister ()
		{
			Contract.Requires (IsRegistered (), "registered");

			Win32.UnregisterClass (Handle->lpszClassName, Handle->hInstance);

			Contract.Ensures (!IsRegistered (), "not registered");
		}
#endregion

#region Status Report
		public unsafe bool IsRegistered ()
		{
			_WndClass l_class;
			return Win32.GetClassInfo (IntPtr.Zero, Handle->lpszClassName, &l_class) ||
				Win32.GetClassInfo (Handle->hInstance, Handle->lpszClassName, &l_class);
		}
#endregion

#region Implementation: Access
		private WclString _class_name;
		private WclString _menu_name;
		private WndProc _window_procedure;
#endregion
	}

		/// <summary>
		/// Wrapper of the WND_CLASS Windows structure. We do our own marshalling for the 
		/// `lpszClassName' and `lpszMenuName' entry.
		/// </summary>
	[StructLayout (LayoutKind.Sequential)]
	public struct _WndClass
	{
		public uint style;
		public IntPtr lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;
		public IntPtr lpszMenuName;
		public IntPtr lpszClassName;
	}

}
