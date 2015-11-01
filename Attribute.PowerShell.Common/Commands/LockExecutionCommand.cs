using System;
using System.Management.Automation;
using System.Timers;
using Attribute.Common.Enumeration;
using Attribute.PowerShell.Common.Properties;
using Attribute.PowerShell.Common.Util;
using Microsoft.PowerShell.Commands;

namespace Attribute.PowerShell.Common.Commands
{
    [Cmdlet(VerbsCommon.Lock, "Execution", DefaultParameterSetName = "WaitTimed")]
    public class LockExecutionCommand : ConsoleColorCmdlet
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        protected override void BeginProcessing()
        {
            if (!this._indefinite)
            {
                try
                {
                    if (this.Unit == TimeUnit.Millisecond || this.Unit == TimeUnit.Tick)
                    {
                        Exception ex = new InvalidOperationException("Invalid time unit value.");
                        ExceptionHelper.SetUpException(
                                                       ref ex,
                                                       "InvalidTimeUnit",
                                                       ErrorCategory.InvalidOperation,
                                                       this.Unit);
                        throw ex;
                    }

                    this._timer = new Timer
                                  {
                                      Interval = this.Unit.GetMilliseconds()
                                  };
                }
                catch (Exception ex)
                {
                    this.WriteException(ex, true);
                }
            }
        }

        protected override void ProcessRecord()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.BackgroundColor = this.BackgroundColor;

            try
            {
                if (this._indefinite)
                {
                    this.doWaitIndefinite();
                }
                else
                {
                    this.doWaitTimed();
                }
            }
            catch (Exception ex)
            {
                this.WriteException(ex);
            }

            Console.ResetColor();
        }

        #endregion


        #region [-- PRIVATE METHODS --]

        private void doWaitIndefinite()
        {
            this.writeOuput();

            while (!Console.KeyAvailable)
            {
            }

            Console.ReadKey(true);
            Console.WriteLine();
        }

        private void doWaitTimed()
        {
            var counter = this._timeout;
            var lastCounterValue = counter;

            this._timer.Elapsed += (pSender, pEvent) => counter--;
            this._timer.Start();

            this.writeOuput(counter);

            while (counter > 0)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    if (!this._noBreak)
                    {
                        break;
                    }
                }

                if (this._noRedraw)
                {
                }
                if (lastCounterValue != counter)
                {
                    this.writeOuput(counter);
                    lastCounterValue = counter;
                }
            }

            this.writeOuput();
            Console.WriteLine();
        }

        private void writeOuput(int counter = 0)
        {
            if (this._indefinite)
            {
                Console.Write(Resources.LockExecutionCommand_Prompt_Indefinite);
            }
            else
            {
                var name = Enum.GetName(typeof(TimeUnit), this.Unit);

                if (name != null)
                {
                    Console.Write(
                                  Resources.LockExecutionCommand_Prompt_Format,
                                  '\r'
                                  + (this.NoBreak
                                         ? Resources.LockExecutionCommand_Prompt_NoCancel
                                         : Resources.LockExecutionCommand_Prompt),
                                  counter,
                                  name.ToLower() + (counter == 1 ? "" : "s"));
                }
            }
        }

        #endregion


        #region [-- PROPERTIES --]

        [Parameter(ParameterSetName = "WaitIndefinite")]
        public SwitchParameter Indefinite
        {
            get { return this._indefinite; }
            set { this._indefinite = value; }
        }

        [Parameter(ParameterSetName = "WaitTimed"), Alias("b")]
        public SwitchParameter NoBreak
        {
            get { return this._noBreak; }
            set { this._noBreak = value; }
        }

        [Parameter(ParameterSetName = "WaitTimed"), Alias("r")]
        public SwitchParameter NoRedraw
        {
            get { return this._noRedraw; }
            set { this._noRedraw = value; }
        }

        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = "WaitTimed")]
        public int Timeout
        {
            get { return this._timeout; }
            set { this._timeout = value; }
        }

        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true,
            ParameterSetName = "WaitTimed")]
        public TimeUnit Unit
        {
            get { return this._unit; }
            set { this._unit = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private SwitchParameter _indefinite;
        private SwitchParameter _noBreak;
        private SwitchParameter _noRedraw;
        private int _timeout = 5;
        private Timer _timer;
        private TimeUnit _unit = TimeUnit.Second;

        #endregion
    }
}
