using UnityEngine;

public class VertigoState : StateBase//яётн
{
    float time = 0;
    float maxTime = 2;
    public VertigoState(FSMSystem fsm, GameObject gameObject) : base(fsm, gameObject)
    {
        type = StateType.Vertigo;
    }

    public override void Init()
    {

    }

    public override void Action()
    {
        time += Time.deltaTime;
    }

    public override void Reason()
    {
        if (time >= maxTime)
        {
            time = 0;
            fsm.TranslationState(Translation.ToPatrol);
        }
    }

    public override void StateEnd()
    {
        LineRenderer line = GameObject.Find("LineRenderer").GetComponent<LineRenderer>();
        line.positionCount = 0;
    }
}
