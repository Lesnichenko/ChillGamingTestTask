using UnityEngine;

namespace Tools.Extensions
{
    public static class CanvasGroupExtensions
    {
        public static bool IsEnable(this CanvasGroup canvasGroup)
        {
            return canvasGroup.alpha == 1;
        }

        public static void Show(this CanvasGroup canvasGroup)
        {
            canvasGroup.SetActive(true);
        }
        
        public static void Hide(this CanvasGroup canvasGroup)
        {
            canvasGroup.SetActive(false);
        }

        private static void SetActive(this CanvasGroup canvasGroup, bool activeState)
        {
            canvasGroup.alpha = activeState ? 1 : 0;
            canvasGroup.blocksRaycasts = activeState;
            canvasGroup.interactable = activeState;
        }
    }
}