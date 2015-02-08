using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace KanjiYomi
{
    public partial class Form1 : Form
    {
        HotKey hotKey;

        IniFile ini;

        int balloonFadeoutSecond;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ホットキーの候補を作成
            hotKeys.DataSource = Enum.GetValues(typeof(Keys));

            ini = new IniFile("./config.ini");
            LoadConfig();
            RegisterHotKeyWrap();

            this.Activate();
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            hotKey.Dispose();
        }

        private void LoadConfig()
        {
            int res;

            // hotkey
            enableCtrl.Checked = ini.GetValue("hotkey", "control", "0") == "1";
            enableAlt.Checked = ini.GetValue("hotkey", "alt", "1") == "1";
            enableShift.Checked = ini.GetValue("hotkey", "shift", "1") == "1";

            if (Int32.TryParse(ini.GetValue("hotkey", "key", "81"), out res))
            {
                hotKeys.SelectedItem = (object)(Keys)res;
            }
            else
            {
                hotKeys.SelectedItem = (object)(Keys)81;
            }

            // etc
            if (Int32.TryParse(ini.GetValue("etc", "balloonFadeoutSecond", "5"), out res))
            {
                balloonFadeoutSecond = res;
            }
            else
            {
                balloonFadeoutSecond = 5;
            }
            balloonSecondBox.Value = balloonFadeoutSecond;
        }

        private void SaveConfig()
        {
            // hotkey
            ini["hotkey", "control"] = enableCtrl.Checked ? "1" : "0";
            ini["hotkey", "alt"] = enableAlt.Checked ? "1" : "0";
            ini["hotkey", "shift"] = enableShift.Checked ? "1" : "0";
            ini["hotkey", "key"] = ((Int32)(hotKeys.SelectedValue)).ToString();

            // etc
            ini["etc", "balloonFadeoutSecond"] = balloonFadeoutSecond.ToString();
        }

        // ホットキーの登録 
        private void RegisterHotKeyWrap()
        {
            if (hotKey != null)
            {
                hotKey.Dispose();
            }

            Keys key = (Keys)hotKeys.SelectedValue;

            if (key == Keys.None)
            {
                return;
            }

            MOD_KEY modKey = 0;
            modKey |= enableCtrl.Checked ? MOD_KEY.CONTROL : 0;
            modKey |= enableShift.Checked ? MOD_KEY.SHIFT : 0;
            modKey |= enableAlt.Checked ? MOD_KEY.ALT : 0;

            hotKey = new HotKey(modKey, key);
            hotKey.HotKeyPush += new EventHandler(hotKey_HotKeyPush);
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void hotKey_HotKeyPush(object sender, EventArgs e)
        {
            try
            {
                IDataObject data = Clipboard.GetDataObject();

                if (data.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)data.GetData(DataFormats.Text);
                    string yomigana = IMEConverter.ConvertYomigana(text);

                    
                    if (yomigana == null)
                    {
                        string message = "以下のテキストは自動変換できませんでした:\n" + text;
                        notifyIcon.ShowBalloonTip(balloonFadeoutSecond * 1000, "KanjiYomi", message, ToolTipIcon.Error);
                    }
                    else
                    {
                        notifyIcon.ShowBalloonTip(balloonFadeoutSecond * 1000, "KanjiYomi", yomigana, ToolTipIcon.Info);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "予期せぬエラーが発生しました:\n" + ex.Message;
                notifyIcon.ShowBalloonTip(balloonFadeoutSecond * 1000, "Error(KanjiYomi)", message, ToolTipIcon.Error);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {            
            RegisterHotKeyWrap();
            balloonFadeoutSecond = (int)balloonSecondBox.Value;
            SaveConfig();
        }

        // cf. http://www.atmarkit.co.jp/bbs/phpBB/viewtopic.php?topic=21135&forum=7
        protected override void WndProc(ref Message m)
        {
            //　WParamが、SC_MINIMIZE(0xF020)
            if ((m.Msg == 0x112) && (m.WParam == (IntPtr)0xF020))
            {
                base.Hide(); // 隠す
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.Show(); // 表示する
            this.Visible = true; // フォームの表示
            base.Activate(); // フォームをアクティブにする
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // 終了処理のキャンセル
                base.Hide(); // 隠す
            }
        }
    }
}
