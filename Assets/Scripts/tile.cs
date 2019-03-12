using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    bool done;
    bool busy;
    public string entrance = "none";
    public string exit = "none";
    [Space(10)]
    public GameObject tileHorizontal;
    public GameObject tileVertical;
    [Space(5)]
    public GameObject tileCapLeft;
    public GameObject tileCapRight;
    public GameObject tileCapUp;
    public GameObject tileCapDown;
    [Space(5)]
    public GameObject tileCurveUpRight;
    public GameObject tileCurveRightDown;
    public GameObject tileCurveDownLeft;
    public GameObject tileCurveLeftUp;
    [Space(5)]
    public GameObject ball;
    public GameObject hole;
    public GameObject club;
    [Space(5)]
    public GameObject decoration;

    public LayerMask mask;

    public void Decorate()
    { // hardcoded for your pleasure

        // horizontal
        if (entrance == "left" & exit == "right" || entrance == "right" & exit == "left")
        {
            tileHorizontal.SetActive(true);
        }

        // vertical
        if (entrance == "up" & exit == "down" || entrance == "down" & exit == "up")
        {
            tileVertical.SetActive(true);
        }

        // curves
        if (entrance == "up" & exit == "right" || entrance == "right" & exit == "up")
        {
            tileCurveUpRight.SetActive(true);
        }
        if (entrance == "right" & exit == "down" || entrance == "down" & exit == "right")
        {
            tileCurveRightDown.SetActive(true);
        }
        if (entrance == "left" & exit == "down" || entrance == "down" & exit == "left")
        {
            tileCurveDownLeft.SetActive(true);
        }
        if (entrance == "up" & exit == "left" || entrance == "left" & exit == "up")
        {
            tileCurveLeftUp.SetActive(true);
        }

        // cap start
        if (entrance == "none" & exit == "up")
        {
            tileCapUp.SetActive(true);
        }
        if (entrance == "none" & exit == "down")
        {
            tileCapDown.SetActive(true);
        }
        if (entrance == "none" & exit == "left")
        {
            tileCapLeft.SetActive(true);
        }
        if (entrance == "none" & exit == "right")
        {
            tileCapRight.SetActive(true);
        }

        // cap end
        if (entrance == "up" & exit == "none")
        {
            tileCapUp.SetActive(true);
        }
        if (entrance == "down" & exit == "none")
        {
            tileCapDown.SetActive(true);
        }
        if (entrance == "left" & exit == "none")
        {
            tileCapLeft.SetActive(true);
        }
        if (entrance == "right" & exit == "none")
        {
            tileCapRight.SetActive(true);
        }

        if (entrance == "none" && exit != "none")
        {
            ball.SetActive(true);
            club.SetActive(true);
        }

        if (exit == "none" && entrance != "none")
        {
            hole.SetActive(true);
        }

        if (entrance == "none" && exit == "none")
        {
            decoration.SetActive(true);
        }

    }

    public void BuildStep()
    {

        int[] orderList = new int[] { 0, 1, 2, 3 };

        for (int i = 0; i < orderList.Length; i++)
        {
            int temp = orderList[i];
            int randomIndex = Random.Range(i, orderList.Length);
            orderList[i] = orderList[randomIndex];
            orderList[randomIndex] = temp;
        }

        busy = true;

        Vector3 tileUp = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z + 5f);
        Vector3 tileDown = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z - 5f);
        Vector3 tileLeft = new Vector3(transform.position.x - 5f, transform.position.y + 5f, transform.position.z);
        Vector3 tileRight = new Vector3(transform.position.x + 5f, transform.position.y + 5f, transform.position.z);

        RaycastHit upHit;
        RaycastHit downHit;
        RaycastHit leftHit;
        RaycastHit rightHit;

        for (int i = 0; i < orderList.Length; i++)
        {

            if (i == orderList[0])
            {
                if (Physics.Raycast(tileUp, transform.TransformDirection(Vector3.down), out upHit, Mathf.Infinity, mask))
                {
                    if (upHit.transform.gameObject.tag == "tile" && done == false)
                    {
                        if (upHit.transform.gameObject.GetComponent<tile>().busy == false)
                        {
                            // create tile on this side
                            exit = "up";
                            upHit.transform.gameObject.GetComponent<tile>().entrance = "down";
                            upHit.transform.gameObject.GetComponent<tile>().BuildStep();
                            done = true;
                        }
                    }
                }
            }
            if (i == orderList[1])
            {
                if (Physics.Raycast(tileDown, transform.TransformDirection(Vector3.down), out downHit, Mathf.Infinity, mask))
                {
                    if (downHit.transform.gameObject.tag == "tile" && done == false)
                    {
                        if (downHit.transform.gameObject.GetComponent<tile>().busy == false)
                        {
                            // create tile on this side
                            exit = "down";
                            downHit.transform.gameObject.GetComponent<tile>().entrance = "up";
                            downHit.transform.gameObject.GetComponent<tile>().BuildStep();
                            done = true;
                        }
                    }
                }
            }
            if (i == orderList[2])
            {
                if (Physics.Raycast(tileLeft, transform.TransformDirection(Vector3.down), out leftHit, Mathf.Infinity, mask))
                {
                    if (leftHit.transform.gameObject.tag == "tile" && done == false)
                    {
                        if (leftHit.transform.gameObject.GetComponent<tile>().busy == false)
                        {
                            // create tile on this side
                            exit = "left";
                            leftHit.transform.gameObject.GetComponent<tile>().entrance = "right";
                            leftHit.transform.gameObject.GetComponent<tile>().BuildStep();
                            done = true;
                        }
                    }
                }
            }
            if (i == orderList[3])
            {
                if (Physics.Raycast(tileRight, transform.TransformDirection(Vector3.down), out rightHit, Mathf.Infinity, mask))
                {
                    if (rightHit.transform.gameObject.tag == "tile" && done == false)
                    {
                        if (rightHit.transform.gameObject.GetComponent<tile>().busy == false)
                        {
                            // create tile on this side
                            exit = "right";
                            rightHit.transform.gameObject.GetComponent<tile>().entrance = "left";
                            rightHit.transform.gameObject.GetComponent<tile>().BuildStep();
                            done = true;
                        }
                    }
                }
            }

        }

        if (entrance != "none" & exit == "none")
        {
            GameObject.Find("gameStateManager").GetComponent<gameStateManager>().MapCreatedCallback(this.gameObject);
            done = true;
        }

        //       Decorate ();

    }

}