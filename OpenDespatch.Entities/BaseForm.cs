using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.Entities
{
    public partial class BaseForm : Form
    {
        public delegate void LogWriterDelegate(string message, Color textColor);

        public LogWriterDelegate WriteLogMethod;
        protected RichTextBox logRichy;

        public BaseForm()
        {
            InitializeComponent();
            WriteLogMethod = new LogWriterDelegate(WriteLog);
        }

        #region Public utility functions
        public void WriteLog(string message, Color textColor)
        {
            if (logRichy == null) return;

            logRichy.SelectionStart = logRichy.TextLength;
            logRichy.SelectionColor = textColor;
            logRichy.AppendText(String.Format("{0:yyyy-MM-dd HH:mm:ss} - {1}{2}", DateTime.Now, message, Environment.NewLine));

            logRichy.SelectionStart = logRichy.TextLength;
            logRichy.SelectionColor = Color.DarkGray;
            logRichy.AppendText(String.Format("---------------------------------------{0}", Environment.NewLine));

            logRichy.ScrollToCaret();
            logRichy.Invalidate();
            Application.DoEvents();
        }
        #endregion
    }
}
