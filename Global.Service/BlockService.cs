using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using System.Collections.Generic;

namespace Global.Service
{
    public class BlockService : BaseService, IBlockService
    {
        public IEnumerable<BlockInfoDto> GetBlocks()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                BlockFacade facade = new BlockFacade(uow);
                List<BlockInfoDto> result = facade.GetBlocksInfo(new BlockInfoConverter());
                return result;
            }
        }

        public BlockInfoDto GetBlock(object blockId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                BlockFacade facade = new BlockFacade(uow);
                BlockInfoDto result = facade.GetBlockInfo(blockId, new BlockInfoConverter());
                return result;
            }
        }
    }
}
