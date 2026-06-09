using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    public TextMeshProUGUI text;

    public GameObject clear;

    private int Score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        Score += value;

        text.text = "Score: " + Score.ToString();
    }

    public void ClearGame()
    {
        clear.SetActive(true);
    }
}
