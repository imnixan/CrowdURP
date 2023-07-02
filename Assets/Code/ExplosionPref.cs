using UnityEngine;

public class ExplosionPref : MonoBehaviour
{
    public void SetSize(float size)
    {
        foreach(Transform child in transform)
        {
            child.localScale = new Vector3(size,size,size);
        }
    }
    
    void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
