using JetBrains.Annotations;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    private float trapPosition;
    private float trapLate;
    private int keyCheck;
    private float countDown;

    public GameObject laserTrap;
    public float rotateSpeed = 35f;

    private void Start()
    {
        trapPosition = transform.position.y + 1.5f;
    }

    void Update()
    {
        if (keyCheck >= 1)
        {
            countDown += Time.deltaTime;

            if (countDown >= 11)
            {
                laserTrap.SetActive(true);
                countDown = 0;
            }
        }

        if (transform.position.y <= trapPosition)
        {
            transform.Translate(0, 10 * Time.deltaTime, 0);
        }

        trapLate += Time.deltaTime;

        if (trapLate >= 1.5f)
        {
            transform.Rotate(0, (rotateSpeed * keyCheck) * Time.deltaTime, 0);
        }
    }

    public void Key()
    {
        keyCheck += 1;
    }
}
