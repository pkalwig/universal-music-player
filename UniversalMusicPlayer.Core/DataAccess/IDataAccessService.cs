using LiteDB;

namespace UniversalMusicPlayer.Core.DataAccess
{
    public interface IDataAccessService
    {
        LiteDatabase Create();
    }
}
