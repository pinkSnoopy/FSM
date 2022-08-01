using System.Collections.Generic;
using UnityEngine;

public class FSMSystem
{
    public Dictionary<StateType, StateBase> dic = new Dictionary<StateType, StateBase>();
    public StateType curStateType;
    public StateBase curState;

    public void Init()
    {
        curStateType = StateType.Patrol;

        foreach (var item in dic)
        {
            item.Value.Init();
        }
    }

    public void AddState(StateType type, StateBase state)
    {
        if (!dic.ContainsKey(type))
            dic.Add(type, state);
        else
            Debug.Log("״̬�����Ѿ������״̬��" + type);
    }

    public void TranslationState(Translation trans)
    {
        StateType type = dic[curStateType].JudgeTranslation(trans);
        if (type == StateType.nullType)
        {
            Debug.Log("�޷�ת��");
            return;
        }
        else
        {
            curState.StateEnd();
            curStateType = type;
            //Debug.Log("��ǰ״̬" + type);
            curState = dic[type];
            curState.StateStart();
        }
    }

    public void Update()
    {
        curState.Action();
        curState.Reason();
    }
}
