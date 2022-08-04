using ATG.Data;

namespace ATG
{
    public interface IPickable
    {
        ItemVisualizeData DoPick();
        void Disable();
    }
}