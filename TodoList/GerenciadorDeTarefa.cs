using System;
using System.Collections.Generic;

namespace TodoList
{
    internal class GerenciadorDeTarefa
    {
        private List<Tarefa> listaDeTarefas = new();
        public void AdicionarTarefa()
        {
            Console.Clear();
            Console.WriteLine("### Adicionando uma nova tarefa ###\n");
            Console.Write("Digite o nome da tarefa: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a prioridade da tarefa (0 = Baixa, 1 = Média, 2 = Alta): ");
            bool parseOk = int.TryParse(Console.ReadLine(), out int prioridadeInt);

            if (!parseOk || prioridadeInt < 0 || prioridadeInt > 2)
            {
                Console.WriteLine("Prioridade inválida!");
                return;
            }

            Prioridade prioridade = (Prioridade)prioridadeInt;

            Tarefa novaTarefa = new(descricao, prioridade);

            listaDeTarefas.Add(novaTarefa);
            Console.WriteLine("\nTarefa criada com sucesso!");
        }

        public void ListarTarefas()
        {
            Console.Clear();
            Console.WriteLine("### Lista de Tarefas ###\n");
            if (listaDeTarefas.Count() < 1)
            {
                Console.WriteLine("Lista de tarefas vazia!");
                return;
            }
            Console.WriteLine("{0,-5} | {1,-30} | {2,-10} | {3,-10}", "ID", "Descrição", "Prioridade", "Status");
            foreach (Tarefa tarefa in listaDeTarefas)
            {
                Console.WriteLine("{0,-5} | {1,-30} | {2,-10} | {3,-10}", tarefa.Id, tarefa.Descricao, tarefa.Prioridade, tarefa.Status);
            }
        }
        public void EditarTarefa()
        {
            Console.Clear();
            Console.WriteLine("### Editando uma tarefa ###\n");

            if (listaDeTarefas.Count < 1)
            {
                Console.WriteLine("Não existe tarefa.");
                return;
            }

            ListarTarefas();
            Console.Write("\nDigite o ID da tarefa que você deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool tarefaExiste = listaDeTarefas.Any(tarefa => tarefa.Id == id);

            if (!tarefaExiste)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            Tarefa tarefa = listaDeTarefas.Find(tarefa => tarefa.Id == id);

            Console.WriteLine("\nO que deseja alterar? ");
            Console.WriteLine("1. Descrição");
            Console.WriteLine("2. Propriedade");
            Console.WriteLine("3. Status");
            Console.WriteLine("4. Todos");
            Console.Write("\nDigite sua opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    EdtarDescricao(tarefa);
                    break;
                case "2":
                    EditarPrioridade(tarefa);
                    break;
                case "3":
                    EditarStatus(tarefa);
                    break;
                case "4":
                    EditarTodas(tarefa);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
        public void DeletarTarefa()
        {
            Console.Clear();
            Console.WriteLine("\n### Deletando tarefa ###");
            if (listaDeTarefas.Count() < 1)
            {
                Console.WriteLine("\nLista de tarefas vazia.");
                return;
            }

            ListarTarefas();
            Console.Write("\nDigite o ID da tarefa que deseja remover: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Tarefa tarefa = listaDeTarefas.Find(tarefa => tarefa.Id == id);

            if (!listaDeTarefas.Contains(tarefa))
            {
                Console.WriteLine("Tarefa inválida.");
            }
            else if (Validacao() == true)
            {
                listaDeTarefas.Remove(tarefa);
                Console.WriteLine("\nTarefa removida.");
            }
        }
        public static void EdtarDescricao(Tarefa tarefa)
        {
            Console.Write("Digite a nova descrição da tarefa: ");
            string? novaDescricao = Console.ReadLine();

            if (novaDescricao == "")
            {
                Console.WriteLine("Digite uma descrição válida.");
                return;
            }
            else
            {
                tarefa.Descricao = novaDescricao;
                Console.WriteLine("Descrição de tarefa alterada com sucesso!");
            }
        }
        public static void EditarPrioridade(Tarefa tarefa)
        {
            Console.Write("Digite a nova prioridade da tarefa (0 = Baixa, 1 = Média, 2 = Alta): ");
            int novaPrioridade = Convert.ToInt32(Console.ReadLine());

            if (novaPrioridade > 2)
            {
                Console.WriteLine("Selecione uma prioridade válida.");
                return;
            }
            else
            {
                tarefa.Prioridade = (Prioridade)novaPrioridade;
                Console.WriteLine("Prioridade da tarefa alterada com sucesso!");
            }
        }
        public static void EditarStatus(Tarefa tarefa)
        {
            Console.Write("Digite o novo status da tarefa (0 = Pendente, 1 = Concluída): ");
            int novoStatus = Convert.ToInt32(Console.ReadLine());

            if (novoStatus > 2)
            {
                Console.WriteLine("Selecione um status válido.");
                return;
            }
            else
            {
                tarefa.Status = (StatusTarefa)novoStatus;
                Console.WriteLine("Status da tarefa alterada com sucesso!");
            }
        }
        public static void EditarTodas(Tarefa tarefa)
        {
            Console.Write("\nDigite a nova descrição da tarefa: ");
            string? novaDescricao = Console.ReadLine();

            Console.Write("Digite a nova prioridade da tarefa (0 = Baixa, 1 = Média, 2 = Alta): ");
            int novaPrioridade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o novo status da tarefa (0 = Pendente, 1 = Concluída): ");
            int novoStatus = Convert.ToInt32(Console.ReadLine());



            if (novaDescricao == "")
            {
                Console.WriteLine("Digite uma descrição válida.");
                return;
            }
            else if (novaPrioridade > 2)
            {
                Console.WriteLine("Selecione uma prioridade válida.");
                return;
            }
            else if (novoStatus > 2)
            {
                Console.WriteLine("Selecione um status válido.");
                return;
            }
            else
            {
                tarefa.Descricao = novaDescricao;
                tarefa.Prioridade = (Prioridade)novaPrioridade;
                tarefa.Status = (StatusTarefa)novoStatus;
                Console.WriteLine("\nTarefa alterada com sucesso!");
            }
        }

        private bool Validacao()
        {
            Console.Write("\nVocê tem certeza que deseja remover esta tarefa? ");
            string? confirmacao = Console.ReadLine();

            if (confirmacao != "sim")
            {
                return false;
            }

            return true;
        }
    }
}
