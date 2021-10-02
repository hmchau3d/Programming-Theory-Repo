using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private int m_enemyHealth = 1;
    public int enemyHealth
    {
        get { return m_enemyHealth; }
        set
        {
            if (value < 1)
            {
                Debug.LogError("You can't set enemy's health less than 1!");
            }
            else
            {
                m_enemyHealth = value;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "projectile")
        {
            other.gameObject.SetActive(false);
        }

        if (other.tag == "PatientSensor")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
        }

        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        m_enemyHealth--;
        Debug.Log($"Enemy damged -1, health = {m_enemyHealth}");
        if (m_enemyHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}
