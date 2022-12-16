using ReferenciaArtigo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form_Principal : Form
    {
        /* Init componentes "deletar"*/
        private readonly CheckBox[] Cbx_Delete = new CheckBox[999];
        private readonly Panel[] Pnl_Delete = new Panel[999];
        /* End componentes "deletar"*/

        /* Init componentes "fazer" */
        private int Fazer_Count = 0;
        private readonly CheckBox[] Cbx_Fazer = new CheckBox[999];
        private readonly Panel[] Pnl_Fazer = new Panel[999];
        /* End componentes "fazer" */

        /* Init componentes "concluido" */
        private int Concluido_Count = 0;
        private readonly CheckBox[] Cbx_Concluido = new CheckBox[999];
        private readonly Panel[] Pnl_Concluido = new Panel[999];
        /* End componentes "concluido" */

        private SQLFunctions cmd = new SQLFunctions();

        public Form_Principal()
        {
            InitializeComponent();
            InitForm();
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Pnl_Fazer[Fazer_Count] = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(282, 28)
            };
            Flp_Afazer.Controls.Add(Pnl_Fazer[Fazer_Count]);

            Cbx_Fazer[Fazer_Count] = new CheckBox
            {
                Location = new Point(4, 4),
                Size = new Size(),
                Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                AutoSize = true,
                Text = Txb_Novo.Text
            };
            Cbx_Fazer[Fazer_Count].CheckedChanged += new EventHandler(Cbx_Concluido_Click);

            Pnl_Fazer[Fazer_Count].Controls.Add(Cbx_Fazer[Fazer_Count]);

            Cbx_Fazer[Fazer_Count].MouseEnter += new EventHandler(MouseEnter);
            Cbx_Fazer[Fazer_Count].MouseLeave += new EventHandler(MouseLeave);

            Fazer_Count++;
            Txb_Novo.Text = "";

            Txb_Novo.Focus();
        }
        private void Cbx_Concluido_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < Fazer_Count; x++)
            {
                if (Cbx_Fazer[x].Checked == true)
                {
                    Pnl_Concluido[Concluido_Count] = new Panel
                    {
                        Location = new Point(10, 10),
                        Size = new Size(282, 28)
                    };
                    Flp_Concluido.Controls.Add(Pnl_Concluido[Concluido_Count]);

                    Cbx_Concluido[Concluido_Count] = new CheckBox
                    {
                        Location = new Point(4, 8),
                        Size = new Size(),
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Strikeout, GraphicsUnit.Point, 0),
                        AutoSize = true,
                        Text = Cbx_Fazer[x].Text,
                        Checked = true
                    };
                    Cbx_Concluido[Concluido_Count].CheckedChanged += new EventHandler(Cbx_Desconcluido_Click);
                    Cbx_Concluido[Concluido_Count].MouseEnter += new EventHandler(MouseEnter);
                    Cbx_Concluido[Concluido_Count].MouseLeave += new EventHandler(MouseLeave);
                    Pnl_Concluido[Concluido_Count].Controls.Add(Cbx_Concluido[Concluido_Count]);

                    Pnl_Delete[Concluido_Count] = new Panel
                    {
                        Location = new Point(230, 4),
                        Size = new Size(60, 25)
                    };
                    Pnl_Concluido[Concluido_Count].Controls.Add(Pnl_Delete[Concluido_Count]);

                    Cbx_Delete[Concluido_Count] = new CheckBox
                    {
                        Location = new Point(-17, 4),
                        Size = new Size(),
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        ForeColor = Color.Red,
                        AutoSize = true,
                        Text = "Delete"
                    };
                    Cbx_Delete[Concluido_Count].Click += new EventHandler(Deleta);
                    Cbx_Delete[Concluido_Count].MouseEnter += new EventHandler(MouseEnter);
                    Cbx_Delete[Concluido_Count].MouseLeave += new EventHandler(MouseLeave);
                    Pnl_Delete[Concluido_Count].Controls.Add(Cbx_Delete[Concluido_Count]);

                    Concluido_Count++;

                    Organiza_Afazer(x);
                    break;
                }
            }
        }
        private void Cbx_Desconcluido_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < Concluido_Count; x++)
            {
                if (Cbx_Concluido[x].Checked == false)
                {
                    Pnl_Fazer[Fazer_Count] = new Panel
                    {
                        Location = new Point(10, 10),
                        Size = new Size(282, 28)
                    };
                    Flp_Afazer.Controls.Add(Pnl_Fazer[Fazer_Count]);

                    Cbx_Fazer[Fazer_Count] = new CheckBox
                    {
                        Location = new Point(4, 4),
                        Size = new Size(),
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        AutoSize = true,
                        Text = Cbx_Concluido[x].Text
                    };
                    Cbx_Fazer[Fazer_Count].CheckedChanged += new EventHandler(Cbx_Concluido_Click);

                    Pnl_Fazer[Fazer_Count].Controls.Add(Cbx_Fazer[Fazer_Count]);

                    Cbx_Fazer[Fazer_Count].MouseEnter += new EventHandler(MouseEnter);
                    Cbx_Fazer[Fazer_Count].MouseLeave += new EventHandler(MouseLeave);

                    Fazer_Count++;

                    Organiza_Concluido(x);
                    break;
                }
            }
        }
        private void Organiza_Afazer(int ind)
        {
            int x;
            for (x = ind; x < Fazer_Count - 1; x++)
            {
                Cbx_Fazer[x].Text = Cbx_Fazer[x + 1].Text;
                Cbx_Fazer[x].Checked = false;
            }

            Pnl_Fazer[Fazer_Count - 1].Controls.Remove(Cbx_Fazer[Fazer_Count - 1]);
            Flp_Afazer.Controls.Remove(Pnl_Fazer[Fazer_Count - 1]);

            Pnl_Fazer[x] = null;
            Cbx_Fazer[x] = null;

            Fazer_Count--;
        }
        private void Organiza_Concluido(int ind)
        {
            int x;
            for (x = ind; x < Concluido_Count - 1; x++)
            {
                Cbx_Concluido[x].Text = Cbx_Concluido[x + 1].Text;
                Cbx_Concluido[x].Checked = true;
            }

            Pnl_Concluido[Concluido_Count - 1].Controls.Remove(Cbx_Concluido[Concluido_Count - 1]);
            Flp_Concluido.Controls.Remove(Pnl_Concluido[Concluido_Count - 1]);

            Pnl_Concluido[x] = null;
            Cbx_Concluido[x] = null;

            Concluido_Count--;
        }
        private void Deleta(object sender, EventArgs e)
        {
            int x, y;

            for (x = 0; x < Concluido_Count; x++)
            {
                if (Cbx_Delete[x].Checked == true)
                {
                    for (y = x; y < Concluido_Count - 1; y++)
                    {
                        Cbx_Concluido[y].Text = Cbx_Concluido[y + 1].Text;
                        Cbx_Delete[y].Checked = false;
                    }

                    Flp_Concluido.Controls.Remove(Pnl_Concluido[y]);

                    Pnl_Concluido[y] = null;
                    Pnl_Delete[y] = null;
                    Cbx_Concluido[y] = null;
                    Cbx_Delete[y] = null;

                    Concluido_Count--;
                }
            }
        }
        private new void MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private new void MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void Form_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmd.Limpa();

            for(int x = 0; x < Fazer_Count; x++)
            {
                cmd.Insere(Cbx_Fazer[x].Text, "Fazer");
            }
            for (int x = 0; x < Concluido_Count; x++)
            {
                cmd.Insere(Cbx_Concluido[x].Text, "Concluido");
            }
        }
        private void InitForm()
        {
            DataTable dt = cmd.Buscar("Fazer");
            if (dt != null)
            {
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    Pnl_Fazer[Fazer_Count] = new Panel
                    {
                        Location = new Point(10, 10),
                        Size = new Size(282, 28)
                    };
                    Flp_Afazer.Controls.Add(Pnl_Fazer[Fazer_Count]);

                    Cbx_Fazer[Fazer_Count] = new CheckBox
                    {
                        Location = new Point(4, 4),
                        Size = new Size(),
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        AutoSize = true,
                        Text = dt.Rows[x]["Texto"].ToString()
                    };
                    Cbx_Fazer[Fazer_Count].CheckedChanged += new EventHandler(Cbx_Concluido_Click);

                    Pnl_Fazer[Fazer_Count].Controls.Add(Cbx_Fazer[Fazer_Count]);

                    Cbx_Fazer[Fazer_Count].MouseEnter += new EventHandler(MouseEnter);
                    Cbx_Fazer[Fazer_Count].MouseLeave += new EventHandler(MouseLeave);

                    Fazer_Count++;
                    Txb_Novo.Text = "";
                }
            }

            dt = cmd.Buscar("Concluido");
            if (dt != null)
            {
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    Pnl_Concluido[Concluido_Count] = new Panel
                    {
                        Location = new Point(10, 10),
                        Size = new Size(282, 28)
                    };
                    Flp_Concluido.Controls.Add(Pnl_Concluido[Concluido_Count]);

                    Cbx_Concluido[Concluido_Count] = new CheckBox
                    {
                        Location = new Point(4, 8),
                        Size = new Size(),
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Strikeout, GraphicsUnit.Point, 0),
                        AutoSize = true,
                        Text = dt.Rows[x]["Texto"].ToString(),
                        Checked = true
                    };
                    Cbx_Concluido[Concluido_Count].CheckedChanged += new EventHandler(Cbx_Desconcluido_Click);
                    Cbx_Concluido[Concluido_Count].MouseEnter += new EventHandler(MouseEnter);
                    Cbx_Concluido[Concluido_Count].MouseLeave += new EventHandler(MouseLeave);
                    Pnl_Concluido[Concluido_Count].Controls.Add(Cbx_Concluido[Concluido_Count]);

                    Pnl_Delete[Concluido_Count] = new Panel
                    {
                        Location = new Point(230, 4),
                        Size = new Size(60, 25)
                    };
                    Pnl_Concluido[Concluido_Count].Controls.Add(Pnl_Delete[Concluido_Count]);

                    Cbx_Delete[Concluido_Count] = new CheckBox
                    {
                        Location = new Point(-17, 4),
                        Size = new Size(),
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        ForeColor = Color.Red,
                        AutoSize = true,
                        Text = "Delete"
                    };
                    Cbx_Delete[Concluido_Count].Click += new EventHandler(Deleta);
                    Cbx_Delete[Concluido_Count].MouseEnter += new EventHandler(MouseEnter);
                    Cbx_Delete[Concluido_Count].MouseLeave += new EventHandler(MouseLeave);
                    Pnl_Delete[Concluido_Count].Controls.Add(Cbx_Delete[Concluido_Count]);

                    Concluido_Count++;
                }
            }
        }
    }
}