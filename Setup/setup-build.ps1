$scriptpath = $PSScriptRoot
$innoSetupExe = Read-Host "������ Inno Setup ��������λ�ã����磺C:\Program Files (x86)\Inno Setup 6\ISCC.exe����"
$sdkurl ="https://aka.ms/windowsappsdk/1.3/1.3.230724000/windowsappruntimeinstall-x64.exe"
if (-not [string]::IsNullOrEmpty($innoSetupExe)) {
    Write-Host "��ѡ�����汾��"
    Write-Host "1. x64��Ŀǰ����x64ƽ̨������"
    $choice = Read-Host "������ѡ���ţ�"
    if ($choice -eq "1") {
        $scriptPath = Join-Path $scriptpath "Win-x64\x64-Script.iss"
        Write-Host "��ʼ����������Ŀ"
        $outputPath = Join-Path $PSScriptRoot "/Win-x64/WindowsAppRuntimeInstall.exe"
        $wc = New-Object System.Net.WebClient
        $wc.DownloadFile($sdkurl, $outputPath)
        Write-Host "Windows App Runtime ��װ�ļ������ص���$outputPath"
    } 
    else
    {
       Write-Host "Error value"
       Exit	
    }
    $innoSetupFolder = Split-Path -Path $innoSetupExe
    Set-Location $innoSetupFolder
    & $innoSetupExe $scriptPath
    Set-Location -Path $PSScriptRoot
    Write-Host "�Ѿ���ѡ���ƽ̨�ļ��������ɰ�װexe�������ѡ��ı���汾��Output�ļ����в鿴"
} else {
    Write-Host "δ�ṩ��Ч�� Inno Setup ������λ�á�"
}
Read-Host "�밴������˳�"

