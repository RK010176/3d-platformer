
using Common;

namespace Game
{
    public interface INpcsManager
    {
        Level level { get; set; }
        void AddNpcs();
    }
}