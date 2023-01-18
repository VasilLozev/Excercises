namespace Vehicles.Models
{
    using Interfaces;
    using Exceptions;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption,
            double fuelConsumptionIncrement)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + fuelConsumptionIncrement;
        }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;

            if (neededFuel > FuelQuantity)
            {
                throw new InsufficientFuelException(string.Format(
                    ExceptionMessages.InsufficientFuelMessage, this.GetType().Name));
            }
            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
