$configDirectory = Split-Path $script:MyInvocation.MyCommand.Path

function substituteVersions($fromFilePath, $toFilePath, $packageId){
$fromFilePathFull = ($configDirectory + $fromFilePath)
[xml]$fromFile = Get-Content $fromFilePathFull
$version = $fromFile.SelectSingleNode("//packages/package[@id='" + $packageId+ "']").version

$toFilePathFull = ($configDirectory + $toFilePath)
[xml]$toFile = Get-Content $toFilePathFull
$toFile.SelectSingleNode("//package/metadata/dependencies/dependency[@id='" + $packageId + "']").version = $version
$toFile.Save($toFilePathFull)
}

#nh-sqlserver
substituteVersions "\..\src\main\Antler-NHibernate\packages.config" "\nh\Antler.NHibernate.dll.nuspec" "NHibernate"
substituteVersions "\..\src\main\Antler-NHibernate\packages.config" "\nh\Antler.NHibernate.dll.nuspec" "Iesi.Collections"
substituteVersions "\..\src\main\Antler-NHibernate\packages.config" "\nh\Antler.NHibernate.dll.nuspec" "FluentNHibernate"

#ef-sqlserver
substituteVersions "\..\src\main\Antler-EntityFramework\packages.config" "\ef\Antler.EntityFramework.dll.nuspec" "EntityFramework"

#ef-sqlce
substituteVersions "\..\src\main\Antler-EntityFramework-SqlCe\packages.config" "\ef-sqlce\Antler.EntityFramework.SqlCe.dll.nuspec" "EntityFramework"
substituteVersions "\..\src\main\Antler-EntityFramework-SqlCe\packages.config" "\ef-sqlce\Antler.EntityFramework.SqlCe.dll.nuspec" "EntityFramework.SqlServerCompact"
substituteVersions "\..\src\main\Antler-EntityFramework-SqlCe\packages.config" "\ef-sqlce\Antler.EntityFramework.SqlCe.dll.nuspec" "Microsoft.SqlServer.Compact"

#windsor
substituteVersions "\..\src\main\Antler-Windsor\packages.config" "\windsor\Antler.Windsor.dll.nuspec" "Castle.Windsor"