namespace FleetManagement.Models
{
    public class Vehicle
    {

        public long VehicleId { get; set; }
        public required string ChassisId { get; set; }    
        public required string Type { get; set; }    
        public required string Color { get; set; }
        public required string ChassisSeries { get; set; }
        public required string ChassisNumber { get; set; }        
        public string PassengersCount
        {
            get
            {
                if (Type.ToUpper() == "CAR")
                {
                    return NoOfPassengers.Car.ToString();
                }
                else if (Type.ToUpper() =="BUS")
                {
                    return NoOfPassengers.Bus.ToString();
                }
                else if(Type.ToUpper() =="TRUCK")
                {
                    return NoOfPassengers.Truck.ToString();
                }
                else
                return "";
            }
            set { }            
        }
    }


    static class NoOfPassengers
    {
        public const byte Car = 4;
        public const byte Bus = 42;
        public const byte Truck = 1;
    }

}
