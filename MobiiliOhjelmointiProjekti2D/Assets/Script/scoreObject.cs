using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreObject : MonoBehaviour
{
    private SpriteRenderer rend;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            scoringSystem.theScore += 50;
            StartCoroutine("FadeOut");
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
