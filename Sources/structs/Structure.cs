// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace WCL.Sources.structs
{
		/// <summary>
		/// Abstract class that provides facilities to allocate/deallocate C structures in a generic manner.
		/// </summary>
		/// <typeparam name="T">Type of the underlying C struct that will be allocated and manipulated.</typeparam>
	public unsafe abstract class Structure<T>: IDisposable where T : struct 
	{
#region Initialization
		public Structure ()
		{
			IntPtr l_item = Marshal.AllocHGlobal (Marshal.SizeOf<T> ());
			if (l_item == IntPtr.Zero) {
				throw new OutOfMemoryException ("Cannot Allocate WCL structs");
			} else {
				Win32.FillMemory (l_item, (uint) Marshal.SizeOf <T> (), 0);
			}
			_item = l_item;
			_shared = false;

			Contract.Ensures (_item != IntPtr.Zero, "item_set");
			Contract.Ensures (!_shared, "not shared");
		}
#endregion

#region Status Report
		public bool is_shared
		{
			get { return _shared; }
			set { _shared = value; }
		}
#endregion

#region Implementation: Access
		protected IntPtr _item;
		protected bool _shared;
		#endregion

#region Disposal
		protected virtual void Dispose (bool disposing)
		{
			if ((_item != null) && !_shared) {
				Marshal.FreeHGlobal (_item);
				_item = IntPtr.Zero;
			}
		}

		 ~Structure() {
		   Dispose(false);
		}

		public void Dispose ()
		{
			Dispose (true);
		}
#endregion

	}
}
