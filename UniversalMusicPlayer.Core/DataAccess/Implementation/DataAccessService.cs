using System;
using System.IO;
using LiteDB;
using UniversalMusicPlayer.Core.Config;
using UniversalMusicPlayer.Core.Data;

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

		public AudioFileDoc FindById(Guid id)
		{
			using (var db = Create())
			{
				var audioFileDoc = db.GetCollection<AudioFileDoc>(DbCollections.AudioFiles).FindById(id);
				return audioFileDoc;
			}
		}
	}
}