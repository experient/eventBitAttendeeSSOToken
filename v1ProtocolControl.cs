using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace eventBit.Apps.Example.AttendeeSSOToken
{
    public partial class v1ProtocolControl : UserControl
    {
        public v1ProtocolControl()
        {
            InitializeComponent();
        }


        private void buttonNow_Click(object sender, EventArgs e)
        {
            dateTimePickerStamp.Value = DateTime.Now;
        }

        private string Hex(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", " ");
        }
        private byte[] Hash(string data)
        {
            return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(data));
        }
        private byte[] HMAC(byte[] data, byte[] key)
        {
            return new HMACSHA256(key).ComputeHash(data);
        }

        private static readonly char[] B64WEBSAFE_ENCODE = ("???????????????????????????????????????????.?-.-0123456789???_???"
            + "ABCDEFGHIJKLMNOPQRSTUVWXYZ????_?abcdefghijklmnopqrstuvwxyz").ToCharArray();
        private string Base64Custom(byte[] input)
        {
            var C = Convert.ToBase64String(input).ToCharArray();
            for ( var I = 0; I < C.Length; I++ )
                C[I] = B64WEBSAFE_ENCODE[C[I]];
            return new string(C);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var SourceCode = textBoxSourceCode.Text;
            var SourceHash = Hash(SourceCode);
            textBoxSourceHash.Text = Hex(SourceHash);

            var Pass = textBoxPassword.Text;
            var Key = Hash(Pass);
            textBoxSharedSecret.Text = Hex(Key);

            var EventCode = textBoxEventCode.Text;
            var EventHash = Hash(EventCode);
            textBoxEventCodeHash.Text = Hex(EventHash);

            var BadgeID = textBoxBadgeID.Text;
            var BadgeHash = Hash(BadgeID);
            textBoxBadgeIDHash.Text = Hex(BadgeHash);

            var StampTime = dateTimePickerStamp.Value.ToUniversalTime();
            var Offs = TimeZoneInfo.Local.GetUtcOffset(StampTime).ToString();
            while ( Offs.EndsWith(":00") )
                Offs = Offs.Substring(0, Offs.Length - 3);
            if ( Offs.StartsWith("-") )
                Offs = Regex.Replace(Offs, "-0+", "-");
            else if ( Offs.TrimStart('0') != string.Empty )
                Offs = "+" + Offs.TrimStart('0');
            else
                Offs = string.Empty;
            labelTimeZone.Text = (TimeZoneInfo.Local.IsDaylightSavingTime(StampTime)
                ? TimeZoneInfo.Local.DaylightName
                : TimeZoneInfo.Local.StandardName)
                .Replace("&", "&&") + " (UTC" + Offs + ")";

            var Stamp = Math.Round((StampTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString();
            textBoxTimestamp.Text = Stamp;

            var StampHash = Hash(Stamp);
            textBoxTimestampHash.Text = Hex(StampHash);

            var FullData = new byte[SourceHash.Length + EventHash.Length + BadgeHash.Length + StampHash.Length];
            var Pos = 0;
            foreach ( byte[] Part in new byte[][] { SourceHash, EventHash, BadgeHash, StampHash } )
            {
                Buffer.BlockCopy(Part, 0, FullData, Pos, Part.Length);
                Pos += Part.Length;
            }
            textBoxHMACInput.Text = Hex(FullData);

            var FullHMAC = HMAC(FullData, Key);
            textBoxHMACValue.Text = Hex(FullHMAC);

            var Trunc = new byte[16];
            Buffer.BlockCopy(FullHMAC, 0, Trunc, 0, 16);
            textBoxHMACTrunc.Text = Hex(Trunc);

            var B64 = Base64Custom(Trunc);
            textBoxHMACTruncB64.Text = B64;

            var Query = HttpUtility.ParseQueryString("?");
            Query["SourceCode"] = SourceCode;
            Query["EventCode"] = EventCode;
            Query["BadgeID"] = BadgeID;
            Query["Stamp"] = Stamp;
            Query["Auth"] = B64;
            textBoxCompleteQuery.Text = Query.ToString();
        }

        private void v1ProtocolControl_Load(object sender, EventArgs e)
        {
            TextBox_TextChanged(null, null);
        }

        private string ControlText(Control c)
        {
            if ( c is Button )
                return string.Empty;
            if ( c is DateTimePicker )
                return ((DateTimePicker)c).Value.ToString("o");
            var Sub = c.Controls.OfType<Control>();
            if ( c is TableLayoutPanel )
            {
                var T = (TableLayoutPanel)c;
                Sub = Sub.OrderBy(X => T.GetRow(X)).ThenBy(X => T.GetColumn(X));
            }
            var S = c.Text + string.Concat(Sub.Select(X => ControlText(X)));
            if ( string.IsNullOrWhiteSpace(S) )
                return string.Empty;
            return " " + S.Trim();
        }
        private void buttonExport_Click(object sender, EventArgs e)
        {
            var LabelWidth = tableLayoutPanelMain.Controls.OfType<Label>()
                .Where(X => tableLayoutPanelMain.GetColumn(X) == 0)
                .Max(X => X.Text.Length);

            var ReportBuild = new StringBuilder();
            var Row = 0;
            foreach ( Control Ctl in tableLayoutPanelMain.Controls.OfType<Control>()
                .OrderBy(X => tableLayoutPanelMain.GetRow(X))
                .ThenBy(X => tableLayoutPanelMain.GetColumn(X)) )
            {
                var NewRow = tableLayoutPanelMain.GetRow(Ctl);
                if ( NewRow != Row )
                    ReportBuild.AppendLine();
                Row = NewRow;

                if ( tableLayoutPanelMain.GetColumn(Ctl) == 0 )
                    ReportBuild.Append((Ctl.Text + ":").PadRight(LabelWidth + 1));
                else
                    ReportBuild.Append(ControlText(Ctl));
            }

            var ReportPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".txt");
            File.WriteAllText(ReportPath, ReportBuild.ToString());
            Process.Start(ReportPath);
        }
    }
}
