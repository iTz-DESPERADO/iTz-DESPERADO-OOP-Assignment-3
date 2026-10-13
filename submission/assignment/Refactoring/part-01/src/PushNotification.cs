namespace RefactoringLab;

public sealed class PushNotification : INotification
{
    public void Send(
        string to,
        string message,
        DateTime? scheduledAt = null)
    {
        var label = scheduledAt is { } at
            ? $"push scheduled {at:g}"
            : "push";

        Console.WriteLine($"[{label}] {to}: {message}");
    }
}
