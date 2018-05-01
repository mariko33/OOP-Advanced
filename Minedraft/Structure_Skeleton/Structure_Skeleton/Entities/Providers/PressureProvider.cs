
    public class PressureProvider:Provider
    {
        private const double DurabilityDecrease = 300;
        private const double EnergyMultiplyer = 2;

        public PressureProvider(int id, double energyOutput) : base(id, energyOutput*EnergyMultiplyer)
        {
            this.Durability -= DurabilityDecrease;
            
        }
    }
