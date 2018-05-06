using System;
using System.IO;
using System.Reflection;
 
namespace appdetect
{
    public enum ExecutableArchitecture : ushort
    {
        PE32 = 0x10b,
        PEPLUS = 0x20b
    }
 
    public enum ExecutableMemoryType : uint
    {
        NATIVE = 0x0,
        MANAGED = 0x1
    }
 
    public enum ExecutableSubsystem : ushort
    {
        NATIVE = 0x0001,
        GUI = 0x0002,
        CONSOLE = 0x0003,
 
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(Assembly.GetEntryAssembly().Location);
            using (Stream stream = file.OpenRead())
            {
                Console.WriteLine("Architecture: " + GetArchitecture(stream));
                Console.WriteLine("Subsystem: " + GetSubsystem(stream));
                Console.WriteLine(".NET/NATIVE: " + GetMemoryType(stream));
            }
            Console.ReadLine();
        }
 
        /// <summary>
        /// Get executable e_lfanew
        /// </summary>
        static uint GetElfanew(Stream stream)
        {
            byte[] buffer = new byte[sizeof(uint)];
            stream.Seek(0x3c, SeekOrigin.Begin);
            stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt32(buffer, 0);
        }
 
        /// <summary>
        /// Get executable subsystem
        /// </summary>
        static ExecutableSubsystem GetSubsystem(Stream stream)
        {
            if (!stream.CanSeek)
                throw new Exception("Stream is not seekable");
 
            uint e_lfanew = GetElfanew(stream);
 
            byte[] buffer = new byte[sizeof(ushort)];
            stream.Seek(e_lfanew + 0x5c, SeekOrigin.Begin);
            stream.Read(buffer, 0, buffer.Length);
 
            return (ExecutableSubsystem)BitConverter.ToUInt16(buffer, 0);
        }
 
        /// <summary>
        /// Get executable memory type
        /// </summary>
        static ExecutableMemoryType GetMemoryType(Stream stream)
        {
            if (!stream.CanSeek)
                throw new Exception("Stream is not seekable");
 
            uint e_lfanew = GetElfanew(stream);
 
            byte[] buffer = new byte[sizeof(uint)];
            uint offset = 0xe8;
            if (GetArchitecture(stream) == ExecutableArchitecture.PEPLUS)
            {
                offset = 0xf8;
            }
            stream.Seek(e_lfanew + offset, SeekOrigin.Begin);
            stream.Read(buffer, 0, buffer.Length);
 
            uint framework = BitConverter.ToUInt32(buffer, 0);
            if (framework > 0)
            {
                return ExecutableMemoryType.MANAGED;
            }
            else
            {
                return ExecutableMemoryType.NATIVE;
            }
        }
 
        /// <summary>
        /// Get executable architecture
        /// </summary>
        static ExecutableArchitecture GetArchitecture(Stream stream)
        {
            if (!stream.CanSeek)
                throw new Exception("Stream is not seekable");
 
            uint e_lfanew = GetElfanew(stream);
 
            byte[] buffer = new byte[sizeof(ushort)];
            stream.Seek(e_lfanew + 0x18, SeekOrigin.Begin);
            stream.Read(buffer, 0, buffer.Length);
 
            return (ExecutableArchitecture)BitConverter.ToUInt16(buffer, 0);
        }
    }
}
