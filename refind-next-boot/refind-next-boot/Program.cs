using System;
using Platform;
using System.IO;
using System.Diagnostics;

namespace refind_next_boot {
   class Program {
      static void Main (string[] args) {
         string boot_item = null;
         bool noprompt = false;
         bool restart = false;
         foreach (string arg in args) {
            switch (arg) {
               case "--noprompt":
               case "-n":
                  noprompt = true;
                  break;
               case "--restart":
               case "-r":
                  restart = true;
                  break;
               default:
                  if (boot_item != null) {
                     Console.WriteLine ("Unknown Argument ({0})...", arg);
                     return;
                  }
                  boot_item = arg;
                  break;
            }
         }

         if (boot_item == null) {
            Console.WriteLine ("Missing boot item selection...");
            return;
         }

         if (!OS.IsAdministrator) {
            Console.WriteLine ("Admin privileges is required...");
            return;
         }

         string default_selection = String.Format ("default_selection {0}", boot_item);

         try {
            if (OS.IsWindows) {
               ProcessStartInfo mount = new ProcessStartInfo ("mountvol", "b: /s");
               ProcessStartInfo unmount = new ProcessStartInfo ("mountvol", "b: /d");

               try {
                  Process.Start (mount).WaitForExit ();

                  File.WriteAllText (@"B:\EFI\refind\default.conf", default_selection);
               } finally {
                  Process.Start (unmount).WaitForExit ();
               }
            } else if (OS.IsLinux) {
               File.WriteAllText ("/boot/efi/EFI/refind/default.conf", default_selection);
            }

            Console.WriteLine ("Operation Succeeded...");

            if (!noprompt) {
               Console.Write ("Do you want to restart now? (Y/N) [Y]: ");
            }

            string result = noprompt ? "" : Console.ReadLine ();

            if (String.IsNullOrWhiteSpace (result) || result.ToUpper ().StartsWith ("Y", StringComparison.Ordinal)) {
               if (!noprompt || restart) {
                  if (OS.IsWindows) {
                     Process.Start ("shutdown", "/r /t 0");
                  } else {
                     Process.Start ("systemctl", "reboot");
                  }
               }
            }
         } catch {
            Console.WriteLine ("Operation Failed...");
         }
      }
   }
}
