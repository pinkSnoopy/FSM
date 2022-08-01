using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    protected Dictionary<Translation, StateType> translation = new Dictionary<Translation, StateType>();
    protected FSMSystem fsm;
    protected StateType type;
    protected GameObject m_go;

    public StateBase(FSMSystem fsm, GameObject go)
    {
        this.fsm = fsm;
        m_go = go;
    }

    public abstract void Init();

    public void AddTranslation(Translation trans, StateType type)
    {
        if (!translation.ContainsKey(trans))
            translation.Add(trans, type);
        else
            Debug.Log("已经存在这个转换条件" + trans);
    }

    public StateType GetStateType()
    {
        return type;
    }

    public StateType JudgeTranslation(Translation trans)
    {
        if (translation.ContainsKey(trans))
            return translation[trans];
        else
            return StateType.nullType;
    }

    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public abstract void Action();
    public abstract void Reason();
}

public enum StateType
{
    nullType, Patrol, Chase, Vertigo
}

public enum Translation
{
    nullTrans, ToPatrol, ToChase, ToVertigo
}