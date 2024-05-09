using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SectorController : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public AnimatorController animatorController;
    public bool chooseSector;
    public static int index; 
    public static bool selectionActive;
    public static List<Transform> sectors = new List<Transform>();
    private Color originalColor;

    private void Start()
    {
        selectionActive = true;
        foreach (Transform child in transform)
        {
            sectors.Add(child.GetChild(0));
        }

        originalColor = sectors[0].GetComponent<MeshRenderer>().material.color;
        StartCoroutine(WaitAndChange());
    }

    private void Update()
    {
        if (chooseSector)
        {
            chooseSector = false;
            selectionActive = false;
            sectors[index].GetComponent<Animator>().runtimeAnimatorController = animatorController;
            sectors[index].GetComponent<Animator>().SetTrigger("Move");
        }
    }

    public static void RemoveAnimator()
    {
        selectionActive = true;
    }

    private void changeIndex()
    {
        index++;
        if (index == sectors.Count)
            index = 0;
    }

    private void SetColors()
    {
        for (int i = 0; i < sectors.Count; i++)
        {
            if (i == index)
                sectors[i].GetComponent<MeshRenderer>().material.color = Color.red;
            else
                sectors[i].GetComponent<MeshRenderer>().material.color = originalColor;
        }
    }

    private IEnumerator WaitAndChange()
    {
        while (true)
        {
            if (selectionActive)
            {
                changeIndex();
                SetColors();
            }

            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            chooseSector = true;
        }
    }
}
