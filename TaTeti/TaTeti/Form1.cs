using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaTeti
{
    public partial class Form1 : Form
    {
        List<Button> listaBotones = new List<Button>();
        int Turno = 0;
        int Movimientos = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CrearControles();
            ActualizarlblTurno();
        }

        void CrearControles()
        {
            int left = 50;
            int top = 50;
            
            for (int i = 0; i < 9; i++)
            {
                var boton = new Button();
                boton.Width = 80;
                boton.Height = 80;
                boton.Font = new Font(new FontFamily("Verdana"), 18);
                boton.Visible = true;
                boton.Left = left;
                boton.Top = top;
                boton.Click += OnClickBoton;

                left += 150;

                if(i == 2 || i == 5)
                {
                    top += 150;
                    left = 50;
                }

                listaBotones.Add(boton);
                this.Controls.Add(boton);
            }
        }

        void OnClickBoton(object sender, EventArgs eventArgs)
        {
            Button boton = (Button)sender;
            if (string.IsNullOrEmpty(boton.Text) && !CheckGanador()) 
            {
                boton.Text = Turno == 0 ? "X" : "O";
                if (CheckGanador())
                {
                    if (MessageBox.Show($"Gano el jugador: {Turno + 1}. Desea Jugar de nuevo ", "Ganador", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ReiniciarJuego();
                    }
                }
                else
                {   
                    if(Movimientos < 8 ) { 
                    Turno = Turno == 0 ? 1 : 0;
                    ActualizarlblTurno();
                    Movimientos ++;
                    }else
                    {
                        if (MessageBox.Show($"Hubo un empate. Desea Jugar de nuevo ", "Empate", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ReiniciarJuego();
                        }
                    }
                }
            }   
        }

        void ActualizarlblTurno()
        {
            lblTurno.Text = "Turno: Jugador " + (Turno + 1);
        }

        bool CheckGanador()
        {
            if ((!string.IsNullOrEmpty(listaBotones[0].Text) && listaBotones[0].Text == listaBotones[1].Text && listaBotones[1].Text == listaBotones[2].Text)
               || (!string.IsNullOrEmpty(listaBotones[3].Text) && listaBotones[3].Text == listaBotones[4].Text && listaBotones[4].Text == listaBotones[5].Text)
               || (!string.IsNullOrEmpty(listaBotones[6].Text) && listaBotones[6].Text == listaBotones[7].Text && listaBotones[7].Text == listaBotones[8].Text)
               || (!string.IsNullOrEmpty(listaBotones[0].Text) && listaBotones[0].Text == listaBotones[3].Text && listaBotones[3].Text == listaBotones[6].Text)
               || (!string.IsNullOrEmpty(listaBotones[1].Text) && listaBotones[1].Text == listaBotones[4].Text && listaBotones[4].Text == listaBotones[7].Text)
               || (!string.IsNullOrEmpty(listaBotones[2].Text) && listaBotones[2].Text == listaBotones[5].Text && listaBotones[5].Text == listaBotones[8].Text)
               || (!string.IsNullOrEmpty(listaBotones[0].Text) && listaBotones[0].Text == listaBotones[4].Text && listaBotones[4].Text == listaBotones[8].Text)
               || (!string.IsNullOrEmpty(listaBotones[2].Text) && listaBotones[2].Text == listaBotones[4].Text && listaBotones[4].Text == listaBotones[6].Text))
            {
                return true; 
            }
            return false;
        }

        private void ReiniciarJuego()
        {
            Turno = 0;
            Movimientos = 0;

            for (int i = 0; i < 9; i++)
            {
                listaBotones[i].Text = "";
            }

            ActualizarlblTurno();
        }

        private void lblMovimientos_Click(object sender, EventArgs e)
        {

        }
    }
}
