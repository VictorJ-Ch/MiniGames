using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BowBehaviour : MonoBehaviour
{
    public Transform[] points;
    public Transform shootPoint;
    public GameObject arrowPrefab;
    public float bowCompression; 
    public float arrowMaxSpeed;
    public float arrowMaxDisplacement;
    public float pullSPeed;
    public float realeseSpeed;
    bool applyingTension;
    GameObject arrow;

    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.05f;
        GetComponent<LineRenderer>().positionCount = 3;
    }

    void Update()
    {
        DrawChord();
        if(Input.GetMouseButtonDown(0))
        {
            applyingTension = true;
            SetArrow();
        }
        if(applyingTension) {PullArrow();} else {RealeseArrow();}
        if(Input.GetMouseButtonUp(0))
        {
            applyingTension = false;
            FireArrow();
        }
    }

    void DrawChord()
    {
        Vector3[] pointPositions = new Vector3[] {points[0].position, points[1].position, points[2].position};
        GetComponent<LineRenderer>().SetPositions(pointPositions);
    }

    void SetArrow()
    {
        arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        arrow.GetComponent<KinematicArrow>().shootPoint = shootPoint;
    }

    void PullArrow()
    {
        float dt = Time.deltaTime;
        Vector3 newPosition = new Vector3(0, 0, -arrowMaxDisplacement);
        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, pullSPeed * dt);

        Vector3 newScale = new Vector3(bowCompression, 1, 1);
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, pullSPeed * dt);
    }

    void RealeseArrow()
    {
        float dt = Time.deltaTime;
        Vector3 newPosition = Vector3.zero;
        points[1].localPosition = Vector3.Lerp(points[1].localPosition, newPosition, pullSPeed * dt);

        Vector3 newScale = Vector3.one;
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, pullSPeed * dt);
    }

    void FireArrow()
    {
        float normArrowDisplacement = points[1].localPosition.magnitude / arrowMaxDisplacement;
        arrow.GetComponent<KinematicArrow>().P0 = shootPoint.position;
        arrow.GetComponent<KinematicArrow>().V0 = arrowMaxSpeed * normArrowDisplacement * shootPoint.forward;
        arrow.GetComponent<KinematicArrow>().fired = true;
        arrow.GetComponent<TrailRenderer>().emitting = true;
    }
}
