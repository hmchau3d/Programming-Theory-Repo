using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;
    private Rigidbody playerRb;
    private float horizontalInput;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    void SpawnProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }
    }

    void Update()
    {
        PlayerMove();
        SpawnProjectile();
    }
}
