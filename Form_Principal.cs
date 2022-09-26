using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form_Principal : Form
    {
        private int Cbx_Fazer_Count = 0;
        private int Cbx_Concluido_Count = 0;
        private int Pnl_Fazer_Count = 0;
        private int Pnl_Concluido_Count = 0;
        private int Btn_Delete_count = 0;

        private readonly Button[] Bc = new Button[999];
        private readonly CheckBox[] Cf = new CheckBox[999];
        private readonly Panel[] Nf = new Panel[999];
        private readonly CheckBox[] Cc = new CheckBox[999];
        private readonly Panel[] Nc = new Panel[999];

        public Form_Principal()
        {
            InitializeComponent();
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Nf[Pnl_Fazer_Count] = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(282, 28)
            };
            Flp_Afazer.Controls.Add(Nf[Pnl_Fazer_Count]);

            Cf[Cbx_Fazer_Count] = new CheckBox
            {
                Location = new Point(4, 4),
                Size = new Size(),
                Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                AutoSize = true,
                Text = Txb_Novo.Text
            };
            Cf[Cbx_Fazer_Count].CheckedChanged += new EventHandler(Cbx_Acao);

            Nf[Pnl_Fazer_Count].Controls.Add(Cf[Cbx_Fazer_Count]);

            Cf[Cbx_Fazer_Count].MouseEnter += new EventHandler(MouseEnter);
            Cf[Cbx_Fazer_Count].MouseLeave += new EventHandler(MouseLeave);

            Cbx_Fazer_Count++;
            Pnl_Fazer_Count++;
            Txb_Novo.Text = "";

            Txb_Novo.Focus();
        }
        private void Cbx_Acao(object sender, EventArgs e)
        {
            for (int x = 0; x < Cbx_Fazer_Count; x++)
            {
                if (Cf[x].Checked == true)
                {
                    Nc[Pnl_Concluido_Count] = new Panel
                    {
                        Location = new Point(10, 10),
                        Size = new Size(282, 28)
                    };
                    Flp_Concluido.Controls.Add(Nc[Pnl_Concluido_Count]);

                    Cc[Cbx_Concluido_Count] = new CheckBox
                    {
                        Location = new Point(4, 8),
                        Size = new Size(),
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Strikeout, GraphicsUnit.Point, 0),
                        AutoSize = true,
                        Text = Cf[x].Text,
                        Checked = true
                    };

                    Bc[Btn_Delete_count] = new Button
                    {
                        Location = new Point(235, 4),
                        Font = new Font("Microsoft Sans Serif", 8.00F, FontStyle.Underline, GraphicsUnit.Point, 0),
                        ForeColor = Color.Red,
                        Text = "X",
                        UseVisualStyleBackColor = true,
                        Size = new Size(23, 23),
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.OK
                    };
                    Bc[Btn_Delete_count].Click += new EventHandler(Deleta);
                    Bc[Btn_Delete_count].MouseEnter += new EventHandler(MouseEnter);
                    Bc[Btn_Delete_count].MouseLeave += new EventHandler(MouseLeave);

                    Cc[Cbx_Concluido_Count].MouseEnter += new EventHandler(MouseEnter);
                    Cc[Cbx_Concluido_Count].MouseLeave += new EventHandler(MouseLeave);

                    Nc[Pnl_Concluido_Count].Controls.Add(Cc[Cbx_Concluido_Count]);
                    Nc[Pnl_Concluido_Count].Controls.Add(Bc[Btn_Delete_count]);

                    Cbx_Concluido_Count++;
                    Pnl_Concluido_Count++;
                    Btn_Delete_count++;

                    Organiza(x);
                    break;
                }
            }
        }
        private void Organiza(int ind)
        {
            int x;
            for (x = ind; x < Cbx_Fazer_Count - 1; x++)
            {
                Cf[x].Text = Cf[x + 1].Text;
                Cf[x].Checked = false;
            }

            Nf[Pnl_Fazer_Count - 1].Controls.Remove(Cf[Cbx_Fazer_Count - 1]);
            Flp_Afazer.Controls.Remove(Nf[Pnl_Fazer_Count - 1]);

            Nf[x] = null;
            Cf[x] = null;

            Pnl_Fazer_Count--;
            Cbx_Fazer_Count--;
        }
        private void Deleta(object sender, EventArgs e)
        {
            
        }
        private new void MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private new void MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}