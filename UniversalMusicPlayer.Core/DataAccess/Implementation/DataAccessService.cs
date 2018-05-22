using LiteDB;
using System.IO;
using UniversalMusicPlayer.Core.Config;

namespace UniversalMusicPlayer.Core.DataAccess.Implementation
{
    public class DataAccessService : IDataAccessService
    {
        private readonly ISystemPathProvider _systemPathProvider;

        public DataAccessService(ISystemPathProvider systemPathProvider)
        {
            _systemPathProvider = systemPathProvider;
        }

        public LiteDatabase Create()
        {
            var dbPath = Path.Combine(_systemPathProvider.AppData, AppFiles.DatabaseFile);
            var liteDb = new LiteDatabase(dbPath);

            return liteDb;
        }
    }
}
