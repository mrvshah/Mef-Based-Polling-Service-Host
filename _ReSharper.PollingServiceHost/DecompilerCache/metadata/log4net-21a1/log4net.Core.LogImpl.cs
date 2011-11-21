// Type: log4net.Core.LogImpl
// Assembly: log4net, Version=1.2.10.0, Culture=neutral, PublicKeyToken=1b44e1d426115821
// Assembly location: D:\MyData\git\PollingServiceHost\packages\log4net.1.2.10\lib\2.0\log4net.dll

using log4net;
using log4net.Repository;
using System;

namespace log4net.Core
{
	public class LogImpl : LoggerWrapperImpl, ILog, ILoggerWrapper
	{
		public LogImpl(ILogger logger);

		#region ILog Members

		public virtual void Debug(object message);
		public virtual void Debug(object message, Exception exception);
		public virtual void DebugFormat(string format, params object[] args);
		public virtual void DebugFormat(string format, object arg0);
		public virtual void DebugFormat(string format, object arg0, object arg1);
		public virtual void DebugFormat(string format, object arg0, object arg1, object arg2);
		public virtual void DebugFormat(IFormatProvider provider, string format, params object[] args);
		public virtual void Info(object message);
		public virtual void Info(object message, Exception exception);
		public virtual void InfoFormat(string format, params object[] args);
		public virtual void InfoFormat(string format, object arg0);
		public virtual void InfoFormat(string format, object arg0, object arg1);
		public virtual void InfoFormat(string format, object arg0, object arg1, object arg2);
		public virtual void InfoFormat(IFormatProvider provider, string format, params object[] args);
		public virtual void Warn(object message);
		public virtual void Warn(object message, Exception exception);
		public virtual void WarnFormat(string format, params object[] args);
		public virtual void WarnFormat(string format, object arg0);
		public virtual void WarnFormat(string format, object arg0, object arg1);
		public virtual void WarnFormat(string format, object arg0, object arg1, object arg2);
		public virtual void WarnFormat(IFormatProvider provider, string format, params object[] args);
		public virtual void Error(object message);
		public virtual void Error(object message, Exception exception);
		public virtual void ErrorFormat(string format, params object[] args);
		public virtual void ErrorFormat(string format, object arg0);
		public virtual void ErrorFormat(string format, object arg0, object arg1);
		public virtual void ErrorFormat(string format, object arg0, object arg1, object arg2);
		public virtual void ErrorFormat(IFormatProvider provider, string format, params object[] args);
		public virtual void Fatal(object message);
		public virtual void Fatal(object message, Exception exception);
		public virtual void FatalFormat(string format, params object[] args);
		public virtual void FatalFormat(string format, object arg0);
		public virtual void FatalFormat(string format, object arg0, object arg1);
		public virtual void FatalFormat(string format, object arg0, object arg1, object arg2);
		public virtual void FatalFormat(IFormatProvider provider, string format, params object[] args);
		public virtual bool IsDebugEnabled { get; }
		public virtual bool IsInfoEnabled { get; }
		public virtual bool IsWarnEnabled { get; }
		public virtual bool IsErrorEnabled { get; }
		public virtual bool IsFatalEnabled { get; }

		#endregion

		protected virtual void ReloadLevels(ILoggerRepository repository);
	}
}
