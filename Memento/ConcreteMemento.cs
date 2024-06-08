namespace Memento;

internal class ConcreteMemento(string state) : IMemento
{
    private string _state = state;

    private DateTime _date = DateTime.Now;

    public string GetState()
    {
        return _state;
    }

    public string GetName()
    {
        return $"{_date} / ({_state.Substring(0, 9)})...";
    }

    public DateTime GetDate()
    {
        return _date;
    }
}
