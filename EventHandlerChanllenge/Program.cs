using EventHandlerChanllenge.Model;
using System;

namespace EventHandlerChanllenge
{
  /// <summary>
  /// Implementação de um EventHandler que monitora a mudança dos campos de um objeto
  /// </summary>
  class Program
  {
    // Coisa que será monitorada
    private static Thing thing;

    static void Main(string[] args)
    {
      // Instancia a coisa
      thing = new Thing("Goku", 45, true);

      // Apresenta a coisa
      Console.WriteLine($"O estado inicial da coisa é: {thing.Name}, {thing.Age}, {thing.ActualState()}");

      // Marca a coisa como 'Monitorada'
      thing.guarded = true;

      // Inicia o processo de comuniação com o usuário
      while (true)
      {
        Console.Write("Comando: ");
        CommandHandler(Console.ReadLine());
      }
    }

    /// <summary>
    /// Trata as entradas do usuário no console
    /// </summary>
    /// <param name="command"></param>
    private static void CommandHandler(string command)
    {
      if (command == "Ver coisa")
      {
        Console.WriteLine("Identifiquei que você deseja saber o estado atual da coisa!");
        Console.WriteLine("Muito bem então, vamos lá!");
        Console.WriteLine($"A coisa se chama {thing.Name}.");
        Console.WriteLine($"A idade da coisa é {thing.Age}.");
        Console.WriteLine($"A coisa está {thing.ActualState()}.");
      }
      else if (command == "Mudar nome")
      {
        Console.WriteLine("Identifiquei que você deseja alterar o nome da coisa!");
        Console.Write("Qual será o novo nome? ");
        thing.Name = Console.ReadLine();
      }
      else if (command == "Mudar idade")
      {
        Console.WriteLine("Identifiquei que você deseja alterar a idade da coisa!");
        Console.Write("Qual será a nova idade? ");
        thing.Age = Convert.ToInt32(Console.ReadLine()); // Faltaria validar tipo da entrada
      }
      else if (command == "Matar")
      {
        Console.WriteLine("Identifiquei que você deseja matar a coisa!");
        thing.Alive = false;
      }
      else if (command == "Ressuscitar")
      {
        Console.WriteLine("Identifiquei que você deseja ressuscitar a coisa!");
        thing.Alive = true;
      }
      else if (command == "Exit")
      {
        Console.WriteLine("Identifiquei que você deseja que eu finalize o programa!");
        Console.WriteLine("Tudo bem! Volte sempre!");
        Console.WriteLine("Aperte qualquer tecla para finalizar ...");
        Console.ReadLine();
        Environment.Exit(0);
      }
      else
      {
        Console.WriteLine("Desculpe, não entendi o que você deseja! Tente novamente por gentileza.");
      }
    }
  }
}
