using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// ������������ ��������� � ����������� ���
/// </summary>
public class Fly : MonoBehaviour, IFood
{
    [SerializeField, Range(1f, 10f)] protected float rateWait = 1;
    [SerializeField, Range(0f, 1f)] protected float rateScale = 0.2f;
    [SerializeField] protected bool giveFlies;
    [SerializeField] protected bool giveGoldFlies;

    [SerializeField, Range(0f, 2f)] protected float deviationMove;
    [SerializeField] float moveSpeed;
    delegate void Movement();
    List<Movement> moveModels = new List<Movement>();
    int useMoveModel = 0;

    float distanceMove;
    float speed;
    float angle = 0;
    int modMove = 1;
    Vector2 targetPos;
    Vector2 startPos;
    bool leave = false;
    Vector2 leaveVector;

    private void Start()
    {
        StartCoroutine(Waiting());
        SubsDelegate();
        useMoveModel = Random.Range(0, moveModels.Count);
        distanceMove = Random.value * deviationMove;
        if(Random.value <= 0.5f) modMove = -modMove;
        speed = moveSpeed * deviationMove;
        startPos = transform.position;
        transform.localScale *= Random.Range(1 - rateScale, 1 + rateScale);
    }

    private void FixedUpdate()
    {
        if (leave)
        {
            transform.Translate(leaveVector * speed * Time.fixedDeltaTime);
            if (Mathf.Abs(transform.position.x) > 10)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            moveModels[useMoveModel]();
        }
    }

    public void Eat()
    {
        if(giveFlies) GameManager.manager.AddFlies(SaveManager.save.fliesForFly);
        if(giveGoldFlies) GameManager.manager.AddGoldFlies(SaveManager.save.goldFliesForGoldFly);
        GameManager.manager.foodList.Remove(this);
        Destroy(gameObject);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(rateWait * SaveManager.save.waitFlies);
        leave = true;
        GameManager.manager.foodList.Remove(this);
        if (transform.position.x > 0)
        {
            leaveVector = Vector2.right;
        }
        else
        {
            leaveVector = Vector2.left;
        }
    }

    void SubsDelegate()
    {
        moveModels.Add(new(MoveOnCircle));
        moveModels.Add(new(MoveRandom));
    }

    void MoveOnCircle()
    {
        angle += Time.fixedDeltaTime * modMove;

        float x = MathF.Cos(angle * speed) * distanceMove;
        float y = MathF.Sin(angle * speed) * distanceMove;
        transform.position = new Vector2(x, y) + startPos;
    }

    void MoveRandom()
    {
        if (targetPos == Vector2.zero || Vector2.Distance(transform.position, targetPos) < 1f)
        {
            targetPos = Random.insideUnitCircle * (Camera.main.orthographicSize / 2);
        }
        Vector2 vector = targetPos - new Vector2(transform.position.x, transform.position.y);
        transform.Translate(vector.normalized * speed * Time.fixedDeltaTime);
    }
}
