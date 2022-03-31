using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public abstract class BasePowerUp : MonoBehaviour
{
    private CircleCollider2D myColl;
    private SpriteRenderer sr;

    protected virtual void Awake()
    {
        TakeTheReferences();
    }

    protected virtual void TakeTheReferences()
    {
        myColl = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }



    protected virtual void Start()
    {
        VariablesAssignment();
    }

    protected virtual void VariablesAssignment()
    {
        myColl.isTrigger = true;
    }

    protected abstract void ChangeStats();

}
