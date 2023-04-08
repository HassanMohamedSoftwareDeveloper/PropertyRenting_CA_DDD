namespace PropertyRenting.Domain.Enums;

public abstract class PaymentMethod : Enumeration<PaymentMethod>
{
    public static readonly PaymentMethod Monthly = new MonthlyPaymentMethod();
    public static readonly PaymentMethod Quarter = new QuarterPaymentMethod();
    public static readonly PaymentMethod TwoMonths = new TwoMonthsPaymentMethod();
    public static readonly PaymentMethod HalfYear = new HalfYearPaymentMethod();
    public static readonly PaymentMethod Yearly = new YearlyPaymentMethod();


    protected PaymentMethod(int value, string name) : base(value, name)
    {
    }
    public abstract int PaymentPeriod { get; }

    private sealed class MonthlyPaymentMethod : PaymentMethod
    {
        public MonthlyPaymentMethod() : base(1, "Monthly")
        {
        }
        public override int PaymentPeriod => 1;
    }
    private sealed class QuarterPaymentMethod : PaymentMethod
    {
        public QuarterPaymentMethod() : base(2, "Quarter")
        {
        }
        public override int PaymentPeriod => 3;
    }
    private sealed class TwoMonthsPaymentMethod : PaymentMethod
    {
        public TwoMonthsPaymentMethod() : base(3, "TwoMonths")
        {
        }
        public override int PaymentPeriod => 2;
    }
    private sealed class HalfYearPaymentMethod : PaymentMethod
    {
        public HalfYearPaymentMethod() : base(4, "HalfYear")
        {
        }
        public override int PaymentPeriod => 6;
    }
    private sealed class YearlyPaymentMethod : PaymentMethod
    {
        public YearlyPaymentMethod() : base(5, "Yearly")
        {
        }
        public override int PaymentPeriod => 12;
    }
}
