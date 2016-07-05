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
            var Pass = textBoxPassword.Text;
            var Key = Hash(Pass);
            textBoxSharedSecret.Text = Hex(Key);

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

            var FullData = new byte[BadgeHash.Length + StampHash.Length];
            Buffer.BlockCopy(BadgeHash, 0, FullData, 0, BadgeHash.Length);
            Buffer.BlockCopy(StampHash, 0, FullData, BadgeHash.Length, StampHash.Length);
            textBoxHMACInput.Text = Hex(FullData);

            var FullHMAC = HMAC(FullData, Key);
            textBoxHMACValue.Text = Hex(FullHMAC);

            var Trunc = new byte[16];
            Buffer.BlockCopy(FullHMAC, 0, Trunc, 0, 16);
            textBoxHMACTrunc.Text = Hex(Trunc);

            var B64 = Base64Custom(Trunc);
            textBoxHMACTruncB64.Text = B64;

            var Query = HttpUtility.ParseQueryString("?");
            Query["BadgeID"] = BadgeID;
            Query["Stamp"] = Stamp;
            Query["Auth"] = B64;
            var QueryString = Query.ToString();
            if ( !QueryString.StartsWith("?") )
                QueryString = "?" + QueryString;
            textBoxCompleteQuery.Text = QueryString;
        }

        private void v1ProtocolControl_Load(object sender, EventArgs e)
        {
            TextBox_TextChanged(null, null);
        }
    }
}
