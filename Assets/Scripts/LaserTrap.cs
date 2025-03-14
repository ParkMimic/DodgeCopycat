using JetBrains.Annotations;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    private float trapPosition;
    private float trapLate = 0;
    private bool trigged = true;

    public float rotateSpeed = 35f;

    public GameObject laser1;
    public GameObject laser2;

    public GameObject trigger1;
    public GameObject trigger2;

    private void Start()
    {
        trapPosition = transform.position.y + 1.5f;
        laser1.SetActive(false);
        laser2.SetActive(false);
    }

    void Update()
    {
        trapLate += Time.deltaTime;

        if (trapLate >= 10)
        {
            laser1.SetActive(true);
            laser2.SetActive(true);

            if (transform.position.y <= trapPosition)
            {
                transform.Translate(0, 10 * Time.deltaTime, 0);
            }

            if (trapLate >= 11.5f)
            {
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            }

            if (trigger1 == null && trigger2 == null)
            {
                if (trigged == true)
                {
                    rotateSpeed *= 2;
                    trigged = false;
                }

                Debug.Log("1rotateSpeed : " + rotateSpeed);
            }
        }
    }
}
