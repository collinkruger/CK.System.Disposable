using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CK.System.Disposable
{
    /// <summary>
    /// Is more or less a box for an <see cref="Action"/>
    /// </summary>
    public struct AnonymousDisposable : IDisposable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        volatile Action action;

        /// <summary>
        /// Indicates if <see cref="Dispose"/> has been invoked (more or less)
        /// </summary>
        public bool IsDisposed => action == null;

        
        /// <summary>
        /// Constructs an <see cref="AnonymousDisposable"/> that invokes an <see cref="Action"/> on disposal
        /// </summary>
        /// <param name="action">The <see cref="Action"/> that is to be invoked when "this" object is disposed</param>
        public AnonymousDisposable(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            this.action = action;
        }


        /// <summary>
        /// Invokes the underlying <see cref="Action"/> that was passed into the constructor.
        /// <para>This function is threadsafe, and idempotent; however, if "this" thread dies during execution it is possible for the <see cref="Action"/> not to be invoked.</para>
        /// </summary>
        public void Dispose()
        {
            var handle = Interlocked.Exchange(ref action, null);

            if (handle != null)
                action();
        }
    }
}
