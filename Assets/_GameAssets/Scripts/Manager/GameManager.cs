using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static event Action<GameState> OnChangeState;
    public static event Action<int> OnCountEgg;
    public static event Action OnCollectedMaxEgg;
    [SerializeField] private int maxEggCollectibles = 5;

    private int currnetEggCollect = 0;

    private GameState currnetState = GameState.Play;

    private void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetChangeState(GameState newState)
    {
        if (currnetState == newState) return; // Eğer eski state yeni satete eşitse birşey yapmasın
        currnetState = newState;
        OnChangeState?.Invoke(currnetState);
        Debug.Log("Ben Game Managerdan geliyorum oyunun şu anki durumu" + currnetState);
    } 

    public GameState GetState()
    {
        return currnetState;
    }


    private void OnEnable()
    {
        Egg.OnCollectEgg += EggCollected;
        HealtManager.OnPlayerDead += gameStatusLose;
    }

    private void gameStatusLose()
    {
        SetChangeState(GameState.GameOver);
    }

    private void OnDisable()
    {
        Egg.OnCollectEgg -= EggCollected;
    }

    private void EggCollected()
    {
        currnetEggCollect++;
        Debug.Log("Toplanan yumurta sayısı : " + currnetEggCollect);
        OnCountEgg?.Invoke(currnetEggCollect);


        if (currnetEggCollect == maxEggCollectibles)
        {
            //ToDo : Oyun bitirme ekranı yapılacak
            OnCollectedMaxEgg?.Invoke();
            SetChangeState(GameState.GameWin);
        }
    }
}
