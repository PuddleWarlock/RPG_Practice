using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public Color color = Color.red;
    [SerializeField] private Vector2 size;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = color;
        Gizmos.DrawWireCube( transform.position,new Vector3(size.x,0,size.y));
    }
}
