using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moverProyector : MonoBehaviour
{

    public Text consola;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        consola.text = GyroToUnity(Input.gyro.attitude).ToString();
        this.transform.rotation = GyroToUnity(Input.gyro.attitude);
    }


    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
