using System;

namespace PatternsCsharp.AbstractFactory {
  public interface IInterfaceElementFactory {
    IButton createButton();
    IWindow createWindow();
  }
  public interface IButton {
    void pushButton();
  }

  public interface IWindow {
    void printWidth();
  }

  class WindowsInterfaceElementFactory : IInterfaceElementFactory {
    public IButton createButton() {
      return new WindowsButton("Stock windows button");
    }
    public IWindow createWindow() {
      return new WindowsWindow(1000);
    }
  }

  class MacInterfaceElementFactory : IInterfaceElementFactory
  {
    public IButton createButton()
    {
      return new MacButton("Stock mac button");
    }
    public IWindow createWindow()
    {
      return new MacWindow(500);
    }
  }

  class WindowsButton: IButton
  {
    string name;

    public WindowsButton(string name)
    {
      this.name = name;
    }

    public void pushButton()
    {
      Console.WriteLine("Pushed win-styled button with name " + this.name);
    }
  }

  class WindowsWindow: IWindow
  {
    int width;
    public WindowsWindow(int width)
    {
      this.width = width;
    }
    public void printWidth()
    {
      Console.WriteLine(this.width + " win pixels");
    }
  }

  class MacButton: IButton
  {
    string name;
    public MacButton(string name)
    {
      this.name = name;
    }
    public void pushButton()
    {
      Console.WriteLine("Pushed mac-styled button with name " + this.name);
    }
  }

  class MacWindow: IWindow
  {
    int width;
    public MacWindow(int width)
    {
      this.width = width;
    }
    public void printWidth()
    {
      Console.WriteLine(this.width + " mac pixels :)");
    }
  }

  class Client
  {
    public void Main()
    {
      Console.WriteLine("Testing mac interface...");
      TestInterfaceFactory(new MacInterfaceElementFactory());
      Console.WriteLine();

      Console.WriteLine("Testing windows interface...");
      TestInterfaceFactory(new WindowsInterfaceElementFactory());
      Console.WriteLine();
    }
    public void TestInterfaceFactory(IInterfaceElementFactory interfaceFactory)
    {
      IButton button = interfaceFactory.createButton();
      IWindow window = interfaceFactory.createWindow();

      button.pushButton();
      window.printWidth();
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      new Client().Main();
    }
  }
}