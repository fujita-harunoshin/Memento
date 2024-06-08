namespace Memento;

internal interface IMemento
{
    string GetName();

    string GetState();

    DateTime GetDate();
}
