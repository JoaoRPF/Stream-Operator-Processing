﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using DADStorm;

namespace DADStorm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void execFileClick(object sender, EventArgs e)
        {
            /*string result = PuppetMaster.services.printHello();
            logText.Text += "\r\n" + result;
            sendStuffToPCS();*/
            PuppetMaster.startReadingConfigFile(fileText.Text, false);
        }

        private void sendStuffToPCS()
        {
            string result = PuppetMaster.services.changeInfo("Hello");
            logText.Text += "\r\n" + result;
        }

        public void addNewLineToLog(string line)
        {
            this.BeginInvoke((Action) (() => {
                logText.AppendText("\r\n" + line);
            }));
        }

        public string getFileText()
        {
            return fileText.Text;
        }

        private void stepButton_Click(object sender, EventArgs e)
        {       
             PuppetMaster.startReadingConfigFile(fileText.Text, true);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            PuppetMaster.reset();
        }

        private void execCommandButton_Click(object sender, EventArgs e)
        {
            PuppetMaster.executeCommand(commandText.Text);
            commandText.ResetText();
        }
    }
}
