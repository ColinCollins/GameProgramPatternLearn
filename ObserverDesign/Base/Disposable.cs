using System;
using System.Collections;

public class ResourceHolder : IDisposable {
    private bool isDisplosable = false;

    public void Dispose () {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose (bool disposing) {
        if (!isDisplosable) {
            if (disposing) {
                // Clean up manager objects by call their
                // Dispose() method;
                Console.WriteLine(this + "has been disposed.");
            }
            // Cleanup unmanaged objects
        }
        isDisplosable = true;
    }

    public void SomeMethod () {
        if (isDisplosable) {
            Console.WriteLine(this + "you can't execute any method after the target was disposed");
            throw new ObjectDisposedException("ResourcesHolder");
        }
        // method implementation
    }
}