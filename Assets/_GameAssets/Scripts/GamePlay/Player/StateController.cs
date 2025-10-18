using UnityEngine;

public class StateController : MonoBehaviour
{
    private PlayerState _currentPlayerState = PlayerState.Idle; //(Şuanki durumu)
    
    private void Start()
    {
        _currentPlayerState = PlayerState.Idle; //Başlangıç durumu
    }
   
   public void ChangeState(PlayerState newPlayerState)
    {
        if (_currentPlayerState != newPlayerState)
        {
            _currentPlayerState = newPlayerState;
        }
    }

    public PlayerState GetCurrentState()
    {
        return _currentPlayerState;
    }
}