using UnityEngine;
public class ScoreCount : MonoBehaviour{
    public GameObject pointSound;

    void OnTriggerEnter2D(Collider2D other){
        ScoreManager.score += 1;
        GameObject sound = Instantiate(pointSound, null);
        Destroy(sound, 1f);
    }
}
