﻿using System.Runtime.InteropServices;
using Calamari.Integration.FileSystem;

namespace Calamari.Utilities.FileSystem
{
    internal class WindowsPhysicalFileSystem : CalamariPhysicalFileSystem
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

        protected override bool GetDiskFreeSpace(string directoryPath, out ulong totalNumberOfFreeBytes)
        {
            ulong freeBytesAvailable;
            ulong totalNumberOfBytes;

            return GetDiskFreeSpaceEx(directoryPath, out freeBytesAvailable, out totalNumberOfBytes, out totalNumberOfFreeBytes);
        }
    }
}