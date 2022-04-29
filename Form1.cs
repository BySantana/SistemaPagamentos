using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula40_wf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Criar um ArrayList
            ArrayList formaPagamento = new ArrayList();
            formaPagamento.Add(new FormaDePagamento(1, "Selecione Opção"));
            formaPagamento.Add(new FormaDePagamento(2, "Dinheiro"));
            formaPagamento.Add(new FormaDePagamento(3, "Cartão"));
            formaPagamento.Add(new FormaDePagamento(4, "Boleto"));
            formaPagamento.Add(new FormaDePagamento(5, "Pix"));
                                        
            // Vincular ao comboBox1
            comboBox1.DataSource = formaPagamento;
            comboBox1.DisplayMember = "Descricao";
            comboBox1.ValueMember = "ID";

        }

        public class FormaDePagamento
        {
            public int ID { get; set; }
            public string Descricao { get; set; }

            public FormaDePagamento(int id, string descricao)
            {
                this.ID = id;
                this.Descricao = descricao;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int escolha = comboBox1.SelectedIndex;

            switch (escolha)
            {
                case 1:
                    lblEscolha.Text = "Dinheiro";
                    textBox1.Visible = false;
                    label3.Visible = false;
                    btnCalcular.Visible = false;
                    break;
                case 2:
                    lblEscolha.Text = "Cartão";
                    label3.Text = "Quantidade de parcelas: ";
                    textBox1.Visible = true;
                    label3.Visible = true;
                    btnCalcular.Visible = true;

                    break;
                case 3:
                    lblEscolha.Text = "Boleto";
                    textBox1.Visible = false;
                    label3.Visible = false;
                    btnCalcular.Visible = false;
                    break;
                case 4:
                    lblEscolha.Text = "Pix";
                    Random rnd = new Random();
                    int numAl = rnd.Next(10000, 90000);
                    textBox1.Text = numAl.ToString();
                    label3.Text = "Chave PIX:";
                    textBox1.Visible = true;
                    label3.Visible = true;
                    btnCalcular.Visible = false;
                    break;
                default:
                    lblEscolha.Text = "";
                    break;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if(double.Parse(txtValor.Text) < 1000)
            {
                if(double.Parse(textBox1.Text) < 5)
                {
                    double parcelas = double.Parse(txtValor.Text) / double.Parse(textBox1.Text);
                    MessageBox.Show($"Serão {double.Parse(textBox1.Text)} parcelas de {parcelas:F2}", "AVISO");
                }
                else
                {
                    MessageBox.Show("Número de parcelas não autorizado.");
                }
            }else if(double.Parse(txtValor.Text) >= 1000)
            {
                if (double.Parse(textBox1.Text) <= 10)
                {
                    double parcelas = double.Parse(txtValor.Text) / double.Parse(textBox1.Text);
                    MessageBox.Show($"Serão {double.Parse(textBox1.Text)} parcelas de R${parcelas:F2}", "AVISO");
                }
                else
                {
                    MessageBox.Show("Número de parcelas não autorizado.");
                }
            }
        }
    }
}
