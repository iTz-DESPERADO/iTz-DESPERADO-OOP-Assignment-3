namespace RefactoringLab;

public class OrderProcessor
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmailSender _emailSender;

    public OrderProcessor(
        IOrderRepository orderRepository,
        IEmailSender emailSender)
    {
        _orderRepository = orderRepository
            ?? throw new ArgumentNullException(nameof(orderRepository));

        _emailSender = emailSender
            ?? throw new ArgumentNullException(nameof(emailSender));
    }

    public void Process(int orderId, string customerEmail)
    {
        var processedAt = DateTime.Now;

        _orderRepository.Save(orderId, processedAt);

        _emailSender.Send(
            customerEmail,
            $"Order {orderId} confirmed at {processedAt}");
    }
}


public interface IOrderRepository
{
    void Save(int orderId, DateTime processedAt);
}


public class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}


public interface IEmailSender
{
     void Send(string to, string body);
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) =>
        Console.WriteLine($"[SMTP] to={to} body={body}");
}
