using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Base))]
public class BaseBehaviorChanger : MonoBehaviour
{
    private Dictionary<Type, IBaseBehavior> _states;
    private Base _base;
    private IBaseBehavior _currentState;

    private void Awake()     
    {
        _base = GetComponent<Base>();
        InitiateStates();
        SetStateByDefault();
    }

    private void Update()
    {
        _currentState.Run();
    }

    public void SetWorkerBuildState()
    {
        if (_currentState != GetState<BaseSpawnWorkerBehavior>())
            SetState(GetState<BaseSpawnWorkerBehavior>());
    }

    public void SetNewBaseBiuldState()
    {
        if (_currentState != GetState<BaseBuildNewBaseBehavior>())
            SetState(GetState<BaseBuildNewBaseBehavior>());
    }

    private void InitiateStates()
    {
        _states = new Dictionary<Type, IBaseBehavior>();

        _states[typeof(BaseSpawnWorkerBehavior)] = new BaseSpawnWorkerBehavior(_base);
        _states[typeof(BaseBuildNewBaseBehavior)] = new BaseBuildNewBaseBehavior(_base);
    }

    private void SetStateByDefault()
    {
        SetWorkerBuildState();
    }

    private void SetState(IBaseBehavior baseState)
    {
        _currentState = baseState;
        _currentState.Enter();
    }

    private IBaseBehavior GetState<T>() where T : IBaseBehavior
    {
        Type type = typeof(T);

        return _states[type];
    }
}
