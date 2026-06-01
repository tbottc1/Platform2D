using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{


    public GameObject winImage;

    public int collectibles = 0;
    public int collectiblesNeeded = 3;


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
        winImage.SetActive(false);
    }


    public void WinScreen()
    {
        Debug.Log("we got here.");

        
        winImage.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
