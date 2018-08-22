@echo off
msbuild ClearMeasure.sln /t:Restore;Clean;Build /v:minimal