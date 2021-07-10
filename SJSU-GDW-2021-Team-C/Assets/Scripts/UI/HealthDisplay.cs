using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    public Sprite fullHeart, emptyHeart;
    float gutterSize = 20f;

    Image[] healthIcons;

    int healthAmount = 2;

    // Start is called before the first frame update
    void Start()
    {

        ConstructHealthIcons();
        PlayerControlDelegates.onHealthChange += OnChangeHealth;



    }

    public void OnChangeHealth(int health)
    {
        Debug.Log(health);

        for(int i = 0; i < health; i++)
        {
            healthIcons[i].sprite = fullHeart;
        }

        for (int i = health; i <= healthAmount; i++)
        {
            healthIcons[i].sprite = emptyHeart;
        }

    }

    private void ConstructHealthIcons()
    {
        healthIcons = new Image[healthAmount + 1];
        for (int i = 0; i <= healthAmount; i++)
        {
            GameObject imageObject = new GameObject();
            imageObject.transform.parent = this.transform;

            imageObject.name = "Health Icon " + i;

            healthIcons[i] = imageObject.AddComponent<Image>();
            RectTransform r = healthIcons[i].rectTransform;

            r.anchorMin = new Vector2(0, 1);
            r.anchorMax = new Vector2(0, 1);
            r.pivot = new Vector2(0, 1);

            r.sizeDelta = new Vector2(fullHeart.rect.width, fullHeart.rect.height);


            r.anchoredPosition = new Vector2(gutterSize + i * (r.sizeDelta.x + gutterSize), -1 * gutterSize);

            healthIcons[i].sprite = fullHeart;
        }
    }

}
