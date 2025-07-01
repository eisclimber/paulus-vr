using UnityEngine;


namespace ExPresSXR.Misc
{
    public class IndexedColorSwitcher : ColorSwitcher
    {
        [SerializeField]
        private int _materialIdx;

        public override Material AffectedMaterial
        {
            get
            {
                if (_materialIdx >= 0 && _materialIdx < _meshRenderer.materials.Length)
                {
                    return _meshRenderer.materials[_materialIdx];
                }
                Debug.LogWarning($"Invalid material index({_materialIdx}), returning null.", this);
                return null;
            }
            set
            {
                if (_materialIdx >= 0 && _materialIdx < _meshRenderer.materials.Length)
                {
                    // Replace full materials
                    Material[] changedMaterials = _meshRenderer.materials;
                    changedMaterials[_materialIdx] = value;
                    _meshRenderer.materials = changedMaterials;
                }
                else
                {
                    Debug.LogWarning($"Invalid material index({_materialIdx}), not setting the material.", this);
                }
            }
        }
    }
}