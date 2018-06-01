using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ObjectScript_mouseTest : MonoBehaviour {

    Vector3 scale;
    Vector3 sliderPos;
    float distance;
    Material mat;

	// Use this for initialization
	void Start () {
        scale = new Vector3(0.1f, 1f, 0.1f);
        sliderPos = new Vector3(510f, 230f, 0f);
        mat = new Material(Shader.Find("Sprites/Diffuse"));
    }

    void clean()
    {
        GameObject XAxis = GameObject.Find("XAxis");
        GameObject YAxis = GameObject.Find("YAxis");
        GameObject ZAxis = GameObject.Find("ZAxis");
        Destroy(XAxis);
        Destroy(YAxis);
        Destroy(ZAxis);
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
        clean();
        Vector3 pos = transform.position;
        //recreate XAxis
        GameObject XAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
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
        GameObject YAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
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
        GameObject ZAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
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
    /*
    Vector3 interYoz()
    {
        Debug.Log("interYoz");
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float times = (transform.position.x - mouseRay.origin.x) / mouseRay.direction.x;
        return new Vector3(0, mouseRay.origin.y + mouseRay.direction.y * times - transform.position.y,
                              mouseRay.origin.z + mouseRay.direction.z * times - transform.position.z);
    }

    public void YozClick(BaseEventData data)
    {
        Debug.Log("YozClick");
        initial = interYoz();
    }

    public void YozRotate(BaseEventData data)
    {
        Debug.Log("YozRotate");
        Vector3 axis = new Vector3(1, 0, 0);
        float angle = Vector3.SignedAngle(initial, interYoz(), axis);
        float originAngle = transform.eulerAngles.x;
        angle += originAngle;
        if (angle < -180) angle += 360;
        if (angle >= 180) angle -= 360;
        transform.rotation = Quaternion.Euler(angle, 0, 0);
    }

    Vector3 interXoz()
    {
        Debug.Log("interXoz");
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float times = (transform.position.y - mouseRay.origin.y) / mouseRay.direction.y;
        return new Vector3(mouseRay.origin.x + mouseRay.direction.x * times - transform.position.x, 0,
                              mouseRay.origin.z + mouseRay.direction.z * times - transform.position.z);
    }

    public void XozClick(BaseEventData data)
    {
        Debug.Log("XozClick");
        initial = interXoz();
    }

    public void XozRotate(BaseEventData data)
    {
        Debug.Log("XozRotate");
        Vector3 axis = new Vector3(0, 1, 0);
        float angle = Vector3.SignedAngle(initial, interXoz(), axis);
        float originAngle = transform.eulerAngles.y;
        angle += originAngle;
        if (angle < -180) angle += 360;
        if (angle >= 180) angle -= 360;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    Vector3 interXoy()
    {
        Debug.Log("interXoy");
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float times = (transform.position.z - mouseRay.origin.z) / mouseRay.direction.z;
        return new Vector3(mouseRay.origin.x + mouseRay.direction.x * times - transform.position.x,
                           mouseRay.origin.y + mouseRay.direction.y * times - transform.position.y, 0);
    }

    public void XoyClick(BaseEventData data)
    {
        Debug.Log("XoyClick");
        initial = interXoy();
    }

    public void XoyRotate(BaseEventData data)
    {
        Debug.Log("XoyRotate");
        Vector3 axis = new Vector3(0, 0, 1);
        float angle = Vector3.SignedAngle(initial, interXoy(), axis);
        float originAngle = transform.eulerAngles.z;
        angle += originAngle;
        if (angle < -180) angle += 360;
        if (angle >= 180) angle -= 360;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void CreatePlane()
    {
        Debug.Log("CreatePlane");
        //Destroy old plane
        GameObject Yoz = GameObject.Find("Yoz");
        GameObject Xoz = GameObject.Find("Xoz");
        GameObject Xoy = GameObject.Find("Xoy");
        Destroy(Yoz);
        Destroy(Xoz);
        Destroy(Xoy);
        Vector3 pos = transform.position;
        //recreate Yoz
        Yoz = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Yoz.transform.name = "Yoz";
        Yoz.transform.parent = transform;
        Yoz.transform.localScale = planeScale;
        Yoz.transform.rotation = Quaternion.Euler(0, 0, 90);
        Yoz.transform.position = new Vector3(pos.x, pos.y, pos.z);
        Yoz.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
        //Yoz click
        EventTrigger Yoztrigger = Yoz.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry YozentryClick = new EventTrigger.Entry();
        YozentryClick.eventID = EventTriggerType.PointerDown;
        UnityAction<BaseEventData> Yozclick = new UnityAction<BaseEventData>(YozClick);
        YozentryClick.callback.AddListener(Yozclick);
        Yoztrigger.triggers.Add(YozentryClick);
        //Yoz rotate
        EventTrigger.Entry YozentryRotate = new EventTrigger.Entry();
        YozentryRotate.eventID = EventTriggerType.Drag;
        UnityAction<BaseEventData> Yozrotate = new UnityAction<BaseEventData>(YozRotate);
        YozentryRotate.callback.AddListener(Yozrotate);
        Yoztrigger.triggers.Add(YozentryRotate);
        //recreate Xoz
        Xoz = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Xoz.transform.name = "Xoz";
        Xoz.transform.parent = transform;
        Xoz.transform.localScale = planeScale;
        Xoz.transform.rotation = Quaternion.Euler(0, 0, 0);
        Xoz.transform.position = new Vector3(pos.x, pos.y, pos.z);
        Xoz.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 0.3f);
        //Xoz click
        EventTrigger Xoztrigger = Xoz.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry XozentryClick = new EventTrigger.Entry();
        XozentryClick.eventID = EventTriggerType.PointerDown;
        UnityAction<BaseEventData> Xozclick = new UnityAction<BaseEventData>(XozClick);
        XozentryClick.callback.AddListener(Xozclick);
        Xoztrigger.triggers.Add(XozentryClick);
        //Xoz rotate
        EventTrigger.Entry XozentryRotate = new EventTrigger.Entry();
        XozentryRotate.eventID = EventTriggerType.Drag;
        UnityAction<BaseEventData> Xozrotate = new UnityAction<BaseEventData>(XozRotate);
        XozentryRotate.callback.AddListener(Xozrotate);
        Xoztrigger.triggers.Add(XozentryRotate);
        //recreate Xoy
        Xoy = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Xoy.transform.name = "Xoy";
        Xoy.transform.parent = transform;
        Xoy.transform.localScale = planeScale;
        Xoy.transform.rotation = Quaternion.Euler(90, 0, 0);
        Xoy.transform.position = new Vector3(pos.x, pos.y, pos.z);
        Xoy.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 0.3f);
        //Xoy click
        EventTrigger Xoytrigger = Xoy.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry XoyentryClick = new EventTrigger.Entry();
        XoyentryClick.eventID = EventTriggerType.PointerDown;
        UnityAction<BaseEventData> Xoyclick = new UnityAction<BaseEventData>(XoyClick);
        XoyentryClick.callback.AddListener(Xoyclick);
        Xoytrigger.triggers.Add(XoyentryClick);
        //Xoy rotate
        EventTrigger.Entry XoyentryRotate = new EventTrigger.Entry();
        XoyentryRotate.eventID = EventTriggerType.Drag;
        UnityAction<BaseEventData> Xoyrotate = new UnityAction<BaseEventData>(XoyRotate);
        XoyentryRotate.callback.AddListener(Xoyrotate);
        Xoytrigger.triggers.Add(XoyentryRotate);
    }
    */

    public void XRotate(float angle)
    {
        Debug.Log("XRotate");
        Vector3 rot = transform.eulerAngles;
        angle = GameObject.Find("Xslider").GetComponent<Slider>().value;
        transform.rotation = Quaternion.Euler(angle, rot.y, rot.z);
    }
    public void YRotate(float angle)
    {
        Debug.Log("YRotate");
        Vector3 rot = transform.eulerAngles;
        angle = GameObject.Find("Yslider").GetComponent<Slider>().value;
        transform.rotation = Quaternion.Euler(rot.x, angle, rot.z);
    }
    public void ZRotate(float angle)
    {
        Debug.Log("ZRotate");
        Vector3 rot = transform.eulerAngles;
        angle = GameObject.Find("Zslider").GetComponent<Slider>().value;
        transform.rotation = Quaternion.Euler(rot.x, rot.y, angle);
    }
    public void rotateMenu()
    {
        DefaultControls.Resources c = new DefaultControls.Resources();
        GameObject Xslider = DefaultControls.CreateSlider(c);
        Xslider.transform.parent = GameObject.Find("Canvas").transform;
        Xslider.transform.name = "Xslider";
        Slider Xs = Xslider.GetComponent<Slider>();
        Xs.wholeNumbers = true;
        Xs.maxValue = 180;
        Xs.minValue = -180;
        Xs.value = 0;
        Slider.SliderEvent Xevent = new Slider.SliderEvent();
        UnityAction<float> Xrotate = new UnityAction<float>(XRotate);
        Xevent.AddListener(Xrotate);
        Xs.onValueChanged = Xevent;
        Xs.direction = Slider.Direction.LeftToRight;
        GameObject Yslider = DefaultControls.CreateSlider(c);
        Yslider.transform.parent = GameObject.Find("Canvas").transform;
        Yslider.transform.name = "Yslider";
        Slider Ys = Yslider.GetComponent<Slider>();
        Ys.wholeNumbers = true;
        Ys.maxValue = 180;
        Ys.minValue = -180;
        Ys.value = 0;
        Slider.SliderEvent Yevent = new Slider.SliderEvent();
        UnityAction<float> Yrotate = new UnityAction<float>(YRotate);
        Yevent.AddListener(Yrotate);
        Ys.onValueChanged = Yevent;
        Ys.direction = Slider.Direction.LeftToRight;
        GameObject Zslider = DefaultControls.CreateSlider(c);
        Zslider.transform.parent = GameObject.Find("Canvas").transform;
        Zslider.transform.name = "Zslider";
        Slider Zs = Zslider.GetComponent<Slider>();
        Zs.wholeNumbers = true;
        Zs.maxValue = 180;
        Zs.minValue = -180;
        Zs.value = 0;
        Slider.SliderEvent Zevent = new Slider.SliderEvent();
        UnityAction<float> Zrotate = new UnityAction<float>(ZRotate);
        Zevent.AddListener(Zrotate);
        Zs.onValueChanged = Zevent;
        Zs.direction = Slider.Direction.LeftToRight;
        Xslider.transform.position = sliderPos + new Vector3(612.5f, 259.5f, 7.629395e-06f);
        Yslider.transform.position = sliderPos + new Vector3(612.5f, 229.5f, 7.629395e-06f);
        Zslider.transform.position = sliderPos + new Vector3(612.5f, 199.5f, 7.629395e-06f);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
