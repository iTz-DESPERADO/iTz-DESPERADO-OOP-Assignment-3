namespace RefactoringLab;

public interface INotification
{
    void Send(
        string to,
        string message,
        DateTime? scheduledAt = null);
}

public sealed class EmailNotification : INotification
{
    public void Send(
        string to,
        string message,
        DateTime? scheduledAt = null)
    {
        var label = scheduledAt is { } at
            ? $"email scheduled {at:g}"
            : "email";

        Console.WriteLine($"[{label}] {to}: {message}");
    }
}

public sealed class SmsNotification : INotification
{
    public void Send(
        string to,
        string message,
        DateTime? scheduledAt = null)
    {
        var label = scheduledAt is { } at
            ? $"sms scheduled {at:g}"
            : "sms";

        Console.WriteLine($"[{label}] {to}: {message}");
    }
}


public sealed class UrgentNotification : INotification
{
    private readonly INotification _inner;

    public UrgentNotification(INotification inner)
    {
        _inner = inner;
    }

    public void Send(
        string to,
        string message,
        DateTime? scheduledAt = null)
    {
        _inner.Send(
            to,
            $"[URGENT] {message}",
            scheduledAt);
    }
}

public sealed class ScheduledNotification : INotification
{
    private readonly INotification _inner;
    private readonly DateTime _sendAt;

    public ScheduledNotification(
        INotification inner,
        DateTime sendAt)
    {
        _inner = inner;
        _sendAt = sendAt;
    }

    public void Send(
        string to,
        string message,
        DateTime? scheduledAt = null)
    {
        _inner.Send(to, message, _sendAt);
    }
}