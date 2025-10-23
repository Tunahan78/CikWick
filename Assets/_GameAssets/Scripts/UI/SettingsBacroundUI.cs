using UnityEngine;

public class SettingsBackdropUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsBacroundMax;

    private void Update()
    {
        StateChanged();
    }
    private void StateChanged()
    {
        if (GameManager.Instance.GetState() == GameState.Play)
        {
            settingsBacroundMax.gameObject.SetActive(false);
            return;
        }
        else if(GameManager.Instance.GetState() == GameState.Pause)
        {
            settingsBacroundMax.gameObject.SetActive(true);
        }
    }
}