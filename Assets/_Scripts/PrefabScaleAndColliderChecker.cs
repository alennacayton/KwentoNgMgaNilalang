using UnityEngine;

public class PrefabScaleAndColliderChecker : MonoBehaviour
{
    public Transform prefab; // Reference to your prefab or object containing the prefab

    private CircleCollider2D prefabCollider; // Reference to the CircleCollider2D of the prefab

    private Vector3 initialScale; // Initial scale of the prefab

    private void Start()
    {
        // Get the scale of the prefab in Start
        initialScale = prefab.localScale;
        Debug.Log("Prefab scale in Start: " + initialScale);

        // Get the CircleCollider2D of the prefab in Start
        prefabCollider = prefab.GetComponent<CircleCollider2D>();
        if (prefabCollider != null)
        {
           // Debug.Log("Prefab CircleCollider2D radius in Start: " + prefabCollider.radius);
          //  Debug.Log("Prefab CircleCollider2D size in Start: " + prefabCollider.bounds.size);
        }
        else
        {
            Debug.Log("No CircleCollider2D found on the prefab in Start.");
        }
    }

    private void Update()
    {
        // Get the current scale of the prefab
        Vector3 currentScale = prefab.localScale;

        // Check if the scale has changed during runtime
        if (currentScale != initialScale)
        {
          //  Debug.Log("Prefab scale has changed during runtime. New scale: " + currentScale);
        }

        // Get the CircleCollider2D of the prefab in Update
        if (prefabCollider != null)
        {
          //  Debug.Log("Prefab CircleCollider2D radius in Update: " + prefabCollider.radius);
          //  Debug.Log("Prefab CircleCollider2D size in Update: " + prefabCollider.bounds.size);
        }
        else
        {
            Debug.Log("No CircleCollider2D found on the prefab in Update.");
        }
    }
}
