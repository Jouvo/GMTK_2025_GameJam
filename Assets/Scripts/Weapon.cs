using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset=0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector3 WeaponScreenPosition=Camera.main.WorldToScreenPoint(transform.position);
        Vector3 difference=Input.mousePosition- WeaponScreenPosition;
        float rotZ=Mathf.Atan2(difference.y, difference.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

}
