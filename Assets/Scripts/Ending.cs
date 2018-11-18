using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

    float heartTimer;
    float bufferTimer;
    float endingTimer;

    public GameObject Heart;
    public GameObject EndingCanvas;
    public GameObject EndingCanvasImage;

    bool interact;
    bool startBuffer;
    bool startEnding;
    

    private void Start()
    {
        heartTimer = 2;
        endingTimer = 0;
        bufferTimer = 2;

        Heart.SetActive(false);
        EndingCanvas.SetActive(false);
    }

    private void Update()
    {
        if(interact)
        {
            heartTimer -= Time.deltaTime;

            if (heartTimer <= 0)
            {
                Heart.SetActive(true);
                startBuffer = true;
            }

            if(startBuffer)
            {
                bufferTimer -= Time.deltaTime;
            }

            if(bufferTimer < 0)
            {
                startEnding = true;
            }

            if (startEnding)
            {
                endingTimer += Time.deltaTime;
                EndingCanvas.SetActive(true);
                EndingCanvasImage.SetActive(true);
                EndingCanvasImage.GetComponent<Image>().color = new Color(1, 1, 1, (float)(endingTimer * 0.2));
            }

            if (endingTimer > 7)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interact = true;
        collision.gameObject.GetComponent<playerControl>().disableInput = true;
        collision.gameObject.GetComponent<PlayerEnding>().forceIdle = true;
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        collision.gameObject.GetComponent<playerControl>().enabled = false;
    }
}
