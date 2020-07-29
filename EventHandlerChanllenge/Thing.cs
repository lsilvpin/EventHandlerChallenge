using System;

namespace EventHandlerChanllenge.Model
{
  class Thing
  {
    // Atributos
    private string _name;
    private int _age;
    private bool _alive;

    /// <summary>
    /// Constrói a coisa com suas características iniciais
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Idade</param>
    /// <param name="alive">Estado de vida</param>
    public Thing(string name, int age, bool alive)
    {
      _name = name;
      _age = age;
      _alive = alive;
    }

    // Monitorada?
    public bool guarded { get; set; }

    // Propriedades
    public string Name
    {
      get { return _name; }
      set
      {
        if (guarded)
        {
          string oldName = _name;
          _name = value;

          if (oldName != _name)
          {
            OnNameChange(oldName, _name);
          }
          else
          {
            Console.WriteLine("Ops! O nome que você inseriu já é o nome da coisa!");
          }
        }
        else
        {
          _name = value;
        }
      }
    }
    public int Age
    {
      get { return _age; }
      set
      {
        if (guarded)
        {
          int oldAge = _age;
          _age = value;

          if (oldAge != _age)
          {
            OnAgeChange(oldAge, _age);
          }
          else
          {
            Console.WriteLine("Ops! A idade que você inseriu já é a idade da coisa!");
          }
        }
        else
        {
          _age = value;
        }
      }
    }
    public bool Alive
    {
      get { return _alive; }
      set
      {
        if (guarded)
        {
          bool oldAlive = _alive;
          _alive = value;

          if (oldAlive != _alive)
          {
            OnAliveChange(_alive);
          }
          else
          {
            if (value)
            {
              Console.WriteLine("Amigo, não se ressuscita o que já está vivo!");
            }
            else
            {
              Console.WriteLine("Amigo, não se mata o que já está morto!");
            }
          }
        }
        else
        {
          _alive = value;
        }
      }
    }

    /// <summary>
    /// Traduz para o português o estado de vida da coisa
    /// </summary>
    /// <returns></returns>
    public string ActualState()
    {
      if (Alive)
      {
        return "Viva";
      }
      else
      {
        return "Morta";
      }
    }

    // Quando a instância está sendo monitorada
    #region EventHandler
    /// <summary>
    /// Quando o nome é alterado
    /// </summary>
    private void OnNameChange(string oldName, string newName)
    {
      Console.WriteLine($"O nome foi alterado de {oldName} para {newName}!");
    }
    /// <summary>
    /// Quando a idade é alterada
    /// </summary>
    private void OnAgeChange(int oldAge, int newAge)
    {
      Console.WriteLine($"A idade foi alterada de {oldAge} para {newAge}!");
    }
    /// <summary>
    /// Quando a vida é tirada
    /// </summary>
    private void OnAliveChange(bool actualState)
    {
      string result = (actualState) ? "ressuscitada" : "assassinada";
      Console.WriteLine($"A coisa foi {result}!");
    }
    #endregion
  }
}
