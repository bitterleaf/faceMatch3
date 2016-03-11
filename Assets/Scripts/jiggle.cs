using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class jiggle : MonoBehaviour {

    public float selectTime;
    public float selectRotateSpeed;

    public IEnumerator SelectAction()
    {
        Vector2 loc = gameObject.GetComponent<TargetJoint2D>().target;
        int id = gameObject.GetComponent<Gem>().m_type;
        Clock.markEvent("jiggle_started_obj_" + id.ToString() + "_loc_" + loc.x.ToString() + "_" + loc.y.ToString());

        float t = Time.time;
        Vector3 axis = new Vector3(0f, 0f, 1f);
        while (this != null && transform != null && Time.time < t + 0.5f * selectTime)
        {
            transform.RotateAround(gameObject.transform.position, axis, selectRotateSpeed);
            yield return new WaitForEndOfFrame();
        }
        while (this != null && transform != null && Time.time < t + selectTime)
        {
            transform.RotateAround(gameObject.transform.position, axis, -selectRotateSpeed);
            yield return new WaitForEndOfFrame();
        }
        if (this != null && transform != null)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            Clock.markEvent("jiggle_stopped_obj_" + id.ToString() + "_loc_" + loc.x.ToString() + "_" + loc.y.ToString());
        }
    }

    public float destroyTime;
    public float destroyScale;

    public IEnumerator DestroyAction()
    {
		Vector2 loc = gameObject.GetComponent<TargetJoint2D> ().target;
		int id = gameObject.GetComponent<Gem> ().m_type;
		Clock.markEvent ("destroy_started_obj_"+id.ToString()+"_loc_"+loc.x.ToString()+"_"+loc.y.ToString());
        float t = Time.time;
        while(this != null && transform != null && Time.time < t + destroyTime)
        {
            transform.localScale = destroyScale * transform.localScale;
            yield return new WaitForEndOfFrame();
        }
		Clock.markEvent ("destroy_stopped_obj_"+id.ToString()+"_loc_"+loc.x.ToString()+"_"+loc.y.ToString());
    }

}
