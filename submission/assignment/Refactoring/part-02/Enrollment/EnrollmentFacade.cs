using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab.Part02.Enrollment;

public class EnrollmentFacade
{
    private readonly EmailService _emailService;
    private readonly SeatInventory _seatInventory;
    private readonly InvoiceGenerator _invoiceGenerator;
    private readonly PaymentGateway _paymentGateway;


    public EnrollmentFacade()
    : this(
        new EmailService(),
        new SeatInventory(),
        new InvoiceGenerator(),
        new PaymentGateway())
    {
    }

    public EnrollmentFacade(EmailService emailService, SeatInventory seatInventory, 
        InvoiceGenerator invoiceGenerator, PaymentGateway paymentGateway)
    {
        _emailService = emailService;
        _seatInventory = seatInventory;
        _invoiceGenerator = invoiceGenerator;
        _paymentGateway = paymentGateway;
    }


    public void EnrollCourse(string studentId,string courseId, decimal amount)
    {
        _paymentGateway.Charge(studentId, amount);
        _seatInventory.Reserve(courseId, studentId);
        var invoiceId = _invoiceGenerator.Create(studentId, amount);
        _emailService.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}
