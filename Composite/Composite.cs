using System;
using System.Collections.Generic;

namespace PatternsCsharp.Composite.Conceptual
{
  abstract class Component
  {
    public Component() { }

    public abstract string Logic();

    public virtual void Add(Component component)
    {
      throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
      throw new NotImplementedException();
    }

    public virtual bool IsComposite()
    {
      return true;
    }
  }

  class Leaf: Component
  {
    public override string Logic()
    {
      return "Leaf";
    }

    public override bool IsComposite()
    {
      return false;
    }
  }

  class Composite: Component
  {
    protected List<Component> _children = new List<Component>();

    public override void Add(Component component)
    {
      this._children.Add(component);
    }

    public override void Remove(Component component)
    {
      this._children.Remove(component);
    }

    public override string Logic()
    {
      int i = 0;
      string result = "Branch(";

      foreach (Component component in this._children)
      {
        result += component.Logic();
        if (i != this._children.Count - 1)
        {
          result += "+";
        }
        i++;
      }

      return result + ")";
    }
  }

  class Client
  {
    public void ClientCode(Component leaf)
    {
      Console.WriteLine($"RESULT: {leaf.Logic()}\n");
    }

    public void ClientCode2(Component c1, Component c2)
    {
      if (c1.IsComposite())
      {
        c1.Add(c2);
      }
      Console.WriteLine($"RESULT: {c1.Logic()}");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Client client = new Client();

      Leaf leaf = new Leaf();
      Console.WriteLine("Client: One leaf:");
      client.ClientCode(leaf);

      Composite tree = new Composite();
      Composite branch1 = new Composite();

      branch1.Add(new Leaf());
      branch1.Add(new Leaf());
      Composite branch2 = new Composite();
      branch2.Add(new Leaf());
      tree.Add(branch1);
      tree.Add(branch2);
      Console.WriteLine("Client: Tree of two branches:");
      client.ClientCode(tree);

      Console.WriteLine("Client: With adding one moar leaf:");
      // client.ClientCode2(tree, leaf);
      client.ClientCode2(tree, branch1);
    }
  }
}