using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neu.ANT.Frontend.States
{
  public class CommonStateController<EnumState> where EnumState : Enum
  {
    private readonly Control _target;
    private EnumState _state;

    public CommonStateController(Control target, EnumState defaultState)
    {
      this._target = target;
      this._state = defaultState;
    }

    public delegate void OnStateChangeAction(EnumState state);

    public event OnStateChangeAction OnStateChange;

    public void SetState(EnumState state)
    {
      if (!EqualityComparer<EnumState>.Default.Equals(state, _state))
      {
        _state = state;

        _target.Invoke(new Action(() =>
        {
          OnStateChange?.Invoke(state);
        }));
      }
    }

  }
}
