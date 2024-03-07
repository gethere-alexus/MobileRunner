using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements
{
    public class BoostDescription : MonoBehaviour
    {
        [SerializeField] private Image _boostImage;

        [SerializeField] private TMP_Text _boostDescription;

        public void Construct(Sprite statImage, int boostValue, int valueAfterBoost, float displayDuration = 1.0f)
        {
            StartCoroutine(DisplayStatText(boostValue, valueAfterBoost, displayDuration, _boostDescription));
            _boostImage.sprite = statImage;
        }

        private IEnumerator DisplayStatText(int boost, int afterBoost, float displayDuration, TMP_Text source)
        {
            float pastTime = 0;
            
            float boostResult = 0;
            float afterBoostResult = 0;
            
            while (pastTime <= displayDuration)
            {
                yield return null;
                pastTime += Time.deltaTime;
                
                string boostDisplay = ((int)Mathf.Lerp(boostResult, boost, EasingInversedSquared(pastTime))).ToString();
                string afterBoostDisplay = ((int)Mathf.Lerp(afterBoostResult, afterBoost, EasingInversedSquared(pastTime))).ToString();

                source.text = $"+{boostDisplay} ({afterBoostDisplay})";
            }
            
            source.text = $"+{boost} ({afterBoost})";
        }

        private float EasingInversedSquared(float x) => 
            1 - (1 - x) * (1 - x);
    }
}
