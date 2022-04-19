//@CodeCopy
//MdStart

namespace QTTimeManagement.Logic
{
    public interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
