namespace SistemaEletivas
{
    public class Eletivo
    {
        public string Nome { get; set; }
        public int Capacidade { get; set; }

        public List<Aluno> Alunos = new List<Aluno>();
    }
}