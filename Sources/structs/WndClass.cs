// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using WCL.Callbacks;
using WCL.Enums;
using WCL.Sources.structs;

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

			class_name = a_class_name;
			unsafe {
				item->hInstance = Win32.GetModuleHandle (null);
			}

			Contract.Ensures (class_name.Equals (a_class_name), "class_name_set");
			Contract.Ensures (_item != IntPtr.Zero, "item_set");
		}
#endregion

#region Access
		public unsafe _WndClass* item
		{
			get { return (_WndClass*) _item; }
		}

		public unsafe string class_name
		{
			get {
				if (item->lpszClassName != IntPtr.Zero) {
					return Marshal.PtrToStringUni (item->lpszClassName);
				} else {
					return null;
				}
			}
			set {
				if (value != null) {
					_class_name = new WclString (value);
					item->lpszClassName = _class_name.item;
				} else {
					_class_name = null;
					item->lpszClassName = IntPtr.Zero;
				}
			}
		}

		public unsafe string menu_name
		{
			get {
				if (item->lpszMenuName != IntPtr.Zero) {
					return Marshal.PtrToStringUni (item->lpszMenuName);
				} else {
					return null;
				}
			}
			set {
				_menu_name = new WclString (value);
				item->lpszMenuName = _menu_name.item;
			}
		}

		public unsafe WndProc window_procedure
		{
			get { return _window_procedure; }
			set {
				_window_procedure = value;
				item->lpfnWndProc = Marshal.GetFunctionPointerForDelegate <WndProc> (value);
			}
		}

		public unsafe IntPtr cursor
		{
			get { return item->hCursor; }
			set { item->hCursor = value; }
		}

		public unsafe ClassStyles style
		{
			get { return (ClassStyles) item->style; }
			set { item->style = (uint) value; }
		}
#endregion

#region Basic operations
		public void register ()
		{
				// This returns the atom of the new registered class. For now we do not store it.
			Win32.RegisterClass (_item);
		}

		public unsafe void unregister ()
		{
			Contract.Requires (is_registered (), "registered");

			Win32.UnregisterClass (item->lpszClassName, item->hInstance);

			Contract.Ensures (!is_registered (), "not registered");
		}
#endregion

		public unsafe bool is_registered ()
		{
			_WndClass l_class;
			return Win32.GetClassInfo (IntPtr.Zero, item->lpszClassName, &l_class) ||
				Win32.GetClassInfo (item->hInstance, item->lpszClassName, &l_class);
		}

		private WclString _class_name;
		private WclString _menu_name;
		private WndProc _window_procedure;
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
