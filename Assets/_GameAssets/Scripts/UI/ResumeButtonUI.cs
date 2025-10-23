using UnityEngine;

public class ResumeButtonUI : MonoBehaviour
{
    public void OnResumeButtonClik()
    {
        
        if (GameManager.Instance.GetState() == GameState.Pause)
        {
            GameManager.Instance.SetChangeState(GameState.Play);
        }
    }
}
