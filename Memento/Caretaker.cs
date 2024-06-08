namespace Memento;

internal class Caretaker(Originator originator)
{
    private List<IMemento> _mementos = [];

    private Originator _originator = originator;

    public void Backup()
    {
        Console.WriteLine("\nCaretaker: Saving Originator's state...");
        _mementos.Add(_originator.Save());
    }

    public void Undo()
    {
        if (_mementos.Count == 0) return;

        var memento = _mementos.Last();
        _mementos.Remove(memento);

        Console.WriteLine("Caretaker: Restoring state to: " + memento.GetName());

        try
        {
            _originator.Restore(memento);
        }
        catch (Exception)
        {
            Undo();
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("Caretaker: Here's the list of mementos:");

        foreach (var memento in _mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }
}
