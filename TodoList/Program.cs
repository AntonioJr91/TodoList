using TodoList;

Console.WriteLine("### To Do List ###");

GerenciadorDeTarefa gerenciador = new();

int continuar = 1;
while (continuar == 1)
{
    Console.WriteLine("---------- Mennu ----------");
    Console.WriteLine("1. Adicionar Tarefa");
    Console.WriteLine("2. Listar Tarefas");
    Console.WriteLine("3. Editar Tarefa");
    Console.WriteLine("4. Remover Tarefa");
    Console.WriteLine("0. Sair");
    Console.WriteLine("---------------------------");
    Console.Write("\nEscolha uma opção: ");
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            gerenciador.AdicionarTarefa();
            RetornarAoMenu();
            break;

        case "2":
            gerenciador.ListarTarefas();
            RetornarAoMenu();
            break;
        case "3":
            gerenciador.EditarTarefa();
            RetornarAoMenu();
            break;
        case "4":
            gerenciador.DeletarTarefa();
            RetornarAoMenu();
            break;
        case "0":
            Console.WriteLine("\nProgramada encerrado!");
            continuar = 0;
            break;
        default:
            Console.Write("\nOpção inválida!");
            Thread.Sleep(1000);
            Console.Clear();
            break;
    }
}

static void RetornarAoMenu()
{
    Console.Write("\nPressione qualquer tecla para voltar ao menu principal . . . ");
    Console.ReadKey();
    Console.Clear();
}