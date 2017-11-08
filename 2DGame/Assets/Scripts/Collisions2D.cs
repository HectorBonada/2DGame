using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions2D : MonoBehaviour
{
    [Header("State")]
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool wasGroundedLastFrame;
    [HideInInspector] public bool justGrounded;
    [HideInInspector] public bool justNOTGrounded;
    [HideInInspector] public bool isFalling;

    [HideInInspector] public bool isHeadCollision;
    [HideInInspector] public bool wasHeadCollisionLastFrame;
    [HideInInspector] public bool justHeadCollision;
    [HideInInspector] public bool justNOTHeadCollision;

    [HideInInspector] public bool isLateralCollision;
    [HideInInspector] public bool wasLateralCollisionLastFrame;
    [HideInInspector] public bool justLateralCollision;
    [HideInInspector] public bool justNOTLateralCollision;

    [Header("Filter properties")]
    public ContactFilter2D groundFilter;
    public int maxHits;

    [Header("Bottom box")]
    public Vector2 groundBoxPosition;
    public Vector2 groundBoxSize;
    public bool checkGround;

    [Header("Top box")]
    public Vector2 headBoxPosition;
    public Vector2 headBoxSize;
    public bool checkHead;

    [Header("Lateral box")]
    public Vector2 lateralBoxPosition;
    public Vector2 lateralBoxSize;
    public bool checkLateral;


    void Start ()
    {
        ResetState();
	}
    public void MyStart()
    {

    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;

        isGrounded = false;
        justGrounded = false;
        justNOTGrounded = false;
        isFalling = true;

        wasHeadCollisionLastFrame = isHeadCollision;
        isHeadCollision = false;
        justHeadCollision = false;
        justNOTHeadCollision = false;

        wasLateralCollisionLastFrame = isLateralCollision;
        isLateralCollision = false;
        justLateralCollision = false;
        justNOTLateralCollision = false;

    }

    public void MyFixedUpdate()
    {
        ResetState();
        if (checkGround) GroundDetection();    
        if (checkHead) HeadDetection();
        if (checkLateral) LateralDetection();
    }

    void GroundDetection()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 pos = this.transform.position;
        int numHits = Physics2D.OverlapBox(groundBoxPosition + pos, groundBoxSize, 0, groundFilter, results);

        if(numHits > 0)
        {
            isGrounded = true;
        }

        if(isGrounded) isFalling = false;
        if(isGrounded && !wasGroundedLastFrame) justGrounded = true;
        if(!isGrounded && wasGroundedLastFrame) justNOTGrounded = true;
    }

    void HeadDetection()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 pos = this.transform.position;
        int numHits = Physics2D.OverlapBox(headBoxPosition + pos, headBoxSize, 0, groundFilter, results);

        if (numHits > 0)
        {
            isHeadCollision = true;
        }

        if (isHeadCollision && !wasHeadCollisionLastFrame) justHeadCollision = true;
        if (!isHeadCollision && wasHeadCollisionLastFrame) justNOTHeadCollision = true;
    }

    void LateralDetection()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 pos = this.transform.position;
        int numHits = Physics2D.OverlapBox(lateralBoxPosition + pos, lateralBoxSize, 0, groundFilter, results);

        if (numHits > 0)
        {
            isLateralCollision = true;
        }

        if (isLateralCollision && !wasLateralCollisionLastFrame) justLateralCollision = true;
        if (!isLateralCollision && wasLateralCollisionLastFrame) justNOTLateralCollision = true;
    }

    public void Flip(bool face)
    {
        if(face) lateralBoxPosition.x = Mathf.Abs(lateralBoxPosition.x);
    }
    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Vector2 pos = this.transform.position;
        Gizmos.DrawWireCube(groundBoxPosition + pos, groundBoxSize);
        Gizmos.DrawWireCube(headBoxPosition + pos, headBoxSize);
        Gizmos.DrawWireCube(lateralBoxPosition + pos, lateralBoxSize);
    }
}
