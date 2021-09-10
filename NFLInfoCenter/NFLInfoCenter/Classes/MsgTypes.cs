using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLInfoCenter.Classes
{
    public static class MsgTypes
    {
        public static int msg_success = 1;
        public static int msg_failure = 2;
        public static int msg_nottype = 0;
        
        /// <summary>
        /// Prints message to "prompt" (RichTextBox control) and adds messageType tag.
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <param name="sender"></param>
        /// <param name="prompt"></param>
        public static void printme(int messageType, string message, System.Windows.Forms.Form sender, System.Windows.Forms.RichTextBox prompt = null)
        {

            if (prompt == null)
            {
                foreach (System.Windows.Forms.Control  c in sender.Controls)
                {
                    //Console.WriteLine("checking control: " + c.Name);
                    if(c.Name == "prompt")
                    {
                        prompt = (System.Windows.Forms.RichTextBox)c;
                        break;
                    }
                    foreach (System.Windows.Forms.Control d in c.Controls)
                    {
                        if (d.Name == "prompt")
                        {
                            prompt = (System.Windows.Forms.RichTextBox)d;
                            break;
                        }
                        foreach (System.Windows.Forms.Control e in d.Controls)
                        {
                            if (e.Name == "prompt")
                            {
                                prompt = (System.Windows.Forms.RichTextBox)e;
                                break;
                            }
                        }
                    }

                }

                if(prompt == null)
                {
                    string msg = "The current window has no prompt.";
                    System.Windows.Forms.MessageBox.Show(msg, "Warning",System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }
             
            }
       


            switch (messageType)
            {
                case 0:
                    prompt.AppendText(message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
                case 1:
                    prompt.AppendText("success >> " + message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
                case 2:
                    prompt.AppendText("failure >> " + message + System.Environment.NewLine);
                    prompt.ScrollToCaret();
                    break;
            }
        }

    }
}
