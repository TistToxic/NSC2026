using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float hp = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 100f)
        {
            Destroy(gameObject);
        }
    }
}
