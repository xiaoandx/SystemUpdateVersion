using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Models
{
    public enum CSLE
    {
        [CL(
            @"Chinese:操作授权",
            @"English:Operation Authorization"
        )]
        R_Login_LA_OperationAuthorization,

        [CL(
            @"Chinese:工号：",
            @"English:Work Number:"
        )]
        R_Login_labUserName,

        [CL(
            @"Chinese:秘钥：",
            @"English:Password:"
        )]
        R_Login_labPassword,

        [CL(
           @"Chinese:厂区：",
           @"English:Factory:"
        )]
        R_Login_labFactory,

        [CL(
           @"Chinese:Language:",
           @"English:语言："
        )]
        R_Login_labLanguage,

        [CL(
           @"Chinese: *",
           @"English: *"
        )]
        R_Login_labDeveloping,

        [CL(
           @"Chinese:授权",
           @"English:Sign in"
        )]
        R_Login_btLogin,

        [CL(
           @"Chinese:退出",
           @"English:Sign out"
        )]
        R_Login_btOut,

        [CL(
           @"Chinese:工号：",
           @"English:JobNumber:"
        )]
        R_Status_WorkNo,

        [CL(
           @"Chinese:厂区：",
           @"English:Factory:"
        )]
        R_Status_Factory,

        [CL(
           @"Chinese:进度：",
           @"English:Speed of progress:"
        )]
        R_Status_SpeedOfProgress,

        [CL(
           @"Chinese:刷新APConfig",
           @"English:Refresh AP Config"
        )]
        R_A_SelectAPConfig,

        [CL(
           @"Chinese:添加APConfig",
           @"English:Create AP Config"
        )]
        R_A_AddAPConfig,

        [CL(
          @"Chinese:退出",
          @"English:Exit"
        )]
        R_A_Exit,

        [CL(
          @"Chinese:授权失败！工号未输入",
          @"English:Authorization failed! The employee ID is not entered."
        )]
        A_M_Login_UserName,

        [CL(
          @"Chinese:授权失败！秘钥未输入",
          @"English:Authorization failed! The Password is not entered."
        )]
        A_M_Login_Password,

        [CL(
          @"Chinese:授权失败！厂区未选择",
          @"English:Authorization failed! Factory not selected."
        )]
        A_M_Login_Factory,

        [CL(
          @"Chinese:成功授权【#UserName】可进行更版操作！",
          @"English:[#UserName] is authorized successfully to update the version!"
        )]
        A_M_Login_LoginOK,

        [CL(
          @"Chinese:【#UserName】授权失败，不可进行更版操作！",
          @"English:[#UserName] Authorization failed. You cannot modify the version!"
        )]
        A_M_Login_LoginError,

        [CL(
          @"Chinese:操作授权",
          @"English:Operation authorization"
        )]
        A_M_Login_UserNameLogFun,

        [CL(
          @"Chinese:提示",
          @"English:Tip"
        )]
        A_M_Clue,

        [CL(
          @"Chinese:确定要关闭窗口吗？",
          @"English:Are you sure you want to close the window?"
        )]
        A_M_CloseWindow,

        [CL(
          @"Chinese:修改配置(&U)",
          @"English:Update Config(&U)"
        )]
        R_A_R_UpdateConfig,

        [CL(
          @"Chinese:删除配置(&D)",
          @"English:Delete Config(&D)"
        )]
        R_A_R_DeleteConfig,

        [CL(
          @"Chinese:刷新配置(&F)",
          @"English:Refresh Config(&F)"
        )]
        R_A_R_RefreshConfig,

        [CL(
          @"Chinese:测试FTP连接(&T)",
          @"English:FTP Connection Test(&T)"
        )]
        R_A_R_TestFTPConnector,

        [CL(
          @"Chinese:备注说明",
          @"English:Other instructions"
        )]
        R_A_D_Remarks,

        [CL(
          @"Chinese:* 备注：",
          @"English:* Remarks:"
        )]
        R_A_CreateForm_Remarks,

        [CL(
          @"Chinese:* 备注：",
          @"English:* Remarks:"
        )]
        R_A_UpdateForm_Remarks,

        [CL(
          @"Chinese:本地更版文件",
          @"English:Local update file"
        )]
        R_O_L_Lab_LocalFile,

        [CL(
          @"Chinese:选择更版文件夹：",
          @"English:SelectUpdateFolder:"
        )]
        R_O_L_Lab_SelectLoaclFile,

        [CL(
          @"Chinese:选择文件夹",
          @"English:SelectFolder"
        )]
        R_O_L_But_SelectFolder,

        [CL(
          @"Chinese:扫描更版文件",
          @"English:ScanAllUpdatedFiles"
        )]
        R_O_L_But_FindAllFiles,

        [CL(
          @"Chinese:选择更版服务器",
          @"English:Select update server"
        )]
        R_O_A_Lab_SelectAP,

        [CL(
          @"Chinese:选择更版类型：",
          @"English:SelectUpdateType:"
        )]
        R_O_A_Lab_SelectType,

        [CL(
          @"Chinese:选择更版AP：",
          @"English:SelectUpdateAP:"
        )]
        R_O_A_Lab_SelectTypeAP,

        [CL(
          @"Chinese:查询服务器",
          @"English:QueryingServer"
        )]
        R_O_B_SelectAPByType,

        [CL(
          @"Chinese:AP 第一次上传更版文件",
          @"English:AP First Upload Files"
        )]
        R_O_A_C_First,

        [CL(
          @"Chinese:启用单独退版",
          @"English:Enable Separate Release"
        )]
        R_O_A_C_BackVersion,

        [CL(
          @"Chinese:AP独立设置远程路径",
          @"English:AP Set Remote Path Alone"
        )]
        R_O_A_C_SettingPath,

        [CL(
          @"Chinese:更版操作",
          @"English:Update Version Operation"
        )]
        R_O_O_Lab_Backup,

        [CL(
          @"Chinese:备份版本",
          @"English:BackupVersion"
        )]
        R_O_O_But_Backup,

        [CL(
          @"Chinese:上传版本",
          @"English:UploadVersion"
        )]
        R_O_O_But_Upload,

        [CL(
          @"Chinese:回退版本",
          @"English:BackVersion"
        )]
        R_O_O_But_BackVersion,

        [CL(
          @"Chinese:备份文件夹：",
          @"English:BackupFolder:"
        )]
        R_O_O_Lab_SelectBackupFolder,

        [CL(
          @"Chinese:备份文件夹：",
          @"English:BackupFolder:"
        )]
        R_O_O_Lab_BackFolder,

        [CL(
          @"Chinese:回收Pool",
          @"English:RecyclePool"
        )]
        R_O_O_But_RecyclePool,

        [CL(
          @"Chinese:关闭程序",
          @"English:AppClose"
        )]
        R_O_O_But_AppExit,

        [CL(
          @"Chinese:详细内容",
          @"English:Details"
        )]
        R_O_O_ListView_Msg,

        [CL(
          @"Chinese:本地更版文件清单",
          @"English:List of Local updated files"
        )]
        R_A_APEditForm_lab_Local,

        [CL(
          @"Chinese:AP 更版上传子目录清单",
          @"English:List of subdirectories uploaded by AP update"
        )]
        R_A_APEditForm_lab_Remack,

        [CL(
          @"Chinese:已检查，确认无误",
          @"English:CheckedAndConfirmed"
        )]
        R_A_APEditForm_But_OK,

        [CL(
          @"Chinese:选择目录",
          @"English:SelectFolder"
        )]
        R_M_But_WebApi,

        [CL(
          @"Chinese:选择目录",
          @"English:SelectFolder"
        )]
        R_M_But_PDA,

        [CL(
          @"Chinese:选择目录",
          @"English:SelectFolder"
        )]
        R_M_But_CIMPDA,

        [CL(
          @"Chinese:选择目录",
          @"English:SelectFolder"
        )]
        R_M_But_CamstarPortal,

        [CL(
          @"Chinese:开启回收",
          @"English:OpenRecycle"
        )]
        R_M_CheckWebApi,

        [CL(
          @"Chinese:开启回收",
          @"English:OpenRecycle"
        )]
        R_M_CheckPDA,

        [CL(
          @"Chinese:开启回收",
          @"English:OpenRecycle"
        )]
        R_M_CheckCIMPDA,

        [CL(
          @"Chinese:开启回收",
          @"English:OpenRecycle"
        )]
        R_M_CheckCamstarPortal,

        [CL(
          @"Chinese:保存监控目录",
          @"English:Save monitoring Directory"
        )]
        R_M_ButSavePath,

        [CL(
          @"Chinese:批量启用监控",
          @"English:Enable batch monitoring"
        )]
        R_M_OpenMonitor,

        [CL(
          @"Chinese:时间",
          @"English:Time"
        )]
        R_M_LV_WebAPI_Time,

        [CL(
          @"Chinese:状态",
          @"English:Status"
        )]
        R_M_LV_WebAPI_Status,

        [CL(
          @"Chinese:消息",
          @"English:Msg"
        )]
        R_M_LV_WebAPI_Msg,

        [CL(
          @"Chinese:时间",
          @"English:Time"
        )]
        R_M_LV_PDA_Time,

        [CL(
          @"Chinese:状态",
          @"English:Status"
        )]
        R_M_LV_PDA_Status,

        [CL(
          @"Chinese:消息",
          @"English:Msg"
        )]
        R_M_LV_PDA_Msg,

        [CL(
          @"Chinese:时间",
          @"English:Time"
        )]
        R_M_LV_CIMPDA_Time,

        [CL(
          @"Chinese:状态",
          @"English:Status"
        )]
        R_M_LV_CIMPDA_Status,

        [CL(
          @"Chinese:消息",
          @"English:Msg"
        )]
        R_M_LV_CIMPDA_Msg,

        [CL(
          @"Chinese:时间",
          @"English:Time"
        )]
        R_M_LV_CP_Time,

        [CL(
          @"Chinese:状态",
          @"English:Status"
        )]
        R_M_LV_CP_Status,

        [CL(
          @"Chinese:消息",
          @"English:Msg"
        )]
        R_M_LV_CP_Msg,

        [CL(
          @"Chinese:#Factory 更版开始",
          @"English:#Factory Update Starts"
        )]
        R_Log_UpdateStart,

        [CL(
          @"Chinese:#Factory 更版结束",
          @"English:#Factory Update Finished"
        )]
        R_Log_UpdateEnd,

        [CL(
          @"Chinese:是否确认要删除所选数据项！",
          @"English:Are you sure you want to delete the selected data item!"
        )]
        R_M_DeleteConfig,

        [CL(
          @"Chinese:删除成功！",
          @"English:Deleted Successfully!"
        )]
        R_M_Delete_OK,

        [CL(
          @"Chinese:删除Config成功！",
          @"English:Deleted Config Successfully!"
        )]
        R_L_Delete_OK,

        [CL(
          @"Chinese:删除失败！",
          @"English:Failed to delete!"
        )]
        R_M_Delect_Error,

        [CL(
          @"Chinese:删除Config失败！",
          @"English:Failed to delete Config!"
        )]
        R_L_Delect_Error,

        [CL(
          @"Chinese:删除数据异常！",
          @"English:An error occurred while deleting data!"
        )]
        R_L_DeleteFile,

        [CL(
          @"Chinese:删除Config数据异常！",
          @"English:An error occurred while deleting Config data!"
        )]
        R_M_DeleteFile,

        [CL(
          @"Chinese:FTP 测试连接异常！",
          @"English:FTP test connection exception!"
        )]
        R_L_TESTFTP_Error,

        [CL(
          @"Chinese:FTP 测试连接",
          @"English:FTP test connection"
        )]
        R_L_TESTFTP,

        [CL(
          @"Chinese:请选择更版类型!",
          @"English:Select an update type!"
        )]
        R_M_SelectType,

        [CL(
          @"Chinese:可选退版备份目录",
          @"English:Backup Directory"
        )]
        R_L_SelectBackupFolder,

        [CL(
          @"Chinese:上传更版操作被禁止，请启用操作锁！",
          @"English:The upload update operation is disabled. Enable the operation lock!"
        )]
        R_M_UploadBack,

        [CL(
          @"Chinese:未选择上传AP！",
          @"English:Upload AP is not selected!"
        )]
        R_M_NotSelectAP,

        [CL(
          @"Chinese:更版状态",
          @"English:Update Status"
        )]
        R_L_UpdateVersionStatus,

        [CL(
          @"Chinese:请检查，本地待上传文件数理与对应文件远程目录不一致！",
          @"English:Check that the number of files to be uploaded locally is inconsistent with the remote directory of the corresponding file!"
        )]
        R_M_E_FolderNumber,

        [CL(
          @"Chinese:更版错误",
          @"English:Update error"
        )]
        R_L_UpdateVersionStatus_Error,

        [CL(
          @"Chinese:更版异常",
          @"English:Update Exception"
        )]
        R_L_UpdateVersionStatus_Exception,

        [CL(
          @"Chinese:备份操作被禁止，请启用操作锁！",
          @"English:The backup operation is disabled. Enable the operation lock!"
        )]
        R_M_BackupBack,

        [CL(
          @"Chinese:备份状态",
          @"English:Backup Status"
        )]
        R_L_BackupStatus,

        [CL(
          @"Chinese:请检查，本地待备份文件数理与对应文件远程目录不一致！",
          @"English:Check that the number of files to be backed up on the local file is inconsistent with the remote directory of the corresponding file!"
        )]
        R_M_E_BackupFolderNumber,

        [CL(
          @"Chinese:备份错误",
          @"English:Backup error"
        )]
        R_L_BackupStatus_Error,

        [CL(
          @"Chinese:更版异常",
          @"English:Backup Exception"
        )]
        R_L_BackupStatus_Exception,

        [CL(
          @"Chinese:备份文件夹及AP",
          @"English:Backup folder and AP"
        )]
        R_BackupFolder,

        [CL(
          @"Chinese:退版操作被禁止，请启用操作锁！",
          @"English:The release operation is disabled. Enable the operation lock!"
        )]
        R_M_BackBack,

        [CL(
          @"Chinese:未选择上传AP！",
          @"English:Upload AP is not selected!"
        )]
        R_M_BackSelectAP,

        [CL(
          @"Chinese:请选择退版文件夹！",
          @"English:Select a download folder!"
        )]
        R_M_BackSelectDir,

        [CL(
          @"Chinese:退版状态",
          @"English:Back Version Status"
        )]
        R_L_BackStatus,

        [CL(
          @"Chinese:请检查，本地待上传文件数理与对应文件远程目录不一致！",
          @"English:Check that the number of files to be uploaded locally is inconsistent with the remote directory of the corresponding file!"
        )]
        R_M_E_BackFolderNumber,

        [CL(
          @"Chinese:退版失败",
          @"English:Back Version error"
        )]
        R_L_BackStatus_Error,

        [CL(
          @"Chinese:退版异常",
          @"English:Back Version Exception"
        )]
        R_L_BackStatus_Exception,

        [CL(
          @"Chinese:选择退版文件",
          @"English:Select a backup file"
        )]
        R_BackFolder,

        [CL(
          @"Chinese:是否首次上传更版文件！",
          @"English:Indicates whether to upload an updated file for the first time!"
        )]
        R_L_FistUploadFile,

        [CL(
          @"Chinese:单独进行退版操作！",
          @"English:Perform the release operation separately!"
        )]
        R_L_Perform,

        [CL(
          @"Chinese:单独设定远程上传更版文件目录！",
          @"English:Set the file directory for remote Upload update separately!"
        )]
        R_L_SetTheFileDirectoryForRemote,

        [CL(
          @"Chinese:AP单独配置上传路径(首次设定)",
          @"English:Configure the upload path for the AP separately (set for the first time)"
        )]
        R_L_FistSettingAPPath,

        [CL(
          @"Chinese:请勿重复勾选AP！",
          @"English:Do not select AP again!"
        )]
        R_M_DoNotGouXuanTheAPAgain,

        [CL(
          @"Chinese:AP单独配置上传异常",
          @"English:An upload error occurred while configuring the AP separately"
        )]
        R_L_GouXuanTheAPAgainFiled,

        [CL(
          @"Chinese:是否保存本次监控目录！",
          @"English:Indicates whether to save the monitoring directory!"
        )]
        R_M_ISSaveLoacMoitorFolder,

        [CL(
          @"Chinese:保存本次设定的监控目录",
          @"English:Save the specified monitoring Directory"
        )]
        R_L_SaveSettingPath,

        [CL(
          @"Chinese:回收Pool",
          @"English:RecyclePool"
        )]
        R_L_RecyclePool,

        [CL(
          @"Chinese:回收Pool异常",
          @"English:An error occurred while recycling the Pool."
        )]
        R_L_RecyclePoolFiled,

        [CL(
          @"Chinese:批量启用文件监控",
          @"English:Enable batch file monitoring"
        )]
        R_L_EnableBatchFileMonitoring,

        [CL(
          @"Chinese:需要重启应用才可生效！点击OK重启",
          @"English:You must restart the application to take effect! Click OK to restart"
        )]
        R_AppLanguage,

        [CL(
          @"Chinese:扫描文件夹不能为空！",
          @"English:The scanned folder must be specified!"
        )]
        R_M_ScannedFile,

        [CL(
          @"Chinese:文件夹路径不存在！",
          @"English:The folder path does not exist!"
        )]
        R_M_FolderPathDoesNotExist,

        [CL(
          @"Chinese:远程目录开头不能为 左斜线 线，结尾必须是 左斜线 ",
          @"English:The remote directory must start with a left slash and end with a left slash."
        )]
        R_M_E0002,

        [CL(
          @"Chinese:回收站点pool",
          @"English:Recycle Site Pool"
        )]
        R_L_RecycleSitePool,

        [CL(
          @"Chinese:初始化",
          @"English:Initialize"
        )]
        R_Init,

        [CL(
         @"Chinese:选择监控目录:#selectedPath",
         @"English:SelectMonitoringDirectory:#selectedPath"
        )]
        R_M_SelectMoitorFolderPar,

        [CL(
         @"Chinese:初始化目录",
         @"English:Initialize a directory"
        )]
        R_M_InitPath,

        [CL(
         @"Chinese:选择监控目录",
         @"English:Select a monitoring Directory"
        )]
        R_M_SelectMoitorFolder,

        [CL(
         @"Chinese:监控目录",
         @"English:Monitoring Directory"
        )]
        R_M_MoitorFolder,

        [CL(
         @"Chinese:添加APConfig成功",
         @"English:Create AP Config Successfully"
        )]
        R_Add_Form_Create,

        [CL(
         @"Chinese:添加APConfig失败",
         @"English:Create AP Config Fail"
        )]
        R_Add_Form_Create_Fail,

        [CL(
         @"Chinese:添加APConfig异常",
         @"English:Create AP Config Error"
        )]
        R_Add_Form_Create_Error,

        [CL(
         @"Chinese:备注 is empty!",
         @"English:Remarks is empty!"
        )]
        R_Add_Form_Remarks,

        [CL(
         @"Chinese:修改APConfig成功",
         @"English:Update AP Config Successfully"
        )]
        R_Update_Form_Update_OK,

        [CL(
         @"Chinese:修改APConfig失败",
         @"English:Update AP Config Fail"
        )]
        R_Update_Form_Update_Fail,

        [CL(
         @"Chinese:修改APConfig异常",
         @"English:Update AP Config Error"
        )]
        R_Update_Form_Update_Error,

        [CL(
         @"Chinese:参考左侧每行对应",
         @"English:Refer to the mapping of each row on the left"
        )]
        R_O_O_Rem_Lab,

        [CL(
         @"Chinese:未选择更版AP服务器！请重新选择",
         @"English:No update AP server is selected! Please select again"
        )]
        R_M_SelectAPList,

        [CL(
         @"Chinese:更版清单存在[#IP]同类型配置，请确认后操作！",
         @"English:[#IP] of the same type exists in the updated list. Please confirm before proceeding!"
        )]
        R_O_SelectAPConfigE0001,

        [CL(
         @"Chinese:单独上传版本",
         @"English:UploadSeparateVersion"
        )]
        R_O_A_C_UploadVersion,

        [CL(
         @"Chinese:设置不备份，只进行更版退版",
         @"English:Set no backup, and only update or disable the version."
        )]
        R_L_SetcheckBUpload,

        [CL(
         @"Chinese:**选择语言**",
         @"English:**SelectLanguage**"
        )]
        A_SelectLanguageTitle,

        [CL(
         @"Chinese:**选择厂区**",
         @"English:**SelectFactory**"
        )]
        A_SelectFactoryTitle,

        [CL(
         @"Chinese:**请选择更版类型**",
         @"English:**PleaseSelectUpdateType**"
        )]
        A_SelectUpdateType,

        [CL(
         @"Chinese:请勿重复启动程序！",
         @"English:Do not repeat the startup procedure!"
        )]
        A_CreateNewApp
    }
}
