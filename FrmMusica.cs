using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO3C24_14
{
    public partial class FrmMusica : Form
    {
        public FrmMusica()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            ,
        }

        private void FrmMusica_Load(object sender, EventArgs e)
        {

        }
    }

    private void FrmMusica_Load(object sender, EventArgs e)
    {
        GridMusicas.DataSource = objbll.ListarMusicas();
    }

    DTO_24_14 objdto = new DTO_24_14();
    BLL_24_14 objbll = new BLL_24_14();

    private void btnConfirmar_Click(object sender, EventArgs e)
    {
        try
        {
            objdto.Idmusica = int.Parse(txt_musica.Text);
            objdto.Nome = txtNomeMusica.Text.Trim();
            objdto.NomeAutor = txtAutor.Text.Trim();
            objdto.Idgravadora = int.Parse(txt_gravadora.Text.Trim());
            objdto.IdCD = int.Parse(txt_CD.Text.Trim());

            GridMusicas.DataSource = objbll.ListarMusicas();


            if (objbll.Autenticar(objdto.Idmusica, objdto.Nome, objdto.NomeAutor, objdto.Idgravadora, objdto.IdCD))
            {
                MessageBox.Show("Música localizada no banco de dados");
            }
            else
            {
                MessageBox.Show("Esta música não foi localizada no banco de dados");
            }
        }
        catch (FormatException fe)
        {
            MessageBox.Show("Erro: \n" + fe.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception fe)
        {
            MessageBox.Show(fe.Message);
        }


    }

    private void txt_gravadora_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void btnAdicionar_Click(object sender, EventArgs e)
    {
        try
        {
            objdto.Idmusica = int.Parse(txt_musica.Text);
            objdto.Nome = txtNomeMusica.Text;
            objdto.NomeAutor = txtAutor.Text;
            objdto.Idgravadora = int.Parse(txt_gravadora.Text);
            objdto.IdCD = int.Parse(txt_CD.Text);

            GridMusicas.DataSource = objbll.ListarMusicas();
            objbll.AdicionarMusica(objdto);
            MessageBox.Show("Música adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void btnDeletar_Click(object sender, EventArgs e)
    {
        try
        {
            objdto.Idmusica = int.Parse(txt_musica.Text);
            objdto.Nome = txtNomeMusica.Text;
            objdto.NomeAutor = txtAutor.Text;
            objdto.Idgravadora = int.Parse(txt_gravadora.Text);
            objdto.IdCD = int.Parse(txt_CD.Text);

            GridMusicas.DataSource = objbll.ListarMusicas();
            objbll.ExcluirMusica(objdto);
            MessageBox.Show("Música deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void GridMusicas_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        txt_musica.Text = GridMusicas.Rows[e.RowIndex].Cells[0].Value.ToString();
        txtNomeMusica.Text = GridMusicas.Rows[e.RowIndex].Cells[1].Value.ToString();
        txtAutor.Text = GridMusicas.Rows[e.RowIndex].Cells[2].Value.ToString();
        txt_gravadora.Text = GridMusicas.Rows[e.RowIndex].Cells[3].Value.ToString();
        txt_CD.Text = GridMusicas.Rows[e.RowIndex].Cells[4].Value.ToString();
        this.btnDeletar.Enabled = true;
        this.btnAlterar.Enabled = true;
    }


    private void btnAlterar_Click(object sender, EventArgs e)
    {
        try
        {
            objdto.Idmusica = int.Parse(txt_musica.Text);
            objdto.Nome = txtNomeMusica.Text;
            objdto.NomeAutor = txtAutor.Text;
            objdto.Idgravadora = int.Parse(txt_gravadora.Text);
            objdto.IdCD = int.Parse(txt_CD.Text);

            GridMusicas.DataSource = objbll.ListarMusicas();
            objbll.AlterarMusica(objdto);
            MessageBox.Show("Música alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        txt_musica.Text = "0";
        txtNomeMusica.Clear();
        txtAutor.Clear();
        txt_gravadora.Text = "";
        txt_CD.Text = "";

        this.btnDeletar.Enabled = false;
    }
}


