using UnityEngine;


[CreateAssetMenu(menuName = "Background Image", fileName = "New Background")]
public class BackgroundSO : ScriptableObject
{
   [SerializeField] Sprite img;

   public Sprite GetImage() {
    return img;
   }
}
