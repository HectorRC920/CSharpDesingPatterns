var cliente = () => {
  var newsletter =  new NewsLetter();
  newsletter.AddObserver(new EmailObserver());
  newsletter.AddObserver(new SlackObserver());

  newsletter.Notify();
};
cliente();
public interface ISubject
{
  void AddObserver(IObserver observer);
  void RemoveObserver(IObserver observer);
  void Notify();
}

public interface IObserver
{
  void Update();
}

class NewsLetter : ISubject
{
  private string _message;
  private List<IObserver> observers= new List<IObserver>();

  public void AddObserver(IObserver observer){
    observers.Add(observer);
  }
  public void RemoveObserver(IObserver observer){
    observers.Remove(observer);
  }
  public void Notify() 
  {
    foreach(IObserver observer in observers )
    {
      observer.Update();
    }
  }
  public void SetMessage(string message)
  {
    _message = message;
  }
}

public class EmailObserver : IObserver
{
  public void Update()
  {
    Console.WriteLine("Se envia correo a correo");
  }
}
public class SlackObserver : IObserver
{
  public void Update()
  {
    Console.WriteLine("Se envia correo a slack");
  }
}