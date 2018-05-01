
    public abstract class Ammunition:IAmmunition
    {
        public string Name { get; }
        public double Weight { get; }
        public double WearLevel { get; private set; }
        private const int Multiplier = 100;

        public Ammunition(double weight)
        {
            this.Name = this.GetType().Name;
            this.Weight = weight;
            this.WearLevel = weight*Multiplier;
        }
        public void DecreaseWearLevel(double wearAmount)
        {
            this.WearLevel -= wearAmount;
        }
    }
