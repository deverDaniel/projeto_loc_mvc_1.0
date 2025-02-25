﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Loc_Senai.FormsAdm
{
    public partial class TelaCadastroEvento : Form
    {
        public TelaCadastroEvento()
        {
            InitializeComponent();
            //Desativa barra superior padrão do Windows
            this.Text = string.Empty;
            this.ControlBox = false;
            // Define o tamanho padrão da tela como 900x600 pixels
            this.MaximumSize = new Size(900, 600);
            this.MinimumSize = new Size(700, 575);
        }

        //Comando para responsividade da tela
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PainelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
