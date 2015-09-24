// Copyright (c) 2015 manu-silicon
// This file is distributed under the MIT License. See LICENSE.md for details.

using System;
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;

namespace WCL.Structs
{
		/// <summary>
		/// .NET representation of a Win32 LPWSTR string to avoid the default .NET marshalling between
		/// .NET and the C/C++ code.
		/// </summary>
	public class WclString
	{
#region Initialization
		public WclString (string s) : this (s.Length)
		{
			Contract.Requires (s != null, "s not null");

			SetString (s);

			Contract.Ensures (_handle != IntPtr.Zero, "handle set");
			Contract.Ensures (Capacity == s.Length, "capacity_set");
			Contract.Ensures (String().Equals(s), "string_set");
		}

		public WclString(int n)
		{
			Contract.Requires (n >= 0, "n non negative");

			IntPtr l_item = Marshal.AllocHGlobal ((n + 1) * unit_size);
			if (l_item == IntPtr.Zero) {
				throw new OutOfMemoryException ("Cannot Allocate WclString");
			} else {
				Win32.FillMemory (l_item, (uint) ((n + 1) * unit_size), 0);
			}
			_handle = l_item;
			_capacity = n;

			Contract.Ensures (_handle != IntPtr.Zero, "handle set");
			Contract.Ensures (Capacity == n, "capacity_set");
		}
		#endregion

#region Access
		public IntPtr Handle { get { return _handle; } }

		public const int unit_size = 2;

		public string String ()
		{
			return Marshal.PtrToStringUni (_handle);
		}
#endregion

#region Measurements
		public int Capacity
			// Capacity that current can hold expressed in number of characters (i.e. a multiple of `unit_size'.
		{
			get {

				Contract.Ensures (_capacity >= 0, "capacity non-negative");

				return _capacity;
			}
		}

		public int Count
		{
			get {
				int nb = Capacity;
				int i = 0;
				int l_char_size = unit_size;

				for (; i < nb; i++) {
					if (Marshal.ReadInt16 (_handle, i * l_char_size) == 0) {
						return i;
					}
				}
					// End of buffer was reached.
				return Capacity;
			}
		}
#endregion

#region Element change
		public void SetString (string a_string)
		{
			Contract.Requires (a_string != null, "a_string not null");

			int nb = a_string.Length;
			int i = 0;
			int l_char_size = unit_size;

			for (; i < nb; i++) {
				char c = a_string [i];
				Marshal.WriteInt16(_handle, i * l_char_size, c);
			}
			Marshal.WriteInt16 (_handle, nb * l_char_size, 0);

			Contract.Ensures (String ().Equals (a_string), "string_set");
		}
#endregion

#region Implementation: Accesss
		protected int _capacity;
		protected IntPtr _handle;
#endregion

		[ContractInvariantMethod]
		private void ClassInvariant ()
		{
//			Contract.Invariant (_handle != IntPtr.Zero, "internal pointer not null");
//			Contract.Invariant (_capacity >= 0, "capacity non-negative");
		}
	}
}

