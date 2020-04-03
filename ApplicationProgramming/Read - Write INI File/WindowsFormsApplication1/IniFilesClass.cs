using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace IniFilesClass
{
    public class IniFile
    {    
        public IniFile(string INIPath)
        {
            iniFileName = INIPath;

        }

         /*
         * [配置]
         * name = roman
         * age = 26
         * man = true;
         */

        private static string iniFileName;
        public static string AppFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName; 
        /// <summary>
        /// 和程序名子一样的  C:\WindowsFormsApplication1.ini
        /// </summary>
        public static string AppIniName = AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.GetFileNameWithoutExtension(AppFileName) + ".ini";
        
        /// <summary>
        /// 和程序名子一样的   C:\WindowsFormsApplication1.exe.ini
        /// </summary>
        public static string AppIniName1 = AppFileName + ".ini";

        #region DllImport...
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string SectionName, string KeyName, string Value, string FileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string SectionName, string KeyName, string sDefault, StringBuilder retVal, int size, string FileName);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(string SectionName, string KeyName, int nDefault, string FileName); 

        #endregion

        public void WriteString(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value,iniFileName);
        }
   
        public string ReadString(string Section, string Key, string sDefault)
        {
            StringBuilder sb = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, sDefault, sb, 255, iniFileName);
            return sb.ToString();
        }

        public void WriteInteger(string Section, string Key, int nValue)
        {
            WritePrivateProfileString(Section,Key,nValue.ToString(),iniFileName);
        }
  
        public int ReadInteger(string Section, string Key, int nDefault)
        {
            return  GetPrivateProfileInt(Section, Key, nDefault, iniFileName);
        }

        public void WriteBool(string Section, string Key, bool bValue)
        {
            WritePrivateProfileString(Section, Key, bValue.ToString(), iniFileName);
        }
     
        public bool ReadBool(string Section, string Key, bool nDefault)
        {
            string Value = ReadString(Section,Key,"");
            Value=Value.ToUpper();

            switch ( Value )
            {
                case "TRUE":
                    return true;
                   

                case "FALSE":
                    return false;
                    

                default:
                    return false;
            }
        }
    
    
    }
}
