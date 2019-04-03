# refind-next-boot
A utility for modifying the refind boot order

**Comiple Instructions**

*Ubuntu*

`dotnet publish -c Release -r osx.10.11-x64`

*Windows*

`dotnet public -c Release -r win10-x64`

*Else*

`dotnet public -c Release -r <rid_tag>`


#Windows RIDs
Only common values are listed. For the latest and complete version, see the runtime.json file on CoreFX repo.

* Portable (.NET Core 2.0 or later versions)
	* win-x64
	* win-x86
	* win-arm
	* win-arm64

* Windows 7 / Windows Server 2008 R2
	* win7-x64
	* win7-x86

* Windows 8.1 / Windows Server 2012 R2
	* win81-x64
	* win81-x86
	* win81-arm

* Windows 10 / Windows Server 2016
	* win10-x64
	* win10-x86
	* win10-arm
	* win10-arm64

#Linux RIDs
Only common values are listed. For the latest and complete version, see the runtime.json file on CoreFX repo. Devices running a distribution not listed below may work with one of the Portable RIDs. For example, Raspberry Pi devices running a Linux distribution not listed can be targeted with linux-arm.

* Portable (.NET Core 2.0 or later versions)
	* **linux-x64** (Most desktop distributions like CentOS, Debian, Fedora, Ubuntu and derivatives)
	* **linux-musl-x64** (Lightweight distributions using musl like Alpine Linux)
	* **linux-arm** (Linux distributions running on ARM like Raspberry Pi)

* Red Hat Enterprise Linux
	* **rhel-x64** (Superseded by linux-x64 for RHEL above version 6)
	* **rhel.6-x64** (.NET Core 2.0 or later versions)

* Tizen (.NET Core 2.0 or later versions)
	* tizen
	* tizen.4.0.0
	* tizen.5.0.0


For a list of platforms supported by dotnet see
[.NET Core RID Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)