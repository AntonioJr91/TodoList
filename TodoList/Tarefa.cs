namespace TodoList
{
    internal class Tarefa
    {
        private readonly int id;
        public int Id { get => id; }

        private static Random rmd = new();

        private static List<int> idUsados = new();
        private string descricao;
        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        private Prioridade prioridade;
        public Prioridade Prioridade
        {
            get => prioridade;
            set => prioridade = value;
        }

        private StatusTarefa status;
        public StatusTarefa Status
        {
            get => status;
            set => status = value;
        }
        public Tarefa(string descricao, Prioridade prioridade)
        {
            id = GerarId();
            Descricao = descricao;
            Prioridade = prioridade;
            Status = StatusTarefa.Pendente;
        }

        private int GerarId()
        {
            if (idUsados.Count() >= 100)
            {
                throw new InvalidOperationException("Você atingiu o limite de tarefas.");
            }
            int novoId;
            do
            {
                novoId = rmd.Next(1, 101);
            } while (idUsados.Contains(novoId));

            idUsados.Add(novoId);
            return novoId;
        }
    }
}
