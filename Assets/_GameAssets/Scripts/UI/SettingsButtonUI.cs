using UnityEngine;

public class SettingsButtonUI : MonoBehaviour
{
    public void OnSettingsButtonClik()
    {
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
