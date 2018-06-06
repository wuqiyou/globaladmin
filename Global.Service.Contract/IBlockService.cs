using Global.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface IBlockService : IBaseService
    {
        IEnumerable<BlockInfoDto> GetBlocks();
        BlockInfoDto GetBlock(object blockId);
    }
}
