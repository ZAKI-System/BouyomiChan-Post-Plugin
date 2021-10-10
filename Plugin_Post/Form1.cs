using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Plugin_Post
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 共有値から読み込み
            urlTextBox.Text = Plugin_Post.httpUrl;
            postTextBox.Text = Plugin_Post.postPath;
            clearTextBox.Text = Plugin_Post.clearPath;
            textBox4.Text = Plugin_Post.lastError;
        }

        /// <summary>ログ記入</summary>
        /// <param name="message">内容</param>
        private void WriteLog(string message)
        {
            string text = DateTime.Now.ToString() + " " + message;
            textBox4.Text = text;
            Plugin_Post.lastError = text;
        }

        /// <summary>URIの形式を検査</summary>
        /// <returns>通過すればtrue、不正ならfalse</returns>
        private bool CheckUri()
        {
            try
            {
                var baseUri = new Uri(urlTextBox.Text);
                var postUri = new Uri(baseUri, postTextBox.Text);
                var clearUri = new Uri(baseUri, clearTextBox.Text);
                //MessageBox.Show($"base; {baseUri}\npost; {postUri}\nclear; {clearUri}");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "URI形式エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>HTTP POST</summary>
        /// <param name="uri">POST先URI</param>
        /// <param name="data">POSTするデータ文字列</param>
        private void Post(Uri uri, string data)
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.UploadData(uri, Encoding.UTF8.GetBytes("{\"data\": \""+data+"\"}"));

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
        /// <summary>HTTP GET</summary>
        /// <param name="uri">GET先URI</param>
        private void Get(Uri uri)
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadData(uri);
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

        /// <summary>送信テスト</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostTestButton_Click(object sender, EventArgs e)
        {
            if (CheckUri())
            {
                var baseUri = new Uri(urlTextBox.Text);
                var postUri = new Uri(baseUri, postTextBox.Text);
                Post(postUri, "私はMicrosoft Nanami Onlineです。これが聞こえていれば、送信は成功です。");
            }
        }

        /// <summary>削除テスト</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearTestButton_Click(object sender, EventArgs e)
        {
            if (CheckUri())
            {
                var baseUri = new Uri(urlTextBox.Text);
                var postUri = new Uri(baseUri, postTextBox.Text);
                var clearUri = new Uri(baseUri, clearTextBox.Text);
                Post(postUri, "これは1番目の文章です。次に読み上げる文章は登録されましたが、その後削除されます。");
                Post(postUri, "これは2番目の文章です。これが再生されているということは、処理に異常があります。");
                System.Threading.Thread.Sleep(1000);
                Get(clearUri);
            }
        }

        /// <summary>削除実行</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (CheckUri())
            {
                var baseUri = new Uri(urlTextBox.Text);
                var clearUri = new Uri(baseUri, clearTextBox.Text);
                Get(clearUri);
            }
        }

        /// <summary>設定保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CheckUri())
            {
                Plugin_Post.httpUrl = urlTextBox.Text;
                Plugin_Post.postPath = postTextBox.Text;
                Plugin_Post.clearPath = clearTextBox.Text;
                Properties.Settings.Default.httpUrl = Plugin_Post.httpUrl;
                Properties.Settings.Default.postPath = Plugin_Post.postPath;
                Properties.Settings.Default.clearPath = Plugin_Post.clearPath;
                Properties.Settings.Default.Save();
                MessageBox.Show("保存");
            }
        }

        /// <summary>閉じる</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
