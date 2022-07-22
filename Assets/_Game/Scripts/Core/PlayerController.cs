using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SBF.Extentions.Transforms;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    float Speed => Configs.Player.speed;

    float SwipeSpeed => Configs.PlayerSwipe.speed;

    float RotateSpeed => Configs.PlayerRotation.speed;


    private float currentDirection;

    bool canMove = false;

    enum AnimationStates
    {
        Idle,
        Run
    }
    AnimationStates _animState = AnimationStates.Idle;
    AnimationStates AnimState
    {
        get => _animState;
        set
        {
            if(_animState != value)
            {
                _animState = value;
                anim.SetTrigger(_animState.ToString());
            }
        }
    }

    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;

    const int minCurrency = 0;
    const int maxCurrency = int.MaxValue;


    private int _totalCurrency;
    public int totalCurrency
    {
        get => _totalCurrency;
        set
        {
            _totalCurrency = Mathf.Clamp(value, minCurrency, maxCurrency);
            UIManager.I.SetCurrencyText();
        }
    }

    public void OnGameStarted()
    {
        canMove = true;
        AnimState = AnimationStates.Run;
    }

     void Update()
    {
        if(GameManager.isRunning && canMove)
        {
            rb.transform.position += Vector3.forward * Time.deltaTime * Speed;

            HandlePlayerRotation();
        }
    }

    public void MovePlayer(float x)
    {
        rb.transform.position = new Vector3(Mathf.Clamp(rb.transform.position.x + x * SwipeSpeed, -3f, 3f), rb.transform.position.y, rb.transform.position.z);
        //rb.transform.position +=  Vector3.right * x * SwipeSpeed;

        AddRotation(x * RotateSpeed);
    }

    void AddRotation( float f)
    {
        currentDirection = Mathf.Clamp(currentDirection + f, -15f, 15f);
    }

    void HandlePlayerRotation()
    {
        if (Mathf.Abs(currentDirection) > 0.5f)
        {
            AddRotation(Time.deltaTime * 25f * Mathf.Sign(-currentDirection));
        }
        else
        {
            currentDirection = 0f;
        }

        rb.transform.rotation = Quaternion.Euler(Vector3.up * currentDirection);
    }


    public void SetValue(int value, bool up)
    {
        if(up)
        totalCurrency += value;
        else
        {
            if (totalCurrency > value)
                totalCurrency -= value;
            else
            {
                totalCurrency = 0; 
            }
        }
        UpgradeManager.I.CheckForUpgradeDowngrade(totalCurrency,up);
    }

    // TODO: according to time value, change (setActive()) to the appearence of the player

    public void OnLevelEnded(Vector3 finPos)
    {
        canMove = false;
        Goto(finPos + Vector3.forward * 4f, 2f, () => {
            new SBF.Toolkit.DelayedAction(() => GameManager.OnLevelCompleted(), 2f).Execute(this);
            AnimState = AnimationStates.Idle;
        });
    }

    void Goto(Vector3 targetPos,float duration,System.Action onCompleted)
    {
        rb.transform.DOMove(targetPos, duration).SetEase(Ease.Linear).OnComplete(() => onCompleted?.Invoke());
    }
}

