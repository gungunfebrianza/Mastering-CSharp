using System;
using System.Text;
using BitmapHeader;
using System.IO;


namespace Steganography
{
    public class Stegano
    {
        public Stegano()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region HideMessage Function
        /// <summary>
        ///  This function enabels you to hide a message insider a BMP
        /// </summary>
        /// <param name="inputPath">input BMP path</param>
        /// <param name="outputPath">output BMP path</param>
        /// <param name="message">message to hide</param>
        public void HideMessage(string inputPath, string outputPath, string message)
        {
            int readByte;
            int count = 14;
            BMP bitmap = new BMP(inputPath);
            bitmap.BitmapFileHeader.bfOffBits += (message.Length + 1);
            bitmap.BitmapFileHeader.bfSize += (message.Length + 1);

            FileStream br = new FileStream(inputPath, FileMode.Open);
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(outputPath));

            bitmap.WriteBMPFileHeader(bw);
            br.Seek(14, SeekOrigin.Begin);

            while (count < (bitmap.BitmapFileHeader.bfOffBits - (message.Length + 1)))
            {
                bw.Write((byte)br.ReadByte());
                count++;
            }
            for (int i = 0; i < message.Length; i++)
            {
                bw.Write(message[i]);
            }
            bw.Write(Convert.ToByte(message.Length));

            while ((readByte = br.ReadByte()) >= 0)
            {
                bw.Write((byte)readByte);
            }
            bw.Close();
            br.Close();
        }
        #endregion

        #region RetriveMessage Function
        /// <summary>
        ///  Retrives a hidden message from a BMP
        /// </summary>
        /// <param name="path">path of BMP</param>
        /// <returns>the hidden message</returns>
        public string RetriveMessage(string path)
        {
            int length;
            StringBuilder message = new StringBuilder();
            BinaryReader br = new BinaryReader(File.OpenRead(path));
            BMP bitmap = new BMP(path);
            br.BaseStream.Seek(bitmap.BitmapFileHeader.bfOffBits - 1, SeekOrigin.Begin);
            length = (int)br.ReadByte();

            br.BaseStream.Seek(-(length + 1), SeekOrigin.Current);
            message.Append(br.ReadChars(length));
            br.Close();

            return message.ToString();
        }
        #endregion
    }
}
