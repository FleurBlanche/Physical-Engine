using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ObjectScript_mouseTest : MonoBehaviour {

    Vector3 scale;
    float distance;
    Material mat;

	// Use this for initialization
	void Start () {
        scale = new Vector3(0.1f, 1f, 0.1f);
        mat = new Material(Shader.Find("Sprites/Diffuse"));
    }

    float interX()
    {
        Debug.Log("interX");
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float times = (transform.position.z - mouseRay.origin.z) / mouseRay.direction.z;
        return mouseRay.origin.x + mouseRay.direction.x * times;
    }
    public void XClick(BaseEventData data)
    {
        Debug.Log("XClick");
        distance = transform.position.x - interX();
    }

    public void XMove(BaseEventData data)
    {
        Debug.Log("XMove");
        Vector3 pos = transform.position;
        pos.x = interX() + distance;
        transform.position = pos;
    }
    float interY()
    {
        Debug.Log("interY");
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float times = (transform.position.x - mouseRay.origin.x) / mouseRay.direction.x;
        return mouseRay.origin.y + mouseRay.direction.y * times;
    }
    public void YClick(BaseEventData data)
    {
        Debug.Log("YClick");
        distance = transform.position.y - interY();
    }

    public void YMove(BaseEventData data)
    {
        Debug.Log("YMove");
        Vector3 pos = transform.position;
        pos.y = interY() + distance;
        transform.position = pos;
    }

    float interZ()
    {
        Debug.Log("interZ");
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float times = (transform.position.x - mouseRay.origin.x) / mouseRay.direction.x;
        //Debug.Log(mouseRay.origin.z + mouseRay.direction.z * times);
        return mouseRay.origin.z + mouseRay.direction.z * times;
    }
    public void ZClick(BaseEventData data)
    {
        Debug.Log("ZClick");
        distance = transform.position.z - interZ();
        //Debug.Log(distance);
    }

    public void ZMove(BaseEventData data)
    {
        Debug.Log("ZMove");
        Vector3 pos = transform.position;
        pos.z = interZ() + distance;
        transform.position = pos;
    }

    public void CreateAxis()
    {
        Debug.Log("CreateAxis");
        //Destroy old axis
        GameObject XAxis = GameObject.Find("XAxis");
        GameObject YAxis = GameObject.Find("YAxis");
        GameObject ZAxis = GameObject.Find("ZAxis");
        Destroy(XAxis);
        Destroy(YAxis);
        Destroy(ZAxis);
        Vector3 pos = transform.position;
        //recreate XAxis
        XAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        XAxis.transform.name = "XAxis";
        XAxis.transform.parent = transform;
        XAxis.transform.localScale = scale;
        XAxis.transform.rotation = Quaternion.Euler(0, 0, 90);
        XAxis.transform.position = new Vector3(pos.x + 1, pos.y, pos.z);
        XAxis.gameObject.GetComponent<MeshRenderer>().material = mat;
        XAxis.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
        //XAxis click
        EventTrigger Xtrigger = XAxis.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry XentryClick = new EventTrigger.Entry();
        XentryClick.eventID = EventTriggerType.PointerDown;
        UnityAction<BaseEventData> Xclick = new UnityAction<BaseEventData>(XClick);
        XentryClick.callback.AddListener(Xclick);
        Xtrigger.triggers.Add(XentryClick);
        //XAxis move
        EventTrigger.Entry XentryMove = new EventTrigger.Entry();
        XentryMove.eventID = EventTriggerType.Drag;
        UnityAction<BaseEventData> Xmove = new UnityAction<BaseEventData>(XMove);
        XentryMove.callback.AddListener(Xmove);
        Xtrigger.triggers.Add(XentryMove);
        //recreate YAxis
        YAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        YAxis.transform.name = "YAxis";
        YAxis.transform.parent = transform;
        YAxis.transform.localScale = scale;
        YAxis.transform.rotation = Quaternion.Euler(0, 0, 0);
        YAxis.transform.position = new Vector3(pos.x, pos.y + 1, pos.z);
        YAxis.gameObject.GetComponent<MeshRenderer>().material = mat;
        YAxis.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 0.3f);
        //YAxis click
        EventTrigger Ytrigger = YAxis.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry YentryClick = new EventTrigger.Entry();
        YentryClick.eventID = EventTriggerType.PointerDown;
        UnityAction<BaseEventData> Yclick = new UnityAction<BaseEventData>(YClick);
        YentryClick.callback.AddListener(Yclick);
        Ytrigger.triggers.Add(YentryClick);
        //YAxis move
        EventTrigger.Entry YentryMove = new EventTrigger.Entry();
        YentryMove.eventID = EventTriggerType.Drag;
        UnityAction<BaseEventData> Ymove = new UnityAction<BaseEventData>(YMove);
        YentryMove.callback.AddListener(Ymove);
        Ytrigger.triggers.Add(YentryMove);
        //recreate ZAxis
        ZAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ZAxis.transform.name = "ZAxis";
        ZAxis.transform.parent = transform;
        ZAxis.transform.localScale = scale;
        ZAxis.transform.rotation = Quaternion.Euler(90, 0, 0);
        ZAxis.transform.position = new Vector3(pos.x, pos.y, pos.z + 1);
        ZAxis.gameObject.GetComponent<MeshRenderer>().material = mat;
        ZAxis.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 0.3f);
        //ZAxis click
        EventTrigger Ztrigger = ZAxis.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry ZentryClick = new EventTrigger.Entry();
        ZentryClick.eventID = EventTriggerType.PointerDown;
        UnityAction<BaseEventData> Zclick = new UnityAction<BaseEventData>(ZClick);
        ZentryClick.callback.AddListener(Zclick);
        Ztrigger.triggers.Add(ZentryClick);
        //ZAxis move
        EventTrigger.Entry ZentryMove = new EventTrigger.Entry();
        ZentryMove.eventID = EventTriggerType.Drag;
        UnityAction<BaseEventData> Zmove = new UnityAction<BaseEventData>(ZMove);
        ZentryMove.callback.AddListener(Zmove);
        Ztrigger.triggers.Add(ZentryMove);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
