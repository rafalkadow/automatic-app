using Shared.Enums;

namespace Shared.Extensions.GeneralExtensions
{
    [Serializable]
    public static class DataGridExtensions
    {
        public static string StatusGetDataGrid(this int status)
        {
            var statusList = new List<string>
            {
                "label-danger",
                "label-success",
                "label-archive",
            };
            if (status > statusList.Count - 1 || status < 0)
            {
                return statusList.FirstOrDefault();
            }
            else
            {
                return statusList[status];
            }
        }
        public static string StatusGetDataGrid(this RecordStatusEnum status)
        {
            var statusList = new List<string>
            {
                "label-danger",
                "label-success",
                "label-archive",
            };
            if ((int)status > statusList.Count - 1 || status < 0)
            {
                return statusList.FirstOrDefault();
            }
            else
            {
                return statusList[(int)status];
            }
        }
        public static string StatusTextGetDataGrid(this int status, Func<string, string, string> translateBaseFieldText = null)
        {
            var statusList = new List<string>
            {
                "Inactived",
                "Actived",
                "Archived",
            };

            if (translateBaseFieldText != null)
            {
                for (int i = 0; i < statusList.Count; i++)
                {
                    statusList[i] = translateBaseFieldText(statusList[i], statusList[i]);
                }
            }

            if (status > statusList.Count - 1 || status < 0)
            {
                return statusList.FirstOrDefault();
            }
            else
            {
                return statusList[status];
            }
        }

        public static string StatusTextGetDataGrid(this RecordStatusEnum status)
        {
            return status.ToString();
        }

        public static string BoolTextGetDataGrid(this bool status, Func<string, string, string> translateBaseFieldText = null)
        {
            var statusList = new List<string>
            {
                "Yes",
                "No",
            };

            if (translateBaseFieldText != null)
            {
                for (int i = 0; i < statusList.Count; i++)
                {
                    statusList[i] = translateBaseFieldText(statusList[i], statusList[i]);
                }
            }

            if (status == true)
            {
                return statusList[0];
            }
            else
            {
                return statusList[1];
            }
        }
    }
}