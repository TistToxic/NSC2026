using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector3 targetPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Plane xyPlane = new Plane(Vector3.forward, new Vector3(0, 0, transform.position.z));
            float enter = 0f;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Enemy")))
            {
                targetPos = hit.point;
                targetPos.z = transform.position.z;
            }
            else if (xyPlane.Raycast(ray, out enter))
            {
                targetPos = ray.GetPoint(enter);
                targetPos.z = transform.position.z;
            }

            Debug.DrawLine(transform.position, targetPos, Color.green, 2f);

            Vector3 dir = (targetPos - transform.position).normalized;
            RaycastHit enemyHit;
            if (Physics.Raycast(transform.position, dir, out enemyHit, Mathf.Infinity))
            {
                Debug.Log(enemyHit.collider.gameObject.name);
            }
        }
    }
}
