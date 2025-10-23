using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            if (GameManager.Instance.GetState() == GameState.Play)
            {
                GameManager.Instance.SetChangeState(GameState.Pause);
            }
            else if (GameManager.Instance.GetState() == GameState.Pause)
            {
                GameManager.Instance.SetChangeState(GameState.Play);
            }
        
        }
    }
    
}
