using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KanjiYomi
{
    /// <summary>
    /// cf. http://handcraft.blogsite.org/Memo/Article/Archives/424
    /// </summary>
    static class IMEConverter
    {
        static public string ConvertYomigana(string str)
        {
            IFELanguage ifelang = null;
            string yomigana;

            try
            {
                ifelang = Activator.CreateInstance(Type.GetTypeFromProgID("MSIME.Japan")) as IFELanguage;
                int hr = ifelang.Open();
                if (hr != 0)
                {
                    throw Marshal.GetExceptionForHR(hr);
                }
                hr = ifelang.GetPhonetic(str, 1, -1, out yomigana);
                if (hr != 0)
                {
                    throw Marshal.GetExceptionForHR(hr);
                }

                ifelang.Close();
            }
            catch (COMException ex)
            {
                if (ifelang != null) ifelang.Close();
                throw ex;
            }

            return yomigana;
        }

        // IFELanguage2 Interface ID
        //[Guid("21164102-C24A-11d1-851A-00C04FCC6B14")]
        [ComImport]
        [Guid("019F7152-E6DB-11d0-83C3-00C04FDDB82E")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IFELanguage
        {
            int Open();
            int Close();
            int GetJMorphResult(uint dwRequest, uint dwCMode, int cwchInput, [MarshalAs(UnmanagedType.LPWStr)] string pwchInput, IntPtr pfCInfo, out object ppResult);
            int GetConversionModeCaps(ref uint pdwCaps);
            int GetPhonetic([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string result);
            int GetConversion([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string result);
        }
    }
}
