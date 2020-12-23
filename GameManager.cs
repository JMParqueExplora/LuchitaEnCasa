using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int totalcoins = 0;
    public int lifes = 3;
    public Transform spawnPoint;
    public PlayerController player;
    public float timeToRespawn =2f;
    private float timer = 0;
    public bool isGameOver = false;
    public bool isLevelFinish = false;
    public Text lifeText;
    public GameObject  LevelEndPanel;
    public Text LevelEndText;
    
    
    void Start()
    {
        player.transform.position = spawnPoint.transform.position;
        //Reset.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if(player.isAlive == false){

            if (timer < timeToRespawn){

                timer = timer + Time.deltaTime;
            }
            else {
                if(lifes > 0){
                    lifes --;
                    player.transform.position = spawnPoint.transform.position;
                    player.isAlive = true;
                    timer = 0f;
                }
                else {
                    isGameOver = true;
                }
                
            }

        }
        
        if(isGameOver == true){
            LevelEndPanel.SetActive(true);
            if(isGameOver){
                LevelEndText.text = "Game Over";
                if(Input.GetKeyDown("up")){
                    Restart();
                }

                if(Input.GetMouseButtonDown(0)){
                    Restart();
                }
                
            }
            if(Input.GetKeyDown(KeyCode.Escape)){
                //cargar menú principal
            }
        }

        if(isLevelFinish == true){
            LevelEndPanel.SetActive(true);

            if(isLevelFinish){
                LevelEndText.text = "Completado";
                if(Input.GetKeyDown("up")){
                    Restart();
                }
            }

            
        }

        lifeText.text = "x " + lifes;
    }

    
    public void FinishLevel(){
        
        isLevelFinish = true;
        //Reset.gameObject.SetActive(true);
    }
 
 public void Restart()
 {
    SceneManager.LoadScene("Principal");
 }
    

}
