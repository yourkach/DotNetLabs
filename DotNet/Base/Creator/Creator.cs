using DotNet.Parts;
using DotNet.Parts.CPU;

namespace DotNet.Base.Creator
{
    public interface IPartCreator<out TPart> where TPart : IComputerPart
    {
        TPart Create();
    }

    public class CpuCreator<TCpu> : IPartCreator<TCpu> where TCpu : BaseCpu, new()
    {
        public TCpu Create()
        {
            return new TCpu();
        }
    }
}