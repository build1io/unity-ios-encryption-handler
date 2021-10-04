#if UNITY_IOS

using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace Build1.UnityIOSEncryptionHandler.Editor
{
    public static class UnityIOSEncryptionHandler
    {
        [PostProcessBuild]
        private static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
        {
            if (buildTarget != BuildTarget.iOS)
                return;
                
            var plist = new PlistDocument();
            var filePath = Path.Combine(buildPath, "Info.plist");
            plist.ReadFromFile(filePath);

            var rootDict = plist.root;
            rootDict.SetBoolean("ITSAppUsesNonExemptEncryption", false);
            plist.WriteToFile(filePath);
        }
    }
}

#endif