using FNF.BouyomiChanApp;
using FNF.XmlSerializerSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Plugin_Post
{
    public class Plugin_Post : IPlugin
    {
        // bouyomiプラグイン設定
        public string Name => "Bouyomi POST Plugin";
        public string Version => "2021/10/11r1";
        public string Caption => "bouyomiからHTTP POST送信します。";
        public ISettingFormData SettingFormData => null;

        // 共有
        public static string httpUrl = "http://localhost";
        public static string postPath = "/post";
        public static string clearPath = "/clear";
        public static string lastError = "";

        // private
        private ToolStripButton button;
        private FNF.Utility.BouyomiChan.VoiceSAPI50 fakeVoice = new FNF.Utility.BouyomiChan.VoiceSAPI50("外部サーバー");
        private FNF.Utility.VoiceType fakeVoiceType = (FNF.Utility.VoiceType)9000;
        private FNF.Utility.BouyomiChan.IVoice curVoice;
        private int curVolume;
        private int curSpeed;
        private int curTone;

        private void WriteLog(string message)
        {
            lastError = DateTime.Now.ToString() + " " + message;
        }

        /// <summary>起動時か、プラグインを有効にしたタイミングで呼ばれる</summary>
        public void Begin()
        {
            // 設定読み込み
            httpUrl = Properties.Settings.Default.httpUrl;
            postPath = Properties.Settings.Default.postPath;
            clearPath = Properties.Settings.Default.clearPath;

            // 音声項目登録
            Pub.FormMain.comboBoxVoiceType.SelectedIndexChanged += ComboBoxVoiceType_SelectedIndexChanged;
            Pub.FormMain.comboBoxVoiceType.Items.Add(fakeVoice);
            Pub.FormMain.comboBoxVoiceType.SelectedItem = fakeVoice;
            curVoice = (FNF.Utility.BouyomiChan.IVoice)Pub.FormMain.comboBoxVoiceType.SelectedItem;
            Pub.FormMain.BC.Voices.Add(fakeVoiceType, fakeVoice);

            // 再生intercept登録
            Pub.FormMain.BC.TalkTaskStarted += BC_TalkTaskStarted;

            // パラメータintercept登録
            Pub.FormMain.trackBarVolume.ValueChanged += TrackBarVolume_ValueChanged;
            Pub.FormMain.trackBarSpeed.ValueChanged += TrackBarSpeed_ValueChanged;
            Pub.FormMain.trackBarTone.ValueChanged += TrackBarTone_ValueChanged;
            curVolume = Pub.FormMain.trackBarVolume.Value;
            curSpeed = Pub.FormMain.trackBarSpeed.Value;
            curTone = Pub.FormMain.trackBarTone.Value;

            // 設定ボタン追加
            button = new ToolStripButton
            {
                ToolTipText = "Bouyomi POST 設定",
                Image = Properties.Resources.icon
            };
            button.Click += Button_Click;
            Pub.ToolStrip.Items.Add(button);
        }

        private void TrackBarTone_ValueChanged(object sender, EventArgs e)
        {
            curTone = Pub.FormMain.trackBarTone.Value;
        }
        private void TrackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            curSpeed = Pub.FormMain.trackBarSpeed.Value;
        }
        private void TrackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            curVolume = Pub.FormMain.trackBarVolume.Value;
        }

        /// <summary>intercept 音声変更</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxVoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            curVoice = (FNF.Utility.BouyomiChan.IVoice)Pub.FormMain.comboBoxVoiceType.SelectedItem;
        }

        /// <summary>設定ボタンクリック時</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            using (var form = new Form1())
            {
                form.ShowDialog(Pub.FormMain);
            }
        }

        /// <summary>intercept 再生</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BC_TalkTaskStarted(object sender, FNF.Utility.BouyomiChan.TalkTaskStartedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"speed:{e.TalkTask.Speed}/tone:{e.TalkTask.Tone}/vol:{e.TalkTask.Volume}");
            System.Diagnostics.Debug.WriteLine($"speedC:{curSpeed}/toneC:{curTone}/volC:{curVolume}");
            // デフォルトorSAPI使用かつfakeVoice選択時、またはfakeVoice指定時のみ動作
            //if (true)
            //if (e.TalkTask.VoiceType == fakeVoiceType)
            if (((e.TalkTask.VoiceType == (FNF.Utility.VoiceType)10001 || e.TalkTask.VoiceType == FNF.Utility.VoiceType.Default) && curVoice == fakeVoice)
                || e.TalkTask.VoiceType == fakeVoiceType)
            {
                e.Cancel = true;
                using (var client = new WebClient())
                {
                    try
                    {
                        var bUri = new Uri(httpUrl);
                        var pUri = new Uri(bUri, postPath);
                        
                        // パラメータ 外部指定時はそれを設定、その他はスライダー値を設定
                        string escapedWord = e.ReplaceWord.Replace("\\", "\\\\").Replace("\"", "\\\"");
                        int speed = e.TalkTask.Speed == -1 ? curSpeed : e.TalkTask.Speed;
                        int tone = e.TalkTask.Tone == -1 ? curTone : e.TalkTask.Tone;
                        int volume = e.TalkTask.Volume == -1 ? curVolume : e.TalkTask.Volume;
                        byte[] body = Encoding.UTF8.GetBytes("{\"data\": \"" + escapedWord + "\",\"speed\":" + speed + ",\"tone\":" + tone + ",\"volume\":" + volume + "}");
                        
                        // 送信
                        client.Headers.Add("Content-Type", "application/json");
                        client.UploadData(pUri, body);
                    }
                    catch (WebException wex)
                    {
                        HttpWebResponse wres = (HttpWebResponse)wex.Response;
                        if (wres != null)
                        {
                            WriteLog(wres.StatusCode.ToString());
                        }
                        else
                        {
                            WriteLog(wex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>終了時か、プラグインを無効にしたタイミングで呼ばれる</summary>
        public void End()
        {
            // 音声項目解除
            Pub.FormMain.comboBoxVoiceType.SelectedIndexChanged -= ComboBoxVoiceType_SelectedIndexChanged;
            Pub.FormMain.comboBoxVoiceType.Items.Remove(fakeVoice);
            Pub.FormMain.comboBoxVoiceType.SelectedIndex = 0;
            Pub.FormMain.BC.Voices.Remove((FNF.Utility.VoiceType)9000);

            // 再生intercept解除
            Pub.FormMain.BC.TalkTaskStarted -= BC_TalkTaskStarted;

            // パラメータintercept解除
            Pub.FormMain.trackBarVolume.ValueChanged -= TrackBarVolume_ValueChanged;
            Pub.FormMain.trackBarSpeed.ValueChanged -= TrackBarSpeed_ValueChanged;
            Pub.FormMain.trackBarTone.ValueChanged -= TrackBarTone_ValueChanged;

            // 設定ボタン削除
            Pub.ToolStrip.Items.Remove(button);
            button.Dispose();
        }
    }
}
