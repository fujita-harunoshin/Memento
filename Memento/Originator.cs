namespace Memento;

internal class Originator
{
    private string _state;

    public Originator(string state)
    {
        _state = state;
        Console.WriteLine("Originator: My initial state is: " + state);
    }

    public void DoSomething()
    {
        Console.WriteLine("Originator: I'm doing something important");
        _state = GenerateRandomString(30);
        Console.WriteLine($"Originator: and my state has changed to: {_state}");
    }

    private string GenerateRandomString(int length = 10)
    {
        string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = string.Empty;

        while (length > 0)
        {
            result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

            Thread.Sleep(12);

            length--;
        }

        return result;
    }

    public IMemento Save()
    {
        return new ConcreteMemento(_state);
    }

    public void Restore(IMemento memento)
    {
        if (memento is not ConcreteMemento)
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }

        _state = memento.GetState();
        Console.WriteLine($"Originator: My state has changed to: {_state}");
    }
}
