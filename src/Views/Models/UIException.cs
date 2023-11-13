namespace Views.Models;

public class UIException : Exception
{
    public UIException(string message, object fe, object data)
    {
        Message = message;
        Fe = fe;
        Data = data;
    }

    public string Message { get; }
    public object Fe { get; }
    public object Data { get; }
}
