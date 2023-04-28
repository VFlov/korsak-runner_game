using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    Vector3 targetPos;
    public float laneOffset = 1.5f;
    float laneChangeSpeed = 15f;

    void Start()
    {
        animator = GetComponent<Animator>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && targetPos.x > -laneOffset)
        {
            targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && targetPos.x < laneOffset)
        {
            targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, laneChangeSpeed * Time.deltaTime);
    }

    public void StartGame()
    {
        RoadGenerator.instance.StartLevel();
    }

    public void ResetGame()
    {
        RoadGenerator.instance.ResetLevel();
    }
}
