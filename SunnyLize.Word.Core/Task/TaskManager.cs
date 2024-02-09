

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// Handles anthing to do with task
    /// </summary>
    public class TaskManager : ITaskManager
    {
        #region Task Method
        public async Task Run(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
                 await Task.Run(function);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }

            
        }

        public  Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
                return Task.Run(function , cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }
        }

        public async Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
              await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }
        }

        public async Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
                await Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                //log error
                LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }
        }

        public async Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                //try and run the task
                await Task.Run(action);
            }
            catch (Exception ex)
            {
                //log error
              LogError(ex, origin, filePath, lineNumber);

                //throw as normal
                throw;
            }
        }
        #endregion

        #region Private Helper Mathods

       /// <summary>
       /// Log the given error to log factory
       /// </summary>
       /// <param name="ex"></param>
        private void LogError(Exception ex, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            IOCContainer.Logger.Log($"An unexpected error occured runing the IOCContainer.Task.Run.{ex.Message}", LogLevel.Debug, origin, filePath, lineNumber);
        }
        #endregion
    }
}
