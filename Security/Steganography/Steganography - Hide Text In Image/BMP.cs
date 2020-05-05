using System;
using System.Runtime.InteropServices;
using System.IO;

namespace BitmapHeader
{
    public class BMP
    {
        private string PATH;
        public BMPFileHeader BitmapFileHeader;


        #region BITMAPFILEHEADER Header Structure

        public class BMPFileHeader
        {
            public char[] bfType = new char[2]; // Specifies the file type, must be BM. 
            public int bfSize; //Specifies the size, in bytes, of the bitmap file. 
            public short reserved1; //Reserved; must be zero. 
            public short reserved2; //Reserved; must be zero. 
            public int bfOffBits; //Specifies the offset, in bytes, from the beginning of the BITMAPFILEHEADER structure to the bitmap bits. 

            public BMPFileHeader()
            {
            }

        }

        #endregion


        public BMP(string path)
        {
            PATH = path;

            if (File.Exists(PATH))
            {
                BinaryReader br = new BinaryReader(File.OpenRead(PATH));
                // Read BMP File Header
                BitmapFileHeader = new BMPFileHeader();
                ReadBMPFileHeader(br);
                br.Close();
            }
        }


        private void ReadBMPFileHeader(BinaryReader br)
        {

            BitmapFileHeader.bfType = br.ReadChars(2);
            BitmapFileHeader.bfSize = br.ReadInt32();
            BitmapFileHeader.reserved1 = br.ReadInt16();
            BitmapFileHeader.reserved2 = br.ReadInt16();
            BitmapFileHeader.bfOffBits = br.ReadInt32();

        }

        #region Write Bitmap Header

        /// <summary>
        ///  Writes new header
        /// </summary>
        /// <param name="bw">The binray writer stream</param>
        public void WriteBMPFileHeader(BinaryWriter bw)
        {
            bw.Write(this.BitmapFileHeader.bfType);
            bw.Write(this.BitmapFileHeader.bfSize);
            bw.Write(this.BitmapFileHeader.reserved1);
            bw.Write(this.BitmapFileHeader.reserved2);
            bw.Write(this.BitmapFileHeader.bfOffBits);
        }
        #endregion

    }
}
