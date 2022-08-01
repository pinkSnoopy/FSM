using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateBase// Ñ²Âß
{
    private Transform player;
    List<Transform> paths;
    private int pathIndex;
    private Animator anim;

    public PatrolState(FSMSystem fsm, GameObject gameObject) : base(fsm, gameObject)
    {
        type = StateType.Patrol;
        anim = gameObject.GetComponent<Animator>();
    }

    public override void Init()
    {
        player = GameObject.Find("Player").transform;
        Transform path = GameObject.Find("Path").transform;
        paths = new List<Transform>();
        foreach (Transform item in path)
        {
            paths.Add(item);
        }
    }

    public override void StateStart()
    {
        anim.SetBool("Walk", true);
    }

    public override void StateEnd()
    {
        anim.SetBool("Walk", false);
    }

    public override void Action()
    {
        m_go.transform.LookAt(paths[pathIndex].position);
        m_go.transform.Translate(Vector3.forward * Time.deltaTime);
        if (Vector3.Distance(m_go.transform.position, paths[pathIndex].position) <= 0.2)
        {
            pathIndex++;
            pathIndex %= paths.Count;
        }
    }

    public override void Reason()
    {
        if (Vector3.Distance(player.position, m_go.transform.position) <= 6)
        {
            fsm.TranslationState(Translation.ToChase);
        }
    }
}
