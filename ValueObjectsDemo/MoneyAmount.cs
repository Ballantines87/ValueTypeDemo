using System;

namespace ValueObjectsDemo
{
    sealed class MoneyAmount :IEquatable<MoneyAmount>
    {
        public decimal Amount { get; }
        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            if (amount < 0)
                throw new ArgumentException("Money amount must be non-negative", nameof(amount));
            this.Amount = amount;
            this.CurrencySymbol = currencySymbol;
        }
        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";

        public MoneyAmount Scale(decimal scaleFactor)
            => new MoneyAmount(this.Amount * scaleFactor, this.CurrencySymbol);



        public override bool Equals(object obj) => this.Equals(obj as MoneyAmount);

        public bool Equals(MoneyAmount other)
        {
            return other != null 
                && other.Amount == this.Amount 
                && other.CurrencySymbol == this.CurrencySymbol;
        }

        public static bool operator == (MoneyAmount a, MoneyAmount b)
        {
            return ((ReferenceEquals(b, null) && ReferenceEquals(a, null))
                || (a.Equals(b)));
        }

        public static bool operator != (MoneyAmount a, MoneyAmount b) => !(a == b);

        public override int GetHashCode()
            => (this.Amount.GetHashCode()) ^ (this.CurrencySymbol.GetHashCode());
            


    }
}