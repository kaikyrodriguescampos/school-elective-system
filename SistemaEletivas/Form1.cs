using ClosedXML.Excel;
using System.Data;

namespace SistemaEletivas
{
    public partial class Form1 : Form
    {
        private List<Aluno> listaAlunos = new List<Aluno>();
        private List<Eletivo> listaEletivos = new List<Eletivo>();

        public Form1()
        {
            InitializeComponent();

            listaEletivos.Add(new Eletivo { Nome = "Joice Exploração Cultural", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Thelma Judô", Capacidade = 20 });
            listaEletivos.Add(new Eletivo { Nome = "Jaqueline Teatro", Capacidade = 23 });
            listaEletivos.Add(new Eletivo { Nome = "Adriana Reciclagem", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Lucélia Fashio Math", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Sandra Dança e Capoeira", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Murilo Horta Ensino Médio", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Valdir O Homem que Calculava", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Marcia Quadrinho", Capacidade = 25 });
            listaEletivos.Add(new Eletivo { Nome = "Geovane Preparo de chás Infusões e decoctos", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Mike Música", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Rodrigo Desvendando o passado", Capacidade = 20 });
            listaEletivos.Add(new Eletivo { Nome = "Manoel Matemática e sustentabilidade financeira", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Luiz Gustavo Matemática sem fronteiras: Conexão entre jogos, culturas e raciocínio", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Maraíza Chef Ciêntista", Capacidade = 25 });
            listaEletivos.Add(new Eletivo { Nome = "Karol Revolução Sustentável", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Italo Debates Contemporâneos", Capacidade = 30 });
            listaEletivos.Add(new Eletivo { Nome = "Elisangela Horta Fundamental", Capacidade = 30 });

        }

        private bool AdicionarNoEletivo(Aluno aluno, string nomeEletivo)
        {
            var eletivo = listaEletivos.FirstOrDefault(e => e.Nome == nomeEletivo);

            if (eletivo != null && eletivo.Alunos.Count < eletivo.Capacidade)
            {
                eletivo.Alunos.Add(aluno);
                aluno.EletivaSelecionada = eletivo.Nome;
                return true;
            }

            return false;
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();

                using (var workbook = new XLWorkbook(openFileDialog.FileName))
                {
                    var worksheet = workbook.Worksheet(1);
                    bool primeiraLinha = true;

                    foreach (var row in worksheet.RowsUsed())
                    {
                        if (primeiraLinha)
                        {
                            foreach (var cell in row.Cells())
                                dt.Columns.Add(cell.Value.ToString());

                            primeiraLinha = false;
                        }
                        else
                        {
                            var novaLinha = dt.NewRow();

                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                novaLinha[i] = row.Cell(i + 1).GetValue<string>();
                            }

                            dt.Rows.Add(novaLinha);
                        }
                    }
                }
                dt.Columns.Add("Resultado");

                gridAlunos.DataSource = dt;

                listaAlunos.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    Aluno aluno = new Aluno();

                    aluno.Nome = row["Nome"].ToString();
                    aluno.Turma = row["Turma"].ToString();
                    aluno.Opcao1 = row["Opcao1"].ToString();
                    aluno.Opcao2 = row["Opcao2"].ToString();
                    aluno.Opcao3 = row["Opcao3"].ToString();

                    listaAlunos.Add(aluno);
                }
            }
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            foreach (var eletivo in listaEletivos)
            {
                eletivo.Alunos.Clear();
            }
            var random = new Random();
            listaAlunos = listaAlunos.OrderBy(x => random.Next()).ToList();

            // DISTRIBUIÇÃO
            foreach (var aluno in listaAlunos)
            {
                if (AdicionarNoEletivo(aluno, aluno.Opcao1))
                    continue;

                if (AdicionarNoEletivo(aluno, aluno.Opcao2))
                    continue;

                if (AdicionarNoEletivo(aluno, aluno.Opcao3))
                    continue;
            }

            // MOSTRAR RESULTADO NA TABELA
            for (int i = 0; i < listaAlunos.Count; i++)
            {
                gridAlunos.Rows[i].Cells["Resultado"].Value = listaAlunos[i].EletivaSelecionada;
            }

            // RELATÓRIO DAS ELETIVAS
            string relatorio = "";

            foreach (var eletivo in listaEletivos)
            {
                relatorio += $"{eletivo.Nome} → {eletivo.Alunos.Count}/{eletivo.Capacidade}\n";
            }

            MessageBox.Show(relatorio, "Resumo das Eletivas");

            // ALUNOS SEM VAGA
            var alunosSemVaga = listaAlunos
                .Where(a => string.IsNullOrEmpty(a.EletivaSelecionada))
                .ToList();

            if (alunosSemVaga.Count > 0)
            {
                MessageBox.Show($"{alunosSemVaga.Count} alunos ficaram sem vaga.");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "Resultado_Eletivas.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    foreach (var eletivo in listaEletivos)
                    {
                        string nomeAba = eletivo.Nome.Length > 31
                            ? eletivo.Nome.Substring(0, 31)
                            : eletivo.Nome;

                        var worksheet = workbook.Worksheets.Add(nomeAba);

                        worksheet.Cell(1, 1).Value = "Nome";
                        worksheet.Cell(1, 2).Value = "Turma";

                        int linha = 2;

                        foreach (var aluno in eletivo.Alunos)
                        {
                            worksheet.Cell(linha, 1).Value = aluno.Nome;
                            worksheet.Cell(linha, 2).Value = aluno.Turma;
                            linha++;
                        }
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("Arquivo exportado com sucesso!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}