using System;
using LiteDB;
using UniversalMusicPlayer.Core.Data;

namespace UniversalMusicPlayer.Core.DataAccess
{
	public interface IDataAccessService
	{
		LiteDatabase Create();
		AudioFileDoc FindById(Guid id);
	}
}