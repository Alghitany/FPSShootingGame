using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject enemyContainer;

    [Header("UI")]
    public Text healthText;
    public Text ammoText;
    public Text enemyText;
    public Text infoText;

    private bool gameOver = false;
    private float resetTimer = 3f;

    private void Start()
    {
         infoText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update(){
        if (player.Health <= 0) { healthText.text = "Health: 0"; }
        else
        { healthText.text = "Health: " + player.Health; }
        
        ammoText.text = "Ammo: " + player.Ammo;

        int aliveEnemy = 0;
        foreach(Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())
        {
            if (enemy.Killed == false)
            {
                aliveEnemy++;
            }
        }

        enemyText.text = "Enemies: " + aliveEnemy;
        
        if (aliveEnemy == 0)
        {
            gameOver = true;
            infoText.gameObject.SetActive (true);
            infoText.text = "You win!\nGood job!";
        }

        if (player.Killed == true) {
            gameOver = true;
            infoText.gameObject.SetActive (true);
            infoText.text = "You lose :(\n Try again!";
        }

        if (gameOver == true)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
