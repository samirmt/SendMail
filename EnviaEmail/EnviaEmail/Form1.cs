using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnviaEmail
{
    public partial class Form1 : Form
    {
        static string base64String = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDestinatario.Text))
            {
                lblStatus.Text = "enviando...";
                string anexo = "";

                if (!string.IsNullOrEmpty(txtAnexo.Text)) anexo = txtAnexo.Text;


                var retorno = Email.Enviar(txtDestinatario.Text, anexo);
                lblStatus.Text = retorno;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDestinatario.Text = "samir@tidsoftware.com.br";
        }

        private void BtnAnexo_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = true;
            this.ofd1.Title = "Selecionar Fotos";
            ofd1.InitialDirectory = @"C:\Users\macoratti\Pictures";
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtAnexo.Text = ofd1.FileName;
            }
        }
    }
}
