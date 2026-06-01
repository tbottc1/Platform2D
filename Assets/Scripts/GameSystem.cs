using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{

    public int collectibles = 0;
    public int collectiblesNeeded = 3;
    public TextMeshProUGUI gameOverText;

    public void AddCollectible()
    {
        collectibles++;

        if (collectibles >= collectiblesNeeded)
        {
            Debug.Log("All collectibles gathered!");
        }
    }

    public bool CanWin()
    {
        return collectibles >= collectiblesNeeded;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }


    public void WinScreen()
    {
        gameOverText.gameObject.SetActive(true);
        FindAnyObjectByType<PlayerMovement>().RestartLevel();

    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
