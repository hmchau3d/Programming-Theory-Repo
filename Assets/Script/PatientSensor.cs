using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientSensor : MonoBehaviour
{
    public MainManager Manager;
    public int patientHealth = 4;
    public Text PatientHealthText;

    // Start is called before the first frame update
    void Start()
    {
        PatientHealthText.text = $"Patient Health : {patientHealth}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            PatientDied();
        }
    }

    void PatientDied()
    {
        patientHealth--;
        PatientHealthText.text = $"Patient Health : {patientHealth}";
        Debug.Log($"Patient damged -1, health = {patientHealth}");
        if (patientHealth < 1)
        {
            Manager.GameOver();
            PatientHealthText.text = $"Patient health : DEAD";
        }
    }
}
