﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using CONTROL;
using System.Runtime.InteropServices;
using System.Threading;

namespace Projeto_Loc_Senai
{
    public partial class TelaLogin : Form
    {
        Thread f1;
        Thread f2;
        User us = new User();

        public TelaLogin()
        {
            InitializeComponent();
            //Desativa barra superior padrão do Windows
            this.Text = string.Empty;
            this.ControlBox = false;
            // Define o tamanho padrão da tela como 1440x1024 pixels
            this.Size = new Size(1440, 1024);
        }

        //Comando para responsividade da tela
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Fechar Tela
        private void Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Maximar e Minimizar Tela
        private void Janelas_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        //Minimizar Tela
        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Movimentação da Tela
        private void BarraSuperior1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Desocultar Senha da TextBox
        private void OlhoDesocultar_Click(object sender, EventArgs e)
        {
            OlhoOcultar.BringToFront();
            txtsenha_adm.PasswordChar = '\0';
        }

        //Ocultar Senha da TextBox
        private void OlhoOcultar_Click(object sender, EventArgs e)
        {
            OlhoDesocultar.BringToFront();
            txtsenha_adm.PasswordChar = '•';
        }

        //Fechar a Tela Login e Abrir Adm
        private void AbrirJan(object obj)
        {
            Application.Run(new TelaAdm());
        }

        //Fechar a Tela Login e Abrir Visitante
        private void AbrirJan2(object obj)
        {
            Application.Run(new TelaVisitante());
        }

        private void btnlogin_vis_Click(object sender, EventArgs e)
        {
            this.Close();
            f2 = new Thread(AbrirJan2);
            f2.SetApartmentState(ApartmentState.STA);
            f2.Start();
        }

        private void btnlogin_adm_Click(object sender, EventArgs e)
        {
            controller_login control = new controller_login();
            us.setsenha(txtsenha_adm.Text);
            us.setusuario(txtusuario_adm.Text);

            bool logado = control.login(us);
            if (logado == true)
            {
                this.Close();
                f1 = new Thread(AbrirJan);
                f1.SetApartmentState(ApartmentState.STA);
                f1.Start();
            }
            else
            {
                MessageBox.Show("login ou senha incorretos");

            }
           
        }
    }
}
