using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Models
{
    public enum FTPType
    {
        /// <summary>
        /// 上传版本
        /// </summary>
        Upload,

        /// <summary>
        /// 下载文件
        /// </summary>
        Download,

        /// <summary>
        /// 退版
        /// </summary>
        BackVersion,

        /// <summary>
        /// 备份版本
        /// </summary>
        BackupVersion,

        /// <summary>
        /// 回收Pool
        /// </summary>
        RecyclePool
    }
}
