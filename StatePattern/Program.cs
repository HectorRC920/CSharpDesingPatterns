var ola = () => {
  var estado1 = new ConcreteState1();
  var contexto = new Context(estado1);
  Console.WriteLine(contexto.DoThis());
  var estado2 = new ConcreteState2();
  contexto.ChangeState(estado2);
  Console.WriteLine(contexto.DoThis());

};
ola();

public abstract class State
    {
        protected Context _context = null;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract string DoThis();

        public abstract string DoThat();
    }

public class Context : State
{
  private State _state;
  public Context(State state)
  {
    _state = state;
    this._state.SetContext(this);
  }
  public void ChangeState (State state)
  {
    _state = state;
  }
  public override  string DoThis()
  {
    return _state.DoThis();
  }
  public override string DoThat()
  {
    return _state.DoThat();
  }
}
public class ConcreteState1 : State
{

  public override string DoThis()
  {
    return "Estado 1 do this";
  }
  public override string DoThat()
  {
    return "Estado 1 do that";
  }

}
public class ConcreteState2 : State
{

  public override  string DoThis()
  {
    return "Estado 2 do this";
  }
  public override string DoThat()
  {
    return "Estado 2 do that";
  }

}