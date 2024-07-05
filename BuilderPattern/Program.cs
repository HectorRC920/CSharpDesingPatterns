var ola = () => {
    CarBuilder carroBuilder = new CarBuilder();
    Director director= new Director();
    director.ConstructSportCar(carroBuilder);
    Console.WriteLine(carroBuilder.GetProduct().NumberOfSeats);

    CarManualBuilder manualBuilder = new CarManualBuilder(); 
    director.ConstructSportCar(manualBuilder);

};
ola();

public interface IBuilder
{
  public void Reset();
  public void setSeats(int NumberOfSeats);

  public void setEngine(string engine);

  public void setGps();
}

public class Car
{
  public int NumberOfSeats { get; set; }
}
public class CarManual
{

}

public class CarBuilder : IBuilder
{
  protected  Car _car = null;
  public CarBuilder()
  {
    this.Reset();
  }
  public void Reset(){
    _car = new Car();
  }
  public void setSeats(int NumberOfSeats){
    _car.NumberOfSeats = NumberOfSeats;
    Console.WriteLine("Adding Sport Car Seats " + NumberOfSeats);
  }

  public void setEngine(string engine)
  {
     Console.WriteLine("Adding Sport Car engine " + engine);
  }

  public void setGps()
  {
    Console.WriteLine("Adding Sport Car GPS");
  }
  public Car GetProduct()
  {
    return _car;
  } 
  
}
class CarManualBuilder : IBuilder
{
  protected  CarManual _carManual = null;
  public CarManualBuilder()
  {
   this.Reset();
  }
  public void Reset(){
    _carManual = new CarManual();
  }
  public void setSeats(int NumberOfSeats){
     Console.WriteLine($"Adding Sport Car Seats instructions for :{NumberOfSeats} seats");
  }

  public void setEngine(string engine)
  {
   Console.WriteLine("Adding Sport Car engine intructions for engine " + engine);
  }

  public void setGps()
  {
    Console.WriteLine("Adding Sport Car GPS instructions");
  }
}
class Director 
{
  public void ConstructSportCar(IBuilder builder)
  {
    builder.Reset();
    builder.setSeats(3);
    builder.setEngine("V8");
    builder.setGps();
  }
  public void ConstructSUVCar(IBuilder builder)
  {
    builder.Reset();
    builder.setSeats(6);
    builder.setEngine("V12");
    builder.setGps();
  }
}
// class Engine
// {
//   public Engine()
//   {
//     Console.WriteLine("Motorsini");
//   }
// }