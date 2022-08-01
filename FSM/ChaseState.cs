using UnityEngine;

public class ChaseState : StateBase// ×·»÷
{
    Transform player;
    Animator anim;

    public ChaseState(FSMSystem fsm, GameObject gameObject) : base(fsm, gameObject)
    {
        type = StateType.Chase;
        anim = gameObject.GetComponent<Animator>();
    }

    public override void Init()
    {
        player = GameObject.Find("Player").transform;
    }

    public override void StateStart()
    {
        anim.SetBool("Run", true);
    }

    public override void StateEnd()
    {
        anim.SetBool("Run", false);
    }

    public override void Action()
    {
        m_go.transform.LookAt(player.position);
        m_go.transform.Translate(Vector3.forward * Time.deltaTime);
    }

    public override void Reason()
    {
        if (Vector3.Distance(player.position, m_go.transform.position) > 6)
        {
            fsm.TranslationState(Translation.ToPatrol);
        }
    }
}
