
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillGame : MonoBehaviour
{
   public int value;
   [SerializeField] Image valueDisplay;
   [SerializeField] TMP_Text valueText;
   [SerializeField] Sprite[] valuesImages;
   [SerializeField] float speed;

   bool hasCombine;

   private void Update() {
       if(transform.localPosition != Vector3.zero) {
            hasCombine = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
       } else if(hasCombine == false) {
            if(transform.parent.GetChild(0) != this.transform) {
                Destroy(transform.parent.GetChild(0).gameObject); 
            }
            hasCombine = true;
       }
   }

   public void Upgrade() {
       FillValueUpdate(value*2);
   }

   public void FillValueUpdate(int valueIn) {
       value = valueIn;
       valueText.text = value.ToString(); 
       valueDisplay.sprite = valuesImages[SelectImage(value)]; 
   }


   private int SelectImage(int value) {
       var val = 0;
       switch(value) {
            case 2:
            val = 1;
            break;
            case 4:
            val = 2;
            break;
            case 8:
            val = 3;
            break;
            case 16:
            val = 4;
            break;
            case 32:
            val = 5;
            break;
            case 64:
            val = 6;
            break;
            case 128:
            val = 7;
            break;
            case 256:
            val = 8;
            break;
            case 512:
            val = 9;
            break;
            case 1024:
            val = 10;
            break;
            default: 
            val = 0;
            break;

       }
       return val;
   }
}
