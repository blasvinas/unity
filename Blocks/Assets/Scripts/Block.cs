using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int timesHit = 0;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] GameObject blockSparklesVFX;
    Level level;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit > hitSprites.Length)
            {
                DestroyBlock();
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
            }
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<Game>().AddToScore();
        level.RemoveBlock();
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
        Destroy(gameObject);
    }
}
