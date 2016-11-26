using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.System.Disposable
{
    /// <summary>
    /// Class for easily generating anonymous <see cref="IDisposable"/>s 
    /// </summary>
    public static class Disposable
    {
        /// <summary>
        /// Constructs a new anonymous <see cref="IDisposable"/> that will invoke an <see cref="Action"/> on <see cref="IDisposable.Dispose"/>   
        /// </summary>
        /// <param name="action">The action to be invoked on disposal</param>
        public static IDisposable Gen(Action action) => new AnonymousDisposable(action);
    }
}
