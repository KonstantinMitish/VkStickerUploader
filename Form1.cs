using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkStickerUploader
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private static string UploadFile(string url, string file)
    {
      WebClient wc = new WebClient();
      string response = Encoding.ASCII.GetString(wc.UploadFile(url, file));
      string keyvals = "\"file\":\"";
      int start = response.IndexOf(keyvals) + keyvals.Length,
        end = response.IndexOf("\"", start + 1);
      return response.Substring(start, end - start);
    }


    private VkApi vkApi = new VkApi();

    private void btnLogin_Click(object sender, EventArgs e)
    {
      try
      {
        vkApi.Authorize(new ApiAuthParams()
        {
          ApplicationId = 0000000,
          Login = txtLogin.Text,
          Password = txtPwd.Text,
          Settings = Settings.All,
          TwoFactorAuthorization = () =>
          {
            Two t = new Two();
            t.ShowDialog();
            return t.txt2Fac.Text;
          }
        });
        if (vkApi.IsAuthorized)
        {
          btnLogin.Enabled = false;
          txtLogin.Enabled = false;
          txtPwd.Enabled = false;
          btnAdd.Enabled = true;
        }
        else
        {
          MessageBox.Show(this, "Login error");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "Login error");
        //MessageBox.Show(this, ex.ToString(),"Login error");
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      ofd.ShowDialog();
    }

    private void ofd_FileOk( object sender, CancelEventArgs e )
    {
      string serverAddress = vkApi.Call("docs.getUploadServer", new VkParameters()
        {
          {"type", "graffiti"},
          {"access_token", vkApi.Token}
        })["upload_url"]
        .ToString();
      // Load file
      string file = UploadFile(serverAddress, ofd.FileName);
      var graf = JObject.Parse(vkApi.Call("docs.save", new VkParameters()
          {
            {"file", file},
            {"title", "graffiti.png"}
          })
          .RawJson)["response"]
        .ToArray()
        .First();
      List<MediaAttachment> att = new List<MediaAttachment>();

      Document graffiti = new Document();
      graffiti.Ext = graf["ext"].ToString();
      graffiti.Id = graf["id"].ToObject<long>();
      graffiti.OwnerId = graf["owner_id"].ToObject<long>();
      graffiti.Title = graf["title"].ToString();
      graffiti.Size = graf["size"].ToObject<long>();
      graffiti.Uri = graf["url"].ToString();
      att.Add(graffiti);
      long id = vkApi.Messages.Send(new MessagesSendParams()
      {
        Attachments = att,
        UserId = 000000000 /* here should be someone else's id */
      });
      vkApi.Messages.Delete((ulong)id);
    }

    private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
        btnLogin_Click(null, null);
    }
  }
}
