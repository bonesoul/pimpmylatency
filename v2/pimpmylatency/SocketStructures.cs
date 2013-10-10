using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace pimpmylatency
{
    [StructLayout(LayoutKind.Sequential)]
    public struct sockaddr
    {
        public short sa_family;
        public ushort sin_port;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] in_addr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] sin_zero;
    }

    public static class SocketStructures
    {
        /* marshaling byte arrays to structs http://www.vsj.co.uk/articles/display.asp?id=501 */
        public static object cast_to_struct(Array array, Type t)
        {
            byte[] buffer = (byte[])array;
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            object temp = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), t);
            handle.Free();

            /* big endian to small endian fixes */
            if (t == typeof(sockaddr))
            {
                sockaddr temp2 = (sockaddr)temp;
                temp2.sin_port = SwapUInt16(temp2.sin_port);
                temp = temp2;
            }
            return temp;
        }

        /* http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/c878e72e-d42e-417d-b4f6-1935ad96d8ae */
        public static short SwapInt16(short v)
        {
            return (short)(((v & 0xff) << 8) | ((v >> 8) & 0xff));
        }

        public static ushort SwapUInt16(ushort v)
        {
            return (ushort)(((v & 0xff) << 8) | ((v >> 8) & 0xff));
        }

        public static int SwapInt32(int v)
        {
            return (int)(((SwapInt16((short)v) & 0xffff) << 0x10) |
                          (SwapInt16((short)(v >> 0x10)) & 0xffff));
        }

        public static uint SwapUInt32(uint v)
        {
            return (uint)(((SwapUInt16((ushort)v) & 0xffff) << 0x10) |
                           (SwapUInt16((ushort)(v >> 0x10)) & 0xffff));
        }

        public static long SwapInt64(long v)
        {
            return (long)(((SwapInt32((int)v) & 0xffffffffL) << 0x20) |
                           (SwapInt32((int)(v >> 0x20)) & 0xffffffffL));
        }

        public static ulong SwapUInt64(ulong v)
        {
            return (ulong)(((SwapUInt32((uint)v) & 0xffffffffL) << 0x20) |
                            (SwapUInt32((uint)(v >> 0x20)) & 0xffffffffL));
        }
    }
}
