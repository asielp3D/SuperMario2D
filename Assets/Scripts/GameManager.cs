using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool canShoot;
    public bool isGameOver;
    public float powerUpDuration = 5;
    float powerUpTimer = 0;

    public List<GameObject> enemiesInScreen = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootPowerUp();

        if(Input.GetKeyDown (KeyCode.P))
        {
            KillAllEnemies();
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        //Llamar funcion de forma normal
        //LoadScene();

        //Invocar funcion despues de 1.5 segundos
        Invoke ("LoadScene", 1.5f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(2);
    }

     void ShootPowerUp()
       {
        if(canShoot)
            {
            if(powerUpTimer <= powerUpDuration)
            {
                powerUpTimer+= Time.deltaTime;
            }
            else
            {
                canShoot = false;
                powerUpTimer = 0;
            }
        }
       }

       void KillAllEnemies()
    {
        for (int i = 0; i < enemiesInScreen.Count; i++)
        {
            Destroy(enemiesInScreen[i]);
        }
    }
}
