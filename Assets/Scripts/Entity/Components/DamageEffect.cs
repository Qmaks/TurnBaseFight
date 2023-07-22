using DG.Tweening;
using UnityEngine;

namespace Entity.Components
{
    public interface IDamageEffect
    {
        void ApplyDamageEffect();
    }

    public class DamageEffect : IDamageEffect
    {
        private readonly SpriteRenderer spriteRenderer;

        public DamageEffect(SpriteRenderer spriteRenderer)
        {
            this.spriteRenderer = spriteRenderer;
        }
        
        public void ApplyDamageEffect()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(spriteRenderer.DOColor(Color.red, 0.5f));
            sequence.Append(spriteRenderer.DOColor(Color.white, 0.5f));
            sequence.Play();
        }
    }
}