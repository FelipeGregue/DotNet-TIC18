using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Definindo a estrutura de uma tarefa
    struct Task
    {
        public string Title;
        public string Description;
        public DateTime DueDate;
        public bool IsCompleted;
    }

    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("===== Sistema de Gerenciamento de Tarefas =====");
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-Chave");
            Console.WriteLine("8. Exibir Estatísticas");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTask();
                    break;

                case "2":
                    ListAllTasks();
                    break;

                case "3":
                    MarkTaskAsCompleted();
                    break;

                case "4":
                    ListPendingTasks();
                    break;

                case "5":
                    ListCompletedTasks();
                    break;

                case "6":
                    DeleteTask();
                    break;

                case "7":
                    SearchTasks();
                    break;

                case "8":
                    DisplayStatistics();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CreateTask()
    {
        Console.Write("Digite o título da tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string description = Console.ReadLine();

        Console.Write("Digite a data de vencimento (formato: DD/MM/AAAA): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            tasks.Add(new Task { Title = title, Description = description, DueDate = dueDate, IsCompleted = false });
            Console.WriteLine("Tarefa criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Formato de data inválido. A tarefa não foi criada.");
        }
    }

    static void ListAllTasks()
    {
        Console.WriteLine("===== Lista de Todas as Tarefas =====");
        foreach (var task in tasks)
        {
            Console.WriteLine($"Título: {task.Title}\nDescrição: {task.Description}\nData de Vencimento: {task.DueDate.ToShortDateString()}\nStatus: {(task.IsCompleted ? "Concluída" : "Pendente")}\n");
        }
    }

    static void MarkTaskAsCompleted()
{
    Console.Write("Digite o título da tarefa a ser marcada como concluída: ");
    string title = Console.ReadLine();

    // Encontrar a tarefa na lista de tarefas pendentes
    Task pendingTask = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && !t.IsCompleted);

    if (pendingTask.Title != null)
    {
        // Remover a tarefa da lista de tarefas pendentes
        tasks.Remove(pendingTask);

        // Atualizar o status da tarefa e adicioná-la à lista de tarefas concluídas
        pendingTask.IsCompleted = true;
        tasks.Add(pendingTask);

        Console.WriteLine("Tarefa marcada como concluída!");
    }
    else
    {
        Console.WriteLine("Tarefa não encontrada ou já concluída.");
    }
}

    static void ListPendingTasks()
    {
        Console.WriteLine("===== Lista de Tarefas Pendentes =====");
        foreach (var task in tasks.Where(t => !t.IsCompleted))
        {
            Console.WriteLine($"Título: {task.Title}\nDescrição: {task.Description}\nData de Vencimento: {task.DueDate.ToShortDateString()}\n");
        }
    }

    static void ListCompletedTasks()
    {
        Console.WriteLine("===== Lista de Tarefas Concluídas =====");
        foreach (var task in tasks.Where(t => t.IsCompleted))
        {
            Console.WriteLine($"Título: {task.Title}\nDescrição: {task.Description}\nData de Vencimento: {task.DueDate.ToShortDateString()}\n");
        }
    }

    static void DeleteTask()
    {
        Console.Write("Digite o título da tarefa a ser excluída: ");
        string title = Console.ReadLine();

        Task task = tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (task.Title != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    static void SearchTasks()
    {
        Console.Write("Digite uma palavra-chave para a pesquisa: ");
        string keyword = Console.ReadLine();

        var matchingTasks = tasks.Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"===== Resultados da Pesquisa para '{keyword}' =====");
        foreach (var task in matchingTasks)
        {
            Console.WriteLine($"Título: {task.Title}\nDescrição: {task.Description}\nData de Vencimento: {task.DueDate.ToShortDateString()}\nStatus: {(task.IsCompleted ? "Concluída" : "Pendente")}\n");
        }
    }

    static void DisplayStatistics()
    {
        int completedTasks = tasks.Count(t => t.IsCompleted);
        int pendingTasks = tasks.Count(t => !t.IsCompleted);

        if (tasks.Any())
        {
            Task oldestTask = tasks.OrderBy(t => t.DueDate).First();
            Task newestTask = tasks.OrderByDescending(t => t.DueDate).First();

            Console.WriteLine($"===== Estatísticas =====");
            Console.WriteLine($"Número de Tarefas Concluídas: {completedTasks}");
            Console.WriteLine($"Número de Tarefas Pendentes: {pendingTasks}");
            Console.WriteLine($"Tarefa Mais Antiga:\nTítulo: {oldestTask.Title}\nDescrição: {oldestTask.Description}\nData de Vencimento: {oldestTask.DueDate.ToShortDateString()}");
            Console.WriteLine($"Tarefa Mais Recente:\nTítulo: {newestTask.Title}\nDescrição: {newestTask.Description}\nData de Vencimento: {newestTask.DueDate.ToShortDateString()}");
        }
        else
        {
            Console.WriteLine("Não há tarefas para exibir estatísticas.");
        }
    }
}
