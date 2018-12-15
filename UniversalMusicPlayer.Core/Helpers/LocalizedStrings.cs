using UniversalMusicPlayer.Core.Strings.en;

namespace UniversalMusicPlayer.Core.Helpers
{
    public class LocalizedStrings
    {
		private static readonly ApplicationStrings _applicationStrings = new ApplicationStrings();
	    public ApplicationStrings Strings => _applicationStrings;
    }
}
