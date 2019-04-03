using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Platform {
   public class OS {
      public static bool IsWindows { get; private set; } = RuntimeInformation.IsOSPlatform (OSPlatform.Windows);

      public static bool IsMacOS { get; private set; } = RuntimeInformation.IsOSPlatform (OSPlatform.OSX);

      public static bool IsLinux { get; private set; } = RuntimeInformation.IsOSPlatform (OSPlatform.Linux);

      public static bool IsAdministrator {
         get {
            return IsWindows ?
                   new WindowsPrincipal (WindowsIdentity.GetCurrent ())
                       .IsInRole (WindowsBuiltInRole.Administrator) :
                   Mono.Unix.Native.Syscall.geteuid () == 0;
         }
      }
   }
}
