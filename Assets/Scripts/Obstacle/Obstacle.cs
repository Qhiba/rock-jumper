using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float emergeDelay = 1.0f;
    [SerializeField] private float vanishDelay = 1.0f;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(VanishCount());
    }

    private IEnumerator EmergeCount()
    {
        yield return new WaitForSeconds(emergeDelay);
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
        StartCoroutine(VanishCount());
    }

    private IEnumerator VanishCount()
    {
        yield return new WaitForSeconds(vanishDelay);
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        StartCoroutine(EmergeCount());
    }
}
