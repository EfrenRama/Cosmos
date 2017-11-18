﻿using System;

using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.TestRunner;
using Sys = Cosmos.System;
using Cosmos.Kernel.Tests.Fat.System.IO;

namespace Cosmos.Kernel.Tests.Fat
{
    /// <summary>
    /// The kernel implementation.
    /// </summary>
    /// <seealso cref="Cosmos.System.Kernel" />
    public class Kernel : Sys.Kernel
    {
        private VFSBase mVFS;

        /// <summary>
        /// Pre-run events
        /// </summary>
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully, now start testing");
            mVFS = new CosmosVFS();
            VFSManager.RegisterVFS(mVFS);
        }

        /// <summary>
        /// Main kernel loop
        /// </summary>
        protected override void Run()
        {
            try
            {
                mDebugger.Send("Run");

#if false
                PathTest.Execute(mDebugger);
                DirectoryTest.Execute(mDebugger);
#endif
//                FileTest.Execute(mDebugger);
#if false
                FileStreamTest.Execute(mDebugger);
                DirectoryInfoTest.Execute(mDebugger);
#endif
                StreamWriterTest.Execute(mDebugger);
                //StreamReaderTest.Execute(mDebugger);
                //BinaryWriterTest.Execute(mDebugger);
                //BinaryReaderTest.Execute(mDebugger);


                TestController.Completed();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred");
                Console.WriteLine(e.ToString());
                mDebugger.Send("Exception occurred: " + e.ToString());
                TestController.Failed();
            }
        }
    }
}
