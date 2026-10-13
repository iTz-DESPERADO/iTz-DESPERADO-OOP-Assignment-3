namespace RefactoringLab;

public sealed class UpsShippingCost : IShippingCost
{
    public string Name => "UPS";

    public decimal Calculate(decimal weightKg)
        => weightKg * 20m;
}





