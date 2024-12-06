using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteUpParticleGenerator : MonoBehaviour
{
    // private string Perfect = "PERFECT!";
    // Start is called before the first frame update
    public GameObject m_Effect;
    //public GameObject m_Effect2;
    public GameObject m_Target;

    private Vector3 TextPosition = new Vector3(0, 1.5f, 0.65f);
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 EffectPosition = m_Target.transform.position;
        EffectPosition.Set(EffectPosition.x, EffectPosition.y + 0.4f, EffectPosition.z + 0.2f);

        GameObject Obj = Instantiate(m_Effect, EffectPosition, transform.rotation);
        // GameObject hitObj = Instantiate(m_Effect2, transform.position, transform.rotation);
        Destroy(Obj, 1f);
        // Destroy(hitObj, 1.5f);

        // DynamicTextManager.CreateText(TextPosition, Perfect, DynamicTextManager.defaultData);
    }
}