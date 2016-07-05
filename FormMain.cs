using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace eventBit.Apps.Example.AttendeeSSOToken
{
    public partial class FormMain : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void TaggedControl_Enter(object sender, EventArgs e)
        {
            var Ctl = sender as Control;
            if ( Ctl == null )
                return;
            var Tag = Ctl.Tag as string;
            if ( string.IsNullOrWhiteSpace(Tag) )
                return;
            var Suff = textBoxHelp.Tag as string;
            if ( !string.IsNullOrWhiteSpace(Suff) && (Suff != Tag) )
                Tag = string.Format("{1}{0}{0}{2}", Environment.NewLine, Tag, Suff);
            textBoxHelp.Text = Tag;
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxHelp.Tag = textBoxHelp.Text;

            this.Width = Screen.GetWorkingArea(this).Width;
            this.CenterToParent();

            var Q = new Queue<Control>();
            Q.Enqueue(this);
            while ( Q.Count > 0 )
            {
                var C = Q.Dequeue();
                if ( C.Tag != null )
                    C.Enter += TaggedControl_Enter;
                foreach ( var X in C.Controls.OfType<Control>() )
                    Q.Enqueue(X);
            }

            var ReadmePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "README.txt");
            var ReadmeContent = File.Exists(ReadmePath) ? File.ReadAllText(ReadmePath) : null;
            textBoxReadme.Text = string.IsNullOrWhiteSpace(ReadmeContent)
                ? "README.txt file not found, inaccessible, or blank."
                : ReadmeContent;
        }
    }
}