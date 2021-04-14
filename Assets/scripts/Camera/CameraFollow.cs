using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed;

    public static LimiteTela cameraLimiteTela;
    // Start is called before the first frame update
    void Start()
    {
        cameraLimiteTela = GetComponent<LimiteTela>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        verificarLimite();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 startPosition = new Vector3(target.position.x, target.position.y, -1);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, startPosition, smoothSpeed);
        transform.position = smoothPosition;
    }

    public void verificarLimite()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraLimiteTela.xMin, cameraLimiteTela.XMax),
            Mathf.Clamp(target.position.y, cameraLimiteTela.yMin, cameraLimiteTela.yMax),-1);
    }

}
