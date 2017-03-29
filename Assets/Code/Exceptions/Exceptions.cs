using System.IO;
using TAMKShooter.Systems;

namespace TAMKShooter.Exceptions
{
    public class LocalizationNotFoundException : FileNotFoundException
    {
        public LangCode Language { get; private set; }

        public LocalizationNotFoundException(LangCode langugage)
        {
            Language = langugage;
        }
        public override string Message
        {
            get
            {
                return "Localizatoin can not be found for language:" + Language;
            }
        }
    }
}
