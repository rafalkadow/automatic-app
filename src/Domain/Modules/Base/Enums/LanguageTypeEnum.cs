using Domain.Modules.Base.Consts;
using System.ComponentModel;

namespace Domain.Modules.Base.Enums
{
    [Serializable]
    public enum LanguageTypeEnum
    {
        [Description(BaseLanguageConsts.PLCode)]
        Polish = 0,
        [Description(BaseLanguageConsts.ENCode)]
        English = 1,
    }
}