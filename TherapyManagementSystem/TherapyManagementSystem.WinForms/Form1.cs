using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TherapyManagementSystem.WinForms;
using TherapyManagementSystem.WinForms.Properties;

namespace TherapyManagementSystem.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (CheckIfLoginWasSaved())
            //{
            //    var username = Settings.Default.Username;
            //    var password = Settings.Default.Password;
            //    var secretPhrase = Settings.Default.SecretPhrase;

            //    VerifySecretPhrase(secretPhrase);
            //}
            //else
            //{
            //    Application.Run(new LoginForm());
            //}
        }

        //private void VerifySecretPhrase(string secretPhrase)
        //{
        //    DialogResult result = DialogResult.Retry;
        //    while (result == DialogResult.Retry)
        //    {
        //        var secretPhraseAttempt = Interaction.InputBox("Escreva a sua frase secreta para verificação:", "Verificação");

        //        if (!string.Equals(secretPhraseAttempt, secretPhrase, StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            result = MessageBox.Show("Frase errada.", "Erro", MessageBoxButtons.AbortRetryIgnore);

        //            if (result == DialogResult.Abort)
        //            {
        //                Close();
        //                Dispose();
        //            }
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //}

        //private bool CheckIfLoginWasSaved()
        //{
        //    return !string.IsNullOrWhiteSpace(Settings.Default.Username) || !string.IsNullOrWhiteSpace(Settings.Default.Password) || !string.IsNullOrWhiteSpace(Settings.Default.SecretPhrase);
        //}
    }
}
