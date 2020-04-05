using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
    {

        public float restartDelay = 0.4f;

        bool gameHasEnded = false;

        public void EndGame()
        {
            if (gameHasEnded == false)
            {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            }    
        }
        void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
