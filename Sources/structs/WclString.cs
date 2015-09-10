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
		public WclString (string s) : this (s.Length)
		{
			Contract.Requires (s != null, "s not null");

			set_string (s);

			Contract.Ensures (_item != IntPtr.Zero, "item_set");
			Contract.Ensures (capacity == s.Length, "capacity_set");
			Contract.Ensures (get_string().Equals(s), "string_set");
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
			_item = l_item;
			_capacity = n;

			Contract.Ensures (_item != IntPtr.Zero, "item_set");
			Contract.Ensures (capacity == n, "capacity_set");
		}

		public IntPtr item { get { return _item; } }

		public string get_string ()
		{
			return Marshal.PtrToStringUni (_item);
		}

		public int capacity
			// Capacity that `item' can hold expressed in number of characters (i.e. a multiple of `unit_size'.
		{
			get {

				Contract.Ensures (_capacity >= 0, "capacity non-negative");

				return _capacity;
			}
		}

		public int count
		{
			get {
				int nb = capacity;
				int i = 0;
				int l_char_size = unit_size;

				for (; i < nb; i++) {
					if (Marshal.ReadInt16 (_item, i * l_char_size) == 0) {
						return i;
					}
				}
					// End of buffer was reached.
				return capacity;
			}
		}

		public void set_string (string a_string)
		{
			Contract.Requires (a_string != null, "a_string not null");

			int nb = a_string.Length;
			int i = 0;
			int l_char_size = unit_size;

			for (; i < nb; i++) {
				char c = a_string [i];
				Marshal.WriteInt16(_item, i * l_char_size, c);
			}
			Marshal.WriteInt16 (_item, nb * l_char_size, 0);

			Contract.Ensures (get_string ().Equals (a_string), "string_set");
		}

		public const int unit_size = 2;
		protected int _capacity;
		protected IntPtr _item;

		[ContractInvariantMethod]
		private void ClassInvariant ()
		{
//			Contract.Invariant (_item != IntPtr.Zero, "internal pointer not null");
//			Contract.Invariant (_capacity >= 0, "capacity non-negative");
		}
	}
}

