using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float m_speed = 4.0f;
    public float speed
    {
        get { return m_speed; }
        set
        {
            if (value < 1)
            {
                Debug.Log("You can't set enemy's speed less than 0!");
            }
            else
            {
                m_speed = value;
            }
        }
    }

    private int m_enemyHealth = 1;
    public int enemyHealth
    {
        get { return m_enemyHealth; }
        set
        {
            if (value < 1)
            {
                Debug.Log("You can't set enemy's health less than 1!");
            }
            else
            {
                m_enemyHealth = value;
            }
        }
    }

    private MainManager Manager;

    void Awake()
    {
        Manager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    void Update()
    {
        Move();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            other.gameObject.SetActive(false);
            EnemyDamged();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Manager.GameOver();
        }
    }

    void EnemyDamged()
    {
        m_enemyHealth--;
        Debug.Log($"Enemy is damge, {m_enemyHealth}");
        if (m_enemyHealth < 1)
        {
            transform.position = new Vector3(0f, 0f, 8f);
            Debug.Log($"Enemy dead!");
        }
    }

    void Move()
    {
        transform.Translate(Vector3.back * m_speed * Time.deltaTime);
    }
}
