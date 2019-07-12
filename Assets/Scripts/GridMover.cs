using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridMover : MonoBehaviour
{
    public float moveTime = .1f;
    public LayerMask blockingLayer;

    protected Collider2D objectCollider;
    protected SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;
    private bool moving;
    private bool stopMove = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
        moving = false;
    }

    protected IEnumerator SmoothMovement (Vector3 end) 
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon && stopMove == false) 
        {
            Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }

        moving = false;
        stopMove = false;
    }

    protected bool Move (int xDir, int yDir, out RaycastHit2D hit) 
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        
        objectCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        objectCollider.enabled = true;

        if (hit.transform == null)
        {
            if(moving == false) 
            {
                moving = true;
                StartCoroutine(SmoothMovement (end));
            }
            return true;
        }

        return false;
    }
    protected virtual void AttemptMove <T> (int xDir, int yDir) 
        where T : Obstacle
    {
        RaycastHit2D hit;
        bool canMove = Move (xDir, yDir, out hit);

        if (hit.transform == null)
            return;

        T hitComponent = hit.transform.GetComponent<T>();

        if (!canMove && hitComponent != null)
            OnCantMove(hitComponent);
    }

    public bool IsMoving() {
        return moving;
    }

    public void InterruptMove() {
        stopMove = true;
    }

    protected abstract void OnCantMove<T>(T component)
        where T:Obstacle;
}
