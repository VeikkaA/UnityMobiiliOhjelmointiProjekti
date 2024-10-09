using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    private healthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            healthManager = player.GetComponent<healthManager>();

            if (healthManager == null)
            {
                Debug.LogError("Pelaajaobjekti löytyi, mutta healthManageria ei");
            }
        }
        else
        {
            Debug.Log("Pelaajaa ei löydy");
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (healthManager != null)
            {
                healthManager.LoseLife();
            }
            else
            {
                Debug.LogError("healthManager on null");
            }
        }
        Destroy(gameObject);
    }
}
