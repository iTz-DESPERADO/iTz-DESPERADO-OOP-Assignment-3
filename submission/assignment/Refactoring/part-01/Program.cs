using RefactoringLab;

var shipping = new ShippingCostCalculator(
    new IShippingCost[]
    {
        new AramexShippingCost(),
        new FedExShippingCost(),
        new DHLShippingCost(),
        new UpsShippingCost() // new one
    });

Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"Ups 2kg    → {shipping.Calculate("Ups", 2)}"); // new Shipping Cost
Console.WriteLine();



IOrderRepository orderRepository = new SqlOrderRepository();  // we can change this with another provider of database 
IEmailSender emailSender = new SmtpEmailSender();   // we can change the provider of email sender

var processor = new OrderProcessor(orderRepository, emailSender);
processor.Process(1001, "customer@example.com");
Console.WriteLine();


var sendAt = DateTime.Today.AddHours(18);


INotification urgentScheduledEmail =
    new ScheduledNotification(
        new UrgentNotification(
            new EmailNotification()
        ),
        sendAt
    );

urgentScheduledEmail.Send(
    "customer@example.com",
    "Your order ships tomorrow"
);


INotification urgentSms =
    new UrgentNotification(
        new SmsNotification()
    );

urgentSms.Send("+201000000000", "OTP 4821");




INotification push = new PushNotification();  // new Channel of Notificaiton 

push.Send(
    "Gamalkhaled@gmail.com",
    "Your order has been confirmed");


INotification urgentPush =
    new UrgentNotification(
        new PushNotification());

urgentPush.Send(
    "Gamalkhaled@gmail.com",
    "Security alert!");


INotification scheduledPush =
    new ScheduledNotification(
        new PushNotification(),
        sendAt);

scheduledPush.Send(
    "Gamalkhaled@gmail.com",
    "Your order ships tomorrow");


INotification urgentScheduledPush =
    new ScheduledNotification(
        new UrgentNotification(
            new PushNotification()),
        sendAt);

urgentScheduledPush.Send(
    "Gamalkhaled@gmail.com",
    "Important delivery update!");

// The same two decorators work with every channel, in any combination.
Console.WriteLine("\n=== Every channel: urgent, scheduled, both ===");
foreach (var channel in new INotification[]
         { new EmailNotification(), new SmsNotification(), new PushNotification() })
{
    new UrgentNotification(channel).Send("demo-recipient", "Urgent only");
    new ScheduledNotification(channel, sendAt).Send("demo-recipient", "Scheduled only");
    new ScheduledNotification(new UrgentNotification(channel), sendAt)
        .Send("demo-recipient", "Urgent and scheduled");
}
