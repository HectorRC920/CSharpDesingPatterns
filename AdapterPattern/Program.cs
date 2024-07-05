//Lo que entendi de este patron de diseño basicamente es que
//Vamos a tener una clase que tiene su interfaz y queremos que otra clase
//diferente (con otra interfaz) pueda ejecutar un metodo de la primera clase

var ola = () => {
  JsonReceiver jsonReceiver = new JsonReceiver();
  IXMLOutput adapter = new Adapter(jsonReceiver);

  Console.WriteLine(adapter.PrintXML());
};
ola();

public interface IXMLOutput
{
  public string PrintXML();
}

public class XmlOutput : IXMLOutput
{
  public string PrintXML()
  {
    return "Hi XML";
  }
}

public class Adapter : IXMLOutput
{
  private readonly JsonReceiver _JsonReceiver;
  public Adapter(JsonReceiver _JsonReceiver)
  {
        this._JsonReceiver = _JsonReceiver;
  }
  public string PrintXML()
  {
    Console.WriteLine("Transform XML to JSON");
    Console.WriteLine(_JsonReceiver.ShowJson());
    
    return "XML Transformed end received";
  }
}

public class JsonReceiver 
{
  public string ShowJson()
  {
    return "Json Received";
  }
}

