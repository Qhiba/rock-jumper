using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float playerMaxDistance;

    private Rigidbody2D rb2d;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckPlayerDistance() <= playerMaxDistance)
        {
            FollowPlayer();
        }
    }

    private float? CheckPlayerDistance()
    {
        float distance = 0;

        if (player == null)
        {
            Debug.Log("There's no Player!");
            return null;
        }

        distance = Vector2.Distance(transform.position, player.position);
        return distance;
    }

    private void FollowPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
