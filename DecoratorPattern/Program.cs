var ola = () => {
  INotification notification= new BaseNotification();
  Console.WriteLine(notification.send());

  notification = new SMSDecorator(notification);
  Console.WriteLine(notification.send());

  notification = new SlackNotification(notification);
  Console.WriteLine(notification.send());
};
ola();

public interface INotification
{
  public string send();
}
//La clase base a la cual se le agregaran los decoradores
public class BaseNotification : INotification
{
  public string send()
  {
    return "BaseNotification Sent";
  }
}
//La clase que delega la responsabilidad al decorador que se le asigne
public abstract class NotificationDecorator : INotification
{
  protected INotification _notification;
  public NotificationDecorator(INotification notification)
  {
    this._notification = notification;
  }
  public virtual string send()
  {
    return _notification.send();
  } 
}
public class SMSDecorator : NotificationDecorator
{
  public SMSDecorator (INotification notification) : base (notification)
  {}
  public override string send()
  {
    return _notification.send() + ", SMS Sent";
  }
}
public class SlackNotification : NotificationDecorator
{
  public SlackNotification (INotification notification) : base (notification)
  {

  }
  public override string send()
  {
    return _notification.send() + ", Slack Sent";
  }
}


