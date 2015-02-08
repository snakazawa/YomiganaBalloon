using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace YomiganaBalloon
{
    /// <summary>
    /// cf. http://www.atmarkit.co.jp/fdotnet/dotnettips/151winshow/winshow.html
    /// </summary>
    static class Program
    {
        // アプリケーション固定名
        private static string strAppConstName = "YomiganaBalloon";

        // 多重起動を防止するミューテックス
        private static Mutex mutexObject;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Windows 2000（NT 5.0）以降のみグローバル・ミューテックス利用可
            OperatingSystem os = Environment.OSVersion;
            if ((os.Platform == PlatformID.Win32NT) && (os.Version.Major >= 5))
            {
                strAppConstName = @"Global\" + strAppConstName;
            }

            try
            {
                // ミューテックスを生成する
                mutexObject = new Mutex(false, strAppConstName);
            }
            catch (ApplicationException)
            {
                // グローバル・ミューテックスの多重起動禁止
                MessageBox.Show("すでに起動しています。2つ同時には起動できません。", "多重起動禁止");
                return;
            }

            // ミューテックスを取得する
            if (mutexObject.WaitOne(0, false))
            {
                // アプリケーションを実行
                Application.Run(new Form1());

                // ミューテックスを解放する
                mutexObject.ReleaseMutex();
            }
            else
            {
                // 実行中の同じアプリケーションのウィンドウ・ハンドルの取得
                Process prevProcess = GetPreviousProcess();
                if ((prevProcess != null) &&
                    (prevProcess.MainWindowHandle != IntPtr.Zero))
                {
                    // 起動中のアプリケーションを最前面に表示
                    WakeupWindow(prevProcess.MainWindowHandle);
                }
                else
                {
                    // 警告を表示
                    MessageBox.Show("すでに起動しています。2つ同時には起動できません。", "多重起動禁止");
                }
            }

            // ミューテックスを破棄する
            mutexObject.Close();
        }

        // 外部プロセスのウィンドウを起動する
        public static void WakeupWindow(IntPtr hWnd)
        {
            // メイン・ウィンドウが最小化されていれば元に戻す
            if (IsIconic(hWnd))
            {
                ShowWindowAsync(hWnd, SW_RESTORE);
            }

            // メイン・ウィンドウを最前面に表示する
            SetForegroundWindow(hWnd);
        }
        // 外部プロセスのメイン・ウィンドウを起動するためのWin32 API
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        // ShowWindowAsync関数のパラメータに渡す定義値
        private const int SW_RESTORE = 9;  // 画面を元の大きさに戻す

        // 実行中の同じアプリケーションのプロセスを取得する
        public static Process GetPreviousProcess()
        {
            Process curProcess = Process.GetCurrentProcess();
            Process[] allProcesses = Process.GetProcessesByName(curProcess.ProcessName);

            foreach (Process checkProcess in allProcesses)
            {
                // 自分自身のプロセスIDは無視する
                if (checkProcess.Id != curProcess.Id)
                {
                    // プロセスのフルパス名を比較して同じアプリケーションか検証
                    if (String.Compare(
                            checkProcess.MainModule.FileName,
                            curProcess.MainModule.FileName, true) == 0)
                    {
                        // 同じフルパス名のプロセスを取得
                        return checkProcess;
                    }
                }
            }

            // 同じアプリケーションのプロセスが見つからない！  
            return null;
        }
    }
}
