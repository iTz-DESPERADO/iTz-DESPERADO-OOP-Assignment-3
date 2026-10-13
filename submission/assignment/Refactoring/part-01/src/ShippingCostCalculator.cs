namespace RefactoringLab;

public class ShippingCostCalculator
{
    private readonly IReadOnlyDictionary<string, IShippingCost> _shippingCosts;

    public ShippingCostCalculator(IEnumerable<IShippingCost> shippingCosts)
    {

        ArgumentNullException.ThrowIfNull(shippingCosts);

        _shippingCosts = shippingCosts.ToDictionary(
            x => x.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (!_shippingCosts.TryGetValue(carrier, out var strategy))
            throw new ArgumentException(
                $"Unknown carrier: {carrier}");

        return strategy.Calculate(weightKg);
    }
}



public interface IShippingCost
{
    string Name { get; }
    decimal Calculate(decimal weightKg);

}



public sealed class AramexShippingCost : IShippingCost
{
    public string Name => "Aramex";

    public decimal Calculate(decimal weightKg)
    => weightKg * 12m;
}

public sealed class FedExShippingCost : IShippingCost
{
    public string Name => "FedEx";

    public decimal Calculate(decimal weightKg)
    => weightKg * 15m;
}
public sealed class DHLShippingCost : IShippingCost
{
    public string Name => "DHL";

    public decimal Calculate(decimal weightKg)
    => weightKg * 18m;
}





