using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float initialTimer;
    public bool playerNear;

    float movRange;
    public float timer;
    public Vector3 initialPos;
    public Vector3 targetPos;
    Vector3 smoothVelocity;
    float smoothTime;
    Transform pTransform;
    public float moveSpeed;
    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        initialPos = transform.position;
        timer = initialTimer;
        GenerateTargetPos();
        movRange = 5;
        playerNear = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 && !playerNear)
        {
            timer = initialTimer;
            GenerateTargetPos();
        }
    }

    private void FixedUpdate()
    {
        if (!playerNear)
            AutoMove();
        else
            ChasePlayer();
    }

    void GenerateTargetPos()
    {
        
        targetPos = new Vector3(initialPos.x + Random.Range(-movRange, movRange), transform.position.y, initialPos.z + Random.Range(-movRange, movRange));
        
    }

    void ChasePlayer()
    {

        Quaternion newRotation = Quaternion.LookRotation(new Vector3(pTransform.position.x, 0, pTransform.position.z));

        // Set the player's rotation to this new rotation.
        rBody.MoveRotation(newRotation);

        transform.position = Vector3.MoveTowards(transform.position, pTransform.position, moveSpeed * Time.deltaTime);
    }

    void AutoMove()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothVelocity, initialTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = true;

            if(pTransform == null)
                pTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerHealth pHealth = collision.transform.GetComponent<PlayerHealth>();
            pHealth.TakeHit();
        }
    }
}
