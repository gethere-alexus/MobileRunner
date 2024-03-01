using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Elements
{
   [Serializable]
   public class Section
   {
      public GameObject SectionObject;
      public Button SelectionButton;
      public Sprite IdleButtonSprite, SelectedButtonSprite;

      public void SetActive(bool status)
      {
         SectionObject.SetActive(status);

         Sprite newSprite = status ? SelectedButtonSprite : IdleButtonSprite;
         SelectionButton.GetComponent<Image>().sprite = newSprite;
      }
   }
}
