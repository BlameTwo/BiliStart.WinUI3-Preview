## 发布方法（非msix安装方式）：

1. 必须安装 **[InnoSetup](https://jrsoftware.org/isinfo.php)** 

2. 请按照依赖关系依次发布包含WindowsAppSdk的项目。

3. 已经在BiliStart.WinUI中写好了发布脚本，请通过VS发布，将在`Setup`文件夹中生成Win-64\Files中生成发布文件。

4. 如果项目SDK发生变化，请修改build.ps1中$sdkurl值

5. 运行build.ps1，输入InnoSetup编译器地址后，按照提示进行发布。

## 发布过程（逐一执行）：

1. App.Models

2. IAppContracts

3. Lib.Helper

4. ViewConverter

5. BiliStart.WinUI.UI

6. ViewModels

7. Views

8. AppContractService

9. BiliStart.WinUI3
   请在项目发布前前将所有的bin、obj文件夹删除干净。

### 将会在output文件夹生成安装文件！


