using UnityEngine;

public class PoussinController : MonoBehaviour
{
    public float hauteurAuDessusDuSol = 1f; // Hauteur désirée au-dessus du sol
    public LayerMask layerSol; // Layer contenant le sol

    private void Update()
    {
        // Lancer un raycast vers le bas pour détecter le sol
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layerSol))
        {
            // Calculer la position cible du poussin à la hauteur désirée au-dessus du sol
            Vector3 targetPosition = hit.point + Vector3.up * hauteurAuDessusDuSol;

            // Interpoler la position actuelle du poussin vers la position cible
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
