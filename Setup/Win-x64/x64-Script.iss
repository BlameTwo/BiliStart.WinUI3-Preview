#define MyAppName "BiliStart"
#define MyAppVersion "0.0.3"
#define MyAppPublisher "https://github.com/BlameTwo/BiliStart.WinUI3/releases"
#define MyAppURL "https://www.bilibili.com"
#define MyAppExeName "BiliStart.WinUI3.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{84705B15-1A1C-4A51-A596-39382F223CAB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName}-{#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=..\..\LICENSE.txt
PrivilegesRequiredOverridesAllowed=dialog
OutputBaseFilename=BiliStart-{#MyAppName}_{#MyAppVersion}
Compression=lzma/ultra64
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "chinesesimplified"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Files\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "Files\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "WindowsAppRuntimeInstall.exe"; DestDir:"{tmp}"; Flags:ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent


[Code]

function InitializeSetup: Boolean;
var ResultCode:   Integer; 
begin                  
MSgBox('安装包是安装一个新的版本在您的电脑上，如果有旧版请首先手动卸载旧版。',MbInformation,MB_OK);
MSgBox('即将安装WindowsAppSDK1.3',MbInformation,MB_OK);
ExtractTemporaryFile('WindowsAppRuntimeInstall.exe');
Exec(ExpandConstant('{tmp}\WindowsAppRuntimeInstall.exe'),'','',SW_SHOWNORMAL,ewWaitUntilTerminated,ResultCode);
Result:=true;
end;
